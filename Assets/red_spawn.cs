using UnityEngine;
using System.Collections;

public class red_spawn : MonoBehaviour {
	
	public float spawnChance = 0.005f;
	//public int lane;
	public Vector3 spawnPlace = new Vector3 (5.32399f, 1f, -0.025f);
	public redPaint rpPrefab;
	public float x = 0;

	/* Use this for initialization
	void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
		if(Random.value < spawnChance && rpPrefab)
		{
			x = Random.Range(0,100);
			
			if(x%2 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, -0.25f);
				Vector3 pos1 = new Vector3(5.32399f, 1f, -0.25f);
			
				redPaint rp = (redPaint)Instantiate(rpPrefab);
				rp.transform.position = spawnPlace;
				
				rp.transform.animation.Play("spawningworks");
				
				rp.transform.animation.Play("fallingworks");
			
				rp.transform.parent = transform;
			}
			else if(x%3 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0f);
				Vector3 pos2 = new Vector3(5.32399f, 1f, 0f);
			
				redPaint rp = (redPaint)Instantiate(rpPrefab);
				rp.transform.position = spawnPlace;
				
				rp.transform.animation.Play("spawningworks");
				
				rp.transform.animation.Play("fallingworks");
			
				rp.transform.parent = transform;
			}
			else if(x%5 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0.25f);
				Vector3 pos3 = new Vector3(5.32399f, 1f, 0.25f);
			
				redPaint rp = (redPaint)Instantiate(rpPrefab);
				rp.transform.position = spawnPlace;
				
				rp.transform.animation.Play("spawningworks");
				
				rp.transform.animation.Play("fallingworks");
			
				rp.transform.parent = transform;
			}
		}
	}
}
