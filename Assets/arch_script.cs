using UnityEngine;
using System.Collections;

public class arch_script : MonoBehaviour {
	
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("player_prefab");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 trans = new Vector3(Time.deltaTime, 0, 0);
		transform.Translate(trans);
		
		if(transform.position.x + 3.4f < player.transform.position.x)
			Destroy(gameObject);
	}
}
