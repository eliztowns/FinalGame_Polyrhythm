using UnityEngine;
using System.Collections;

public class timerScript : MonoBehaviour {
	
	public float game_time;
	private float end_time = 180f;
	private float menu_time;
    public float time_till_kickback = 5.0f;
	public int penalty_limit;
	
	
	private player_class player;
	public Texture2D winScreen;
	public Texture2D loseScreen;
	private bool game_over;
    private bool player_won = false;
	
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
	
	void OnGUI() {
		if(game_over && player_won)
            GUI.DrawTexture(new Rect (Screen.width/2 - 256,Screen.height/2 - 256, 512, 512), winScreen);
        else if(game_over && !player_won)
            GUI.DrawTexture(new Rect (Screen.width/2 - 256,Screen.height/2 - 256, 512, 512), loseScreen);
		
	}
	
	// Update is called once per frame
	void Update () {
		game_time += Time.deltaTime;
		
		if(game_time > end_time) {
			game_over = true;
            player_won = true;
        }
		
		if(menu_time > time_till_kickback)
			Application.LoadLevel("MainMenu-Lummis-Mouse");
		
		if (player.penalties <= 0) {
			game_over = true;
            player_won = false;
		}
        
		if(game_over)
			menu_time += Time.deltaTime;
	
	}
}
