using UnityEngine;
using System.Collections;

public class ultimate_paintdrop : MonoBehaviour {
	public Texture2D paintdrop_thing;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnGUI(){
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), paintdrop_thing);

		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("foot_pedal"))
			Application.LoadLevel("ultimate_tutorial_chucknorris");	
	}
}
