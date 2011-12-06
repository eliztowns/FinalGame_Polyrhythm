using UnityEngine;
using System.Collections;

public class bluePaint : MonoBehaviour {
	
	private player_class thePlayer;
	public float dist = 0.01f;
	private combo_master combos;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("player_prefab");
		thePlayer = temp.GetComponent<player_class>();
		combos = temp.GetComponent<combo_master>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(transform.position.y <= 0)
		{
			combos.output_queue.Enqueue("drop");
			//SPLATTER ANIMATION
			Destroy(gameObject);
			
		}
		else if((thePlayer.color == "blue") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z - 1) < 0) && (transform.position.z == 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				combos.output_queue.Enqueue("catch");
				//CATCH
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "blue") && ((thePlayer.transform.position.z > 0) && ((thePlayer.transform.position.z -1) > 0) && (transform.position.z > 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				combos.output_queue.Enqueue("catch");
				//CATCH
				Destroy(gameObject);
			}
		}
		else if((thePlayer.color == "blue") && ((thePlayer.transform.position.z < 0) && (transform.position.z < 0)))
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{
				combos.output_queue.Enqueue("catch");
				//CATCH
				Destroy(gameObject);
			}
		}
		
	}
}
