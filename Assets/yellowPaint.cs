using UnityEngine;
using System.Collections;

public class yellowPaint : MonoBehaviour {
	
	private player_class thePlayer;
	public float dist = 0.01f;
	public float wait = 300;
	public float i = 0;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("player_prefab");
		thePlayer = temp.GetComponent<player_class>();
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate(-0.0143f, -0.003f, 0);
	
		if(transform.position.y <= 0)
		{
			
			//SPLATTER ANIMATION
			transform.animation.transform.position = transform.position;
			transform.Translate(-0.02f, 0, 0);
			transform.animation.transform.Translate(-0.02f, 0.01f, 0);
			transform.animation.Play("missedworks");
			
			if(i == wait)
			{
				Destroy(gameObject);
			}
			i++;
			
		}
		else if((thePlayer.color == "yellow") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z - 1) < 0) && (transform.position.z == 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				//CATCH
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "yellow") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z -1) > 0) && (transform.position.z > 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				//CATCH
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "yellow") && ((thePlayer.transform.position.z < 0) && (transform.position.z < 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				//CATCH
				Destroy(gameObject);
			}
		}
		
	}
}
