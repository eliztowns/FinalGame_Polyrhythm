using UnityEngine;
using System.Collections;

public class ultimate_tolerance : MonoBehaviour {
	public Texture2D tolerance_thing;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI(){
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), tolerance_thing);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("foot_pedal"))
			Application.LoadLevel("ultimate_mainmenu_chucknorris");
	}
}
