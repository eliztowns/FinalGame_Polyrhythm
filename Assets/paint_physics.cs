using UnityEngine;
using System.Collections;

public class paint_physics : MonoBehaviour {
	
	public float p_x = -0.0143f;
	public float p_y = -0.003f;
	//public Vector3 startpos;

	// Use this for initialization
	void Start () {
		
		//startpos = transform.position;
			
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(p_x, p_y, 0);
		
	}
}
