using UnityEngine;
using System.Collections;

public class run_bino_run : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//DEAL WITH ANIMATIONS
		GameObject bino = GameObject.Find("menu_bino");
		bino.animation.Stop();
		bino.animation.Play("running");
		bino.animation["running"].speed = 1.6f;
		
		bino.animation["running"].wrapMode = WrapMode.Loop;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
