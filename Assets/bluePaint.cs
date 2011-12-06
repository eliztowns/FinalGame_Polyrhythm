using UnityEngine;
using System.Collections;

public class bluePaint : MonoBehaviour {
	
	private player_class thePlayer;
	public float dist = 0.01f;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("player_prefab");
		thePlayer = temp.GetComponent<player_class>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.y <= 0)
		{
			
			//SPLATTER ANIMATION
			Destroy(gameObject);
			
		}
		else if((thePlayer.color == "blue") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z - 1) < 0) && (transform.position.z == 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "blue") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z -1) > 0) && (transform.position.z > 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "blue") && ((thePlayer.transform.position.z < 0) && (transform.position.z < 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				Destroy(gameObject);
			}
		}
		
	}
}
