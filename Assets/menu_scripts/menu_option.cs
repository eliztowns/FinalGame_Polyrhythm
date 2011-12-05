using UnityEngine;
using System.Collections;

public class menu_option : MonoBehaviour {
	
	public int position;
	
	public void move_forward(){
		if(position == 0)
			transform.Translate(transform.forward);
	}
	
	public void move_back(){
		if(position == 1){
		Vector3 backward = transform.forward;
		backward.z = -backward.z;
		transform.Translate(backward);
		}
	}
	
	
	// Use this for initialization
	void Start () {
		position = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
