using UnityEngine;
using System.Collections;

public class yellowPaint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(transform.position.y <= 0)
		{
			
			//SPLATTER ANIMATION
			Destroy(gameObject);
			
		}
		
	}
}
