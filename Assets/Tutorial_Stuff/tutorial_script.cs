using UnityEngine;
using System.Collections;

public class tutorial_script : MonoBehaviour {
	//textures	
	public Texture red_tex ;
	public Texture blue_tex ;
	public Texture white_tex ;
	public Texture yellow_tex ;
	
	private GameOptions gameOptions;
	private combo_master combos;
	private tutorial_gui t_gui;
	
	public bool input_lock;
	private string color;
	private float cooldown;
	public bool complete;
	
	public float idiot_timer;
	
	public bool[] drum_hit = {false, false, false, false};
	private float[] drum_cooldown = {0f, 0f, 0f, 0f};
	
	public float count;
	
	GameObject bino;
	
	public void apply_texture(){
		GameObject []bodyparts = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject bodypart in bodyparts){
			if(color == "none")
				bodypart.renderer.material.mainTexture = white_tex;	
			else if(color == "blue")
				bodypart.renderer.material.mainTexture = blue_tex;	
			else if(color == "red")
				bodypart.renderer.material.mainTexture = red_tex;	
			if(color == "yellow")
				bodypart.renderer.material.mainTexture = yellow_tex;			
		}
		if(color != "none")
			bino.animation.CrossFade("powerup");
	}
	
		
	// Use this for initialization
	void Start () {
		complete = false;
		
		GameObject options_temp = GameObject.Find("GameOptions");
		gameOptions = options_temp.GetComponent<GameOptions>();
		combos = GetComponent<combo_master>();
		
		GameObject gui_temp = GameObject.Find("gui_object");
		t_gui = gui_temp.GetComponent<tutorial_gui>();
		
		color = "none";
		input_lock = true;
		
		//LOAD TEXTURES
		/*red_tex = Resources.Load("red") as Texture;
		blue_tex = Resources.Load("blue") as Texture;
		white_tex = Resources.Load("white") as Texture;
		yellow_tex = Resources.Load("yellow") as Texture;*/
		
		//DEAL WITH ANIMATIONS
		bino = GameObject.Find("tutorial_bino");
		bino.animation.Stop();
		bino.animation.Play("running");
		bino.animation["running"].speed = 1.6f;
		
		bino.animation["powerup"].layer = 1;
		
		bino.animation.wrapMode = WrapMode.Once;
		bino.animation["running"].wrapMode = WrapMode.Loop;
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		for(int i=0; i<4; i++){
			drum_cooldown[i] -= Time.deltaTime;
			if(drum_cooldown[i] <0)
				drum_cooldown[i] = 0;
			
			if(drum_cooldown[i] == 0)
				drum_hit[i] = false;
		}
		
		if(t_gui.tutorial_cooldown == 0){
			input_lock = false;
			idiot_timer += Time.deltaTime;
			if(idiot_timer > 7){
				t_gui.tutorial_cooldown = 7f;
				input_lock = true;
				idiot_timer = 0;
			}
				
		}
		
		
		receive_input();
		
	}
	
	
	
	public void receive_input(){
		
		cooldown -= Time.deltaTime;
		if(cooldown  < 0)
			cooldown = 0;
		
		combos = GetComponent<combo_master>();
		Queue input = combos.output_queue;
		
		if(!input_lock){
			if(Input.GetButtonDown("blue")){
			   drum_hit[2] = true;
				drum_cooldown[2] = 0.2f;	
			}
			if(Input.GetButtonDown("yellow")){
				drum_hit[1] = true;
				drum_cooldown[1] = 0.2f;
			}
			if(Input.GetButtonDown("foot_pedal") && complete)
			   Application.LoadLevel("ultimate_leftright_chucknorris");
			   
			
			foreach(string key in input){
				if(key == "green"){
					drum_hit[3] = true;
					drum_cooldown[3] = 0.2f;	
				}
				else if (key == "red"){
					drum_hit[0] = true;
					drum_cooldown[0] = 0.2f;	
				}
				else if (key == "red_combo"){
					color = "red";
					cooldown = 3;
					apply_texture();
					
					//check to see if this was what they were trying to do
					if(t_gui.cur_combo == "red"){
						t_gui.cur_combo = "done";
						idiot_timer = 0;
						input_lock = true;
						t_gui.tutorial_cooldown = 7f;
					}
				}
				else if (key == "blue_combo"){
					color = "blue";
					cooldown = 3;
					apply_texture();
					
					//check to see if this was what they were trying to do
					if(t_gui.cur_combo == "blue"){
						t_gui.cur_combo = "yellow";
						idiot_timer = 0;
						input_lock = true;
						t_gui.tutorial_cooldown = 7f;
						//count = combos.yellow_combo.Count;
					}
				}
				else if (key=="yellow_combo"){
					color = "yellow";
					idiot_timer = 0;
					cooldown = 3;
					apply_texture();
					
					//check to see if this was what they were trying to do
					if(t_gui.cur_combo == "yellow"){
						t_gui.cur_combo = "red";
						input_lock = true;
						t_gui.tutorial_cooldown =  7f;
					}
				}
			}
		}
		
		//clear out output
		combos.empty_output();
		
		//reset the cooldown
		if(cooldown == 0){
			color = "none";
			apply_texture();
		}
		
	}
	
	/*

public class player_class : MonoBehaviour {
	
	public int lane;
	private combo_master input_feed;
	public string color;
	public float cooldown;
	private CharacterController controller;
	private List <string> feet;
	private GameObject player;
	private GameObject bino;
	private float reflected_bps;
	
	//game win/lose conditions
	public int score;
	public int penalties;
	
	private GUIScript gui_instance;
	
	
	void Awake(){
		lane = 1;
		color = "none";
		cooldown = 0;
		feet = new List<string>();
		player = GameObject.Find("player_prefab");
		
		//LOAD TEXTURES
		red_tex = Resources.Load("red") as Texture;
		blue_tex = Resources.Load("blue") as Texture;
		white_tex = Resources.Load("white") as Texture;
		yellow_tex = Resources.Load("yellow") as Texture;
		
		//DEAL WITH ANIMATIONS
		bino = GameObject.Find("bino");
		bino.animation.Stop();
		bino.animation.Play("running");
		bino.animation["running"].speed = 1.6f;
		
		bino.animation.wrapMode = WrapMode.Once;
		bino.animation["running"].wrapMode = WrapMode.Loop;
		bino.animation["powerup"].layer = 1;
		bino.animation["exploding"].layer = 1;
		bino.animation["jumping"].layer = 1;
		
		remaining_tween_z = 0;
		score = 0;
		penalties = 5;
	}
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log(name);
	}
	
	// Update is called once per frame
	void Update () {
		receive_input();
		animation_update();
		if(remaining_tween_z != 0)
			tweening();
		
	}
}*/

}
