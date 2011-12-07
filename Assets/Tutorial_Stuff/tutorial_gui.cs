using UnityEngine;
using System.Collections;

public class tutorial_gui : MonoBehaviour {
	
		//drum pads
	public Texture2D redpad;
	public Texture2D yellowpad;
	public Texture2D bluepad;
	public Texture2D greenpad;
	public Texture2D drumhit;
	
	private float gap_from_top_ratio;
	public float outer_ratio_gap;
	public float inner_ratio_gap;
	
	private float gap;
	private float ratio;
	private float icon_dim;
	
	public string cur_combo;
	public float tutorial_cooldown;
	private float tutorial_complete;
	
	private GameOptions gameOptions;
	private combo_master combos;
	private tutorial_script t_script;
	
	
	void OnGUI(){
		
		if (GUI.Button (new Rect (gap * 1 + icon_dim * 0, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), redpad, ""))
            t_script.drum_hit[1] = true;
        if (GUI.Button (new Rect (gap * 2 + icon_dim * 1, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), yellowpad, ""))
			t_script.drum_hit[2] = true;
        if (GUI.Button (new Rect (gap * 3 + icon_dim * 2, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), bluepad, ""))
            t_script.drum_hit[3] = true;
        if (GUI.Button (new Rect (gap * 4 + icon_dim * 3, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), greenpad, ""))
            t_script.drum_hit[4] = true;
		
		for(int i=0; i<4; i++){
			if(t_script.drum_hit[i]){
				if( i == 0 || i == 3)
					GUI.Button(new Rect (gap * (i + 1) + icon_dim * i, Screen.height* gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), drumhit, "");
				else
					GUI.Button(new Rect (gap * (i + 1) + icon_dim * i, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
			}		
		}
		
		
		if(cur_combo == "blue" && tutorial_cooldown > 0){
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 300, 150), "This is a blue combo:");
			int temp_time = (int)tutorial_cooldown;
			if(tutorial_cooldown - (float)temp_time < 0.5f){
			int lit = -1;
			if(temp_time < combos.blue_combo.Count)
				lit = decode(combos.blue_combo[temp_time]);
			if(lit == 3){
				GUI.Button(new Rect (gap * (2) + icon_dim * 1, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
				GUI.Button(new Rect (gap * (3) + icon_dim * 2, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");								
			}
			else if(lit != -1)
				GUI.Button(new Rect (gap * (lit + 1) + icon_dim * lit, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
			}
		}
		else if(cur_combo == "yellow" && tutorial_cooldown > 0){
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 300, 150), "This is a yellow combo:");
			int temp_time = (int)tutorial_cooldown;
			if(tutorial_cooldown - (float)temp_time < 0.5f){
			int lit = -1;
			if(temp_time < combos.yellow_combo.Count)
				lit = decode(combos.yellow_combo[temp_time]);
			if(lit == 3){
				GUI.Button(new Rect (gap * (2) + icon_dim * 1, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
				GUI.Button(new Rect (gap * (3) + icon_dim * 2, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");								
			}
			else if(lit != -1)
				GUI.Button(new Rect (gap * (lit + 1) + icon_dim * lit, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
				
		}}
		
		else if(cur_combo == "red" && tutorial_cooldown > 0){
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 300, 150), "This is a red combo:");
			int temp_time = (int)tutorial_cooldown;
			if(tutorial_cooldown - (float)temp_time < 0.5f){
			int lit = -1;
			if(temp_time < combos.red_combo.Count)
				lit = decode(combos.red_combo[temp_time]);
			if(lit == 3){
				GUI.Button(new Rect (gap * (2) + icon_dim * 1, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
				GUI.Button(new Rect (gap * (3) + icon_dim * 2, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");								
			}
			else if(lit != -1)
				GUI.Button(new Rect (gap * (lit + 1) + icon_dim * lit, Screen.height* gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), drumhit, "");
				
		}}
		else if(tutorial_cooldown>0 || t_script.complete){
			GUI.Label(new Rect(Screen.width/2, Screen.height/2, 100, 50), "Nice job!");
			tutorial_cooldown = 0;
			t_script.complete = true;
		}
	}

	public int decode(string color){
		if(color == "yellow")
			return 1;
		else if(color == "blue")
			return 2;
		else
			return 3;
	}
	
	// Use this for initialization
	void Start () {
		tutorial_cooldown = 7f;
		
		gap = Screen.width / 25.0f;
		ratio = Screen.width / (5.0f * redpad.width);
		icon_dim = redpad.width;
		Debug.Log(redpad.width);
		
		GameObject options_temp = GameObject.Find("GameOptions");
		gameOptions = options_temp.GetComponent<GameOptions>();
		GameObject bino_temp = GameObject.Find("tutorial_bino");
		t_script = bino_temp.GetComponent<tutorial_script>();
		combos = bino_temp.GetComponent<combo_master>();
		
		cur_combo = "blue";
	
	}
	
	// Update is called once per frame
	void Update () {
		tutorial_cooldown -= Time.deltaTime;
		if(tutorial_cooldown < 0)
			tutorial_cooldown = 0;
	
	}
}