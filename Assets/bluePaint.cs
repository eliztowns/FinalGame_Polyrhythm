using UnityEngine;
using System.Collections;

public class bluePaint : MonoBehaviour {
	
	private player_class thePlayer;
	public float dist = 1f;
	private combo_master combos;
	public float wait = 30f;
	public float i = 0f;
	public GameObject orbiter;
	private GUIScript tolerance;
    private Director theDirector;

	// Use this for initialization
	void Start () {
		GameObject temp = GameObject.Find("player_prefab");
		thePlayer = temp.GetComponent<player_class>();
		combos = temp.GetComponent<combo_master>();
		
		GameObject temp2 = GameObject.Find("GUI - Bar");
		tolerance = temp2.GetComponent<GUIScript>();
        
		GameObject temp3 = GameObject.Find("Director");
		theDirector = temp3.GetComponent<Director>();
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
                theDirector.missed_blue -= 1;
				Destroy(gameObject);
			}
			
			i++;
			
		}
		
		if((thePlayer.color == "blue") && Mathf.Abs(thePlayer.transform.position.z - transform.position.z) < 0.1)
		{
			if((transform.position.x <= (thePlayer.transform.position.x + dist)) && (transform.position.x > thePlayer.transform.position.x)
			   																		&& ((tolerance.value > 30.0f) && (tolerance.value < 70.0f)))
			{
				combos.output_queue.Enqueue("catch");
				//CATCH
				print("PLEASEB");
				Destroy(gameObject);
				print("WORKB");
                theDirector.missed_blue = 0;
				
				//create orbiter
				GameObject o;
				o=(GameObject)Instantiate(orbiter,thePlayer.transform.position,thePlayer.transform.rotation);
				o.transform.parent=thePlayer.transform;
			}
		}
		
	}
}
