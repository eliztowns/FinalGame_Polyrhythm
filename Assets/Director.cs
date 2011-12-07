using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Director : MonoBehaviour {

    public List<string> red_combo;
    public List<string> blue_combo;
    public List<string> yellow_combo;
    
    private string difficulty = "medium";
    private int volume = 100;
    
    private GUIScript barGUI;
    private float tolerance;
    private float beats_per_second;
    
    public float easy_start_tolerance = 25.0f;
    public float medium_start_tolerance = 20.0f;
    public float hard_start_tolerance = 10.0f;
    public float easy_start_BPS = 1.0f;
    public float medium_start_BPS = 1.25f;
    public float hard_start_BPS = 1.5f;
    
    private float time_outside_tolerance = 0;
    private bool inside_tolerance = true;
    
    public bool tolerance_message_bool = false;
    public bool red_message_bool = false;
    public bool yellow_message_bool = false;
    public bool blue_message_bool = false;
    
    private string tolerance_message = "";
    private string red_message = "";
    private string yellow_message = "";
    private string blue_message = "";
    private string total_message = "";
    private int num_messages = 0;
    
	// Use this for initialization
	void Start () {
        instantiateGameOptions();	
        setupGameDifficulty();
	}
    
	// Update is called once per frame
	void Update () {
        setGUIBar();
        checkToleranceBar();
        developMessage();
        if(red_combo.Count > 0)
            setMessages();
	}
    
    void OnGUI () {
        float width = 600;
        float height = 30.0f * num_messages;
        GUI.Label(new Rect(Screen.width / 2.0f - 300, 10, width, height), total_message);    
    }
    
    void developMessage() {
        total_message = "";
        num_messages = 0;
        
        if(tolerance_message_bool) {
            total_message += tolerance_message + "\n";
            num_messages += 1;
        }
        
        if(red_message_bool) {
            total_message += red_message + "\n";
            num_messages += 1;
        }
        
        if(yellow_message_bool) {
            total_message += yellow_message + "\n";
            num_messages += 1;
        }
        
        if(blue_message_bool) {
            total_message += blue_message;
            num_messages += 1;
        }
    }
    
    void checkToleranceBar() {
        if(barGUI.tolerant){
            if(inside_tolerance){
                time_outside_tolerance -= 0.1f * Time.deltaTime;
            } else {
                time_outside_tolerance = 0;
            }
        } else {
            if(inside_tolerance){
                time_outside_tolerance -= 0.1f * Time.deltaTime;            
            } else {
                time_outside_tolerance += 1 * Time.deltaTime;
            }
        }    
        if(time_outside_tolerance > 5.0f)
            tolerance_message_bool = true;
        else
            tolerance_message_bool = false;
        inside_tolerance = barGUI.tolerant;
    }
    
    void setupGameDifficulty() {
        GameObject temp_Thing = GameObject.Find("GUI - Bar");
        barGUI = temp_Thing.GetComponent<GUIScript>();
        if(difficulty == "easy") {
            tolerance = easy_start_tolerance;
            beats_per_second = easy_start_BPS;
        } else if(difficulty == "medium") {
            tolerance = medium_start_tolerance;
            beats_per_second = medium_start_BPS;
        } else{
            tolerance = hard_start_tolerance;
            beats_per_second = hard_start_BPS;
        }
    }
    
    void setGUIBar() {
        barGUI.tolerance = tolerance;
        barGUI.beats_per_second = beats_per_second;        
    }
    
    void setMessages() {
        tolerance_message = "You are messing up your foot pedal timings!";
        red_message = "You are messing up the red combo, it is: " + red_combo[0];
        for(int i = 1; i < red_combo.Count; i++)
            red_message += ", " + red_combo[i];
            
        blue_message = "You are messing up the blue combo, it is: " + blue_combo[0];
        for(int i = 1; i < blue_combo.Count; i++)
            blue_message += ", " + blue_combo[i];
            
        yellow_message = "You are messing up the yellow combo, it is: " + yellow_combo[0];
        for(int i = 1; i < yellow_combo.Count; i++)
            yellow_message += ", " + yellow_combo[i];
    }
    
	void instantiateGameOptions() {
        GameObject temp_Thing = GameObject.Find("GameOptions");
        if(temp_Thing != null){
            GameOptions the_options = temp_Thing.GetComponent<GameOptions>();
            red_combo = the_options.red_combo;
            blue_combo = the_options.blue_combo;
            yellow_combo = the_options.yellow_combo;
            volume = the_options.volume;
            difficulty = the_options.difficulty;
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
    
    int Max(int a, int b) {
        if(a < b)
            return b;
        else
            return a;
    }
}