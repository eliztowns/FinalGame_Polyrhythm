using UnityEngine;
using System.Collections;

public class timerScript : MonoBehaviour {
	
	public float game_time;
	private float end_time = 180f;
	private float menu_time;
    public float time_till_kickback = 5.0f;
	public int penalty_limit;
	
	
	private player_class player;
	
	private bool game_over;
	
	// Use this for initialization
	void Start () {
		game_over = false;
	}
	
	void Awake() {
		game_time = 0.0f;
		menu_time = 0.0f;
		
		GameObject player_prefab = GameObject.Find("player_prefab");
		player = player_prefab.GetComponent<player_class>();
	}
	
	void onGui() {
		if(game_over)
			GUI.Label(new Rect(300, 300, 500, 100), "GAME OVER!");
		
	}
	
	// Update is called once per frame
	void Update () {
		game_time += Time.deltaTime;
		
		if(game_time > end_time)
			game_over = true;
		
		if(menu_time > time_till_kickback)
			Application.LoadLevel("MainMenu-Lummis-Mouse");
		
		if (player.penalties <= 0)
			game_over = true;
		
		if(game_over)
			menu_time += Time.deltaTime;
	
	}
}
