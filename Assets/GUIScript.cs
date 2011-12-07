using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
    private Rect barBackgroundRect;
    private Rect barRect;
    private Rect capRect;
    private Rect glimmerRect;
    private Rect toleranceBarRect;
    
    public Texture2D barBackgroundTexture;
    public Texture2D barTexture;
    public Texture2D capTexture;
    public Texture2D glimmerTexture;
    public Texture2D toleranceBarTexture;
    public Texture2D toleranceLeftTexture;
    public Texture2D toleranceRightTexture;
    
    public float value = 50.0f;
    private float barWidth;
    private float barHeight;
    
    private float space_gain = 6;
    private player_class thePlayer;
    
    public float height_ratio;
    public float from_bottom_gap;
    public float beats_per_second;
    public float tolerance;
    
    private float glimmer_start_time = 0;
    private float glimmer_counter = 0;
    private float glimmer_active_time = 0;
    private float inside_bar_ratio = 6.6f / 8.0f;
    private float inside_bar_y_push = 1.5f / 16.0f;
    private int rainbow_offest = 0;
    private int offset_rate = 5;
    public float tolerance_increase_ratio;
    private string color = "";
    public bool tolerant = true;

    // Use this for initialization
    void Start(){
        Application.targetFrameRate = 60;
        this.tolerance_increase_ratio = ((this.barBackgroundTexture.height + 16) * 1.0f) / (this.barBackgroundTexture.height * 1.0f);
        
        this.barWidth = Screen.width;
        this.barHeight = Screen.height * this.height_ratio;
        
        this.barBackgroundRect.height = this.barHeight;
        this.barBackgroundRect.width = this.barWidth;
        this.barBackgroundRect.y = Screen.height - (Screen.height * this.height_ratio)
                                                 - from_bottom_gap;
                                                     
        this.toleranceBarRect.height = this.barHeight * this.tolerance_increase_ratio;   
        this.toleranceBarRect.width = this.toleranceBarTexture.width * this.tolerance_increase_ratio; 
        this.toleranceBarRect.y = this.barBackgroundRect.y - ((this.toleranceBarRect.height - this.barBackgroundRect.height)/2);
        this.toleranceBarRect.x = Screen.width * (this.value / 100);
                                                     
        this.barRect.height = this.barHeight * this.inside_bar_ratio;
        this.barRect.y = Screen.height - (Screen.height * this.height_ratio)
                                       - from_bottom_gap
                                       + (inside_bar_y_push * this.barHeight);
    
        float ratio = this.barHeight / capTexture.height;
        this.capRect.width = capTexture.width * ratio;
        this.capRect.height = capTexture.height * ratio * this.inside_bar_ratio;
        this.capRect.y = Screen.height - (Screen.height * this.height_ratio)
                                       - from_bottom_gap
                                       + (inside_bar_y_push * this.barHeight);
        
                                           
        this.glimmerRect.width = barWidth;
        this.glimmerRect.height = barHeight * 1.2f;
        this.glimmerRect.y =  Screen.height - (Screen.height * this.height_ratio)
                                            - from_bottom_gap
                                            - (barHeight * 0.1f);
        GameObject temp_Thing = GameObject.Find("player_prefab");
        thePlayer = temp_Thing.GetComponent<player_class>();
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("foot_pedal")){
            this.value = this.value + this.space_gain;
        }
        this.value = this.value - ((Time.deltaTime * this.space_gain) * beats_per_second);            
        this.barRect.width = barWidth * (this.value / 100) - this.capTexture.width + 1;
        this.capRect.x = this.barRect.width - 1;
        
        this.glimmer_counter = 1.0f / beats_per_second;
        this.glimmer_active_time = glimmer_counter * 0.4f;
        
        this.rainbow_offest += this.offset_rate;
        if(this.rainbow_offest >= Screen.width)
            this.rainbow_offest = 0;
        
        isInTolerance();
        
        if(Time.time >= this.glimmer_counter + this.glimmer_start_time)
            this.glimmer_start_time = Time.time;
    }
    
    // OnGUI is called multiple times per frame (about 4 times)
    void OnGUI() {
        //if(Time.time < this.glimmer_start_time + this.glimmer_active_time)
        //    GUI.DrawTexture(glimmerRect, glimmerTexture);
        
        if(this.color != thePlayer.color) {
            this.color = thePlayer.color;
            string newColor = "white";
            if(this.color != "none")
                newColor = this.color;
            Debug.Log(newColor);
            toleranceBarTexture = Resources.Load(newColor + "dots") as Texture2D;
            toleranceLeftTexture = Resources.Load(newColor + "left") as Texture2D;
            toleranceRightTexture = Resources.Load(newColor + "right") as Texture2D;
        }
        
        barBackgroundRect.x = this.rainbow_offest;
        GUI.DrawTexture(barBackgroundRect, barBackgroundTexture);
        barBackgroundRect.x = this.rainbow_offest - barBackgroundRect.width;
        GUI.DrawTexture(barBackgroundRect, barBackgroundTexture);
        
        GUI.DrawTexture(capRect, capTexture);
        GUI.DrawTexture(barRect, barTexture);
        
        float tolerance_length = this.barWidth * ((this.tolerance * 4) / 100);
        int num_dots = ((int)(tolerance_length / this.toleranceBarRect.width));
        float start_tolerance = ((50.0f - this.tolerance)/100) * Screen.width;
        for(int i=0; i < num_dots; i++) {
            if(i == 0){
                this.toleranceBarRect.x = start_tolerance + i * this.toleranceBarRect.width;
                this.toleranceBarRect.width = this.toleranceLeftTexture.width * this.tolerance_increase_ratio; 
                GUI.DrawTexture(toleranceBarRect, toleranceLeftTexture);
            } else if(i == num_dots - 1){
                this.toleranceBarRect.x = start_tolerance + i * this.toleranceBarRect.width;
                this.toleranceBarRect.width = this.toleranceRightTexture.width * this.tolerance_increase_ratio; 
                GUI.DrawTexture(toleranceBarRect, toleranceRightTexture);
            } else {    
                this.toleranceBarRect.x = start_tolerance + i * this.toleranceBarRect.width;
                this.toleranceBarRect.width = this.toleranceBarTexture.width * this.tolerance_increase_ratio; 
                GUI.DrawTexture(toleranceBarRect, toleranceBarTexture);
            }
        }
    }
    
    void isInTolerance() {
        tolerant = ((50.0f + tolerance >= value) && (50.0f - tolerance <=  value));
    }
}