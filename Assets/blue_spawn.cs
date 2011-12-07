using UnityEngine;
using System.Collections;

public class blue_spawn : MonoBehaviour {
	
	public float spawnChance = 0.005f;
	//public int lane;
	public Vector3 spawnPlace = new Vector3 (5.32399f, 1f, -0.025f);
	public bluePaint bpPrefab;
	public float x = 0;

	/* Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
		
		if(Random.value < spawnChance && bpPrefab)
		{
			x = Random.Range(0,100);
			
			if(x%2 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, -0.25f);
			}
			else if(x%3 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0f);
			}
			else if(x%5 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0.25f);
			}
			bluePaint bp = (bluePaint)Instantiate(bpPrefab);
			bp.transform.position = spawnPlace;
			
			bp.transform.animation.Play("spawningworks");
			
			bp.transform.animation.wrapMode = WrapMode.Once;
			bp.transform.animation["fallingworks"].wrapMode = WrapMode.Loop;
			
			bp.transform.animation.CrossFadeQueued("fallingworks");
			bp.transform.parent = transform;
			
		}
		
	}
}
