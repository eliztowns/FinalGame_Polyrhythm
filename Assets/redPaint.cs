using UnityEngine;
using System.Collections;

public class redPaint : MonoBehaviour {
	
	private player_class thePlayer;
	public float dist = 1f;
	private combo_master combos;
	public float wait = 300f;
	public float i = 0f;

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
			transform.animation.transform.Translate(-0.02f, 0f, 0f);
			transform.Translate(-0.02f, 0f, 0f);
			transform.animation.Play("missedworks");
			
			if(i == wait)
			{
				Destroy(gameObject);
			}
			
			i++;
			
		}

		if((thePlayer.color == "red") && Mathf.Abs(thePlayer.transform.position.z - transform.position.z) < 0.1)
		{
			if(transform.position.x <= (thePlayer.transform.position.x + dist))
			{

				//CATCH
				combos.output_queue.Enqueue("catch");
				print("PLEASE");
				Destroy(gameObject);
				print("WORK");
			}
		}

		
	}
}
