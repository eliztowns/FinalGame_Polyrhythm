using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class combo_master : MonoBehaviour {
	private static combo_master instance;
	public bool test_combo;
	public string seen;
	public int test_count;
	public int combo_count;
	
	public Queue output_queue;
	public List <key_pair> combo_interpreter;
	private float combo_timer;
	private float simul_timer;
	private InputManager input;
    private GameOptions the_options;
	
	public List<string> red_combo = new List<string>();
	public List<string> blue_combo = new List<string>();
	public List<string> yellow_combo = new List<string>();
    
    public GameObject blue_sparkles;
    public GameObject green_sparkles;
    public GameObject red_sparkles;
    public GameObject yellow_sparkles;
	
	public static combo_master get{
		get{
			if(!instance)
				Debug.LogError("No InputManager in scene");
			return instance;
		}
	}
	
	void Awake(){
		instance = this;
		output_queue = new Queue();
		combo_interpreter = new List<key_pair>();
	}
	
	//let player_class empty out output after used up
	public void empty_output(){
		output_queue.Clear();	
	}
	
	//register combos
	public void handle_combos(){
		key_pair key;
		seen = "";
		
		while(InputManager.get.HasKeys()){
			key = InputManager.get.GetNextKey();
			if(key.name == "green") {
				output_queue.Enqueue(key.name);
                if(green_sparkles)
                    green_sparkles.particleEmitter.Emit();
			} else if(key.name == "red") {
				output_queue.Enqueue(key.name);
                if(red_sparkles)
                    red_sparkles.particleEmitter.Emit();
            } else if(key.name == "blue") {
				combo_interpreter.Add(key);
				seen += key.name;
                if(blue_sparkles)
                    blue_sparkles.particleEmitter.Emit();
			} else if(key.name == "yellow") {
				combo_interpreter.Add(key);
				seen += key.name;
                if(yellow_sparkles)
                    yellow_sparkles.particleEmitter.Emit();
            }
		}
	}
	
	//clean up list and combine simulatenous pad registers into combos
	public List <key_pair> clean_list(){
		List <key_pair> temp = new List <key_pair>();
		float cutofftime = Time.time - combo_timer;
		test_count = combo_interpreter.Count;
		
		for(int i = 0; i<combo_interpreter.Count; i++){
			//forget about input too old to be part of current combo
			if(combo_interpreter[i].time > cutofftime){
				//check to see if the next one is simultaneous with this one
				if(i<combo_interpreter.Count-1){
					if(combo_interpreter[i+1].time - combo_interpreter[i].time <= simul_timer && combo_interpreter[i].name != combo_interpreter[i+1].name){
						//it was simultaneous, create a combo hit for it
						key_pair combo;
						combo.name = "combo";
						combo.time = combo_interpreter[i].time;
						temp.Add(combo);
						//skip over the next thing, as we've already consumed it
						i++;
						combo_count++;
					}
					else
						temp.Add(combo_interpreter[i]);
				}
				else
					temp.Add(combo_interpreter[i]);						
			}
		}
		
		return temp;
		
	}
	
	//interpret combo_queue
	public void parse_combos(){
		//get an augmented version of list to check for combos with
		List <key_pair> temp = clean_list();
		int temp_count = temp.Count;
		
		//we have out updated list, now check for combinations
		if(temp.Count >= red_combo.Count){
			//red
			int offset = 0;
			for(int i = 0; i< temp.Count-red_combo.Count + 1; i++){
				for(int x = i; x<i+red_combo.Count; x++){
					//check to see if we have a contiguous combo
					if(temp[x].name == red_combo[offset])
						offset++;
					//if our combo breaks off, reset
					else{
						offset = 0;
						break;
					}
				}
				//check to see if we had a full combo
				if(offset!=0){
					//if we did, add the combo to our output queue
					//clear the combo from our combination interpreter
					output_queue.Enqueue("red_combo");
					Debug.Log("Red: Count is: " + temp.Count + " i is: " + i + "offset is: " + offset);
					temp.RemoveRange(i, offset);
					offset = 0;
					break;
				}
			}
		}
		if(temp.Count >= blue_combo.Count){
			//blue
			int offset = 0;
			for(int i = 0; i< temp.Count-blue_combo.Count + 1; i++){
				for(int x = i; x<i+blue_combo.Count; x++){
					//check to see if we have a contiguous combo
					if(temp[x].name == blue_combo[offset])
						offset++;
					//if our combo breaks off, reset and move on
					else{
						offset = 0;
						break;
					}
				}
				//check to see if we had a full combo
				if(offset != 0){
					//if we did, add the combo to our output queue
					output_queue.Enqueue("blue_combo");
					//clear the combo from our combination interpreter
					Debug.Log("Blue: Count is: " + temp.Count + " i is: " + i);
					temp.RemoveRange(i, offset);
					offset = 0;
					break;
				}
			}
				
		}
		//yellow
		if(temp.Count >= yellow_combo.Count){
			int offset = 0;
			for(int i = 0; i< temp.Count-yellow_combo.Count +1; i++){
				for(int x = i; x<i+yellow_combo.Count; x++){
					//check to see if we have a contiguous combo
					if(temp[x].name == yellow_combo[offset])
						offset++;
					//if our combo breaks off, reset
					else{
						offset = 0;
						break;
					}
				}
				//check to see if we had a full combo
				if(offset != 0){
					//if we did, add the combo to our output queue
					output_queue.Enqueue("yellow_combo");
					//clear the combo from our combination interpreter
					Debug.Log("Yellow: Count is: " + temp.Count + " i is: " + i);
					temp.RemoveRange(i, offset);
					offset = 0;
					break;
				}
			}
			
		}
		
		if(temp.Count < temp_count)
			Debug.Log("temp count changed: " + temp_count + "->" + temp.Count);
		
		combo_interpreter = temp;
		
	}
	
	// Use this for initialization
	void Start () {
		simul_timer = 0.05f;
		combo_timer = 7;
		combo_count = 0;
        Debug.Log("Num of gameoptions: " + GameObject.FindGameObjectsWithTag("GameOptions").Length);
        GameObject temp_Thing = GameObject.Find("GameOptions");
        if(temp_Thing != null) {
            the_options = temp_Thing.GetComponent<GameOptions>();
            red_combo = the_options.red_combo;
            blue_combo = the_options.blue_combo;
            yellow_combo = the_options.yellow_combo;
            Debug.Log("~~~Created combo master, combo length: " + red_combo.Count + " vs. " + the_options.red_combo.Count);
        } else {
            red_combo.Add("blue");
            red_combo.Add("combo");
            red_combo.Add("blue");
            red_combo.Add("combo");
            red_combo.Add("blue");
            red_combo.Add("combo");
            blue_combo.Add("yellow");
            blue_combo.Add("yellow");
            blue_combo.Add("yellow");
            blue_combo.Add("yellow");
            blue_combo.Add("yellow");
            blue_combo.Add("yellow");
            yellow_combo.Add("combo");     
            yellow_combo.Add("combo");      
            yellow_combo.Add("combo");      
            yellow_combo.Add("combo");   
        }
	}
	
	// Update is called once per frame
	void Update () {
		//recieve new input
		handle_combos();
		parse_combos();
	
	}
}
