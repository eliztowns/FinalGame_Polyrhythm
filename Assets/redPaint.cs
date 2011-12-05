using UnityEngine;
using System.Collections;

public class redPaint : MonoBehaviour {
	
	public player_class thePlayer;

	// Use this for initialization
	void Start () {
		//GameObject temp = GameObject.Find("player_prefab");
		//thePlayer = temp.GetComponent<player_class>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(transform.position.y <= 0)
		{
			
			//SPLATTER ANIMATION
			Destroy(gameObject);
			
		}
		
		//if(thePlayer.color == "red" && )
		//{
			
		//}

		
	}
}
