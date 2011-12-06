using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//red 2
//yellow 4
//blue 3
//green 1
//foot pedal 5
//start 8
//back 7

public class menu_script : MonoBehaviour {
	
	public int lane;
	private combo_master input_feed;
	public string color;
	public float cooldown;
	private CharacterController controller;
	public List <string> feet;
	public GameObject player;
	public GameObject bino;
	public float reflected_bps;
	
	private GUIScript gui_instance;
	
	//textures	
	public Texture red_tex ;
	public Texture blue_tex ;
	public Texture white_tex ;
	public Texture yellow_tex ;
	
	//sliding around stuff
	private bool is_tweening;
	private float remaining_tween_z;
	
	private void tweening(){
		Vector3 trans_coords = transform.forward;
		//we are moving right
		if(remaining_tween_z > 0){
			trans_coords.z = 0.15f * Time.deltaTime * 1.8f;
			if(trans_coords.z > remaining_tween_z)
				trans_coords.z = remaining_tween_z;
		}
		//we are moving left
		else{
			trans_coords.z = -0.15f * Time.deltaTime * 1.8f;
			if(trans_coords.z < remaining_tween_z)
				trans_coords.z = remaining_tween_z;
		}
		
		transform.Translate(trans_coords);
		remaining_tween_z -= trans_coords.z;
		
	}
	
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
	}
	
	public void menu_change(bool direction){
		
		
	}
	
	public void menu_accept(){
		
		
	}
	
	public void receive_input(){
		
		cooldown -= Time.deltaTime;
		if(cooldown  < 0)
			cooldown = 0;
		
		input_feed = GetComponent<combo_master>();
		Queue input = input_feed.output_queue;
		
		foreach(string key in input){
			//change menu selection up
			if(key == "green")
				menu_change(true);
			//change menu selection down
			else if (key == "red")
				menu_change(false);
			//accept menu selection
			else if (key == "foot_pedal")
				menu_accept();
			else if (key == "red_combo"){
				color = "red";
				cooldown = 3;
				apply_texture();
			}
			else if (key == "blue_combo"){
				color = "blue";
				cooldown = 3;
				apply_texture();
			}
			else if (key=="yellow_combo"){
				color = "yellow";
				cooldown = 3;
				apply_texture();
			}
		}
		
		//clear out output
		input_feed.empty_output();
		
		//reset the cooldown
		if(cooldown == 0){
			color = "none";
			apply_texture();
		}
		
	}
	
	void Awake(){
		lane = 1;
		color = "none";
		cooldown = 0;
		feet = new List<string>();
		player = GameObject.Find("player_prefab");
		
		red_tex = Resources.Load("red") as Texture;
		blue_tex = Resources.Load("blue") as Texture;
		white_tex = Resources.Load("white") as Texture;
		yellow_tex = Resources.Load("yellow") as Texture;
		
		bino = GameObject.Find("bino");
		bino.animation.Stop();
		bino.animation.Play("running");
		bino.animation["running"].speed = 1.6f;
		
		bino.animation.wrapMode = WrapMode.Loop;
		
		remaining_tween_z = 0;
	}
	
	
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		receive_input();
		//animation_update();
		if(remaining_tween_z != 0)
			tweening();
	}
}
