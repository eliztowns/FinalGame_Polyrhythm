using UnityEngine;
using System.Collections;

public class yellow_spawn : MonoBehaviour {
	
	public float spawnChance = 0.005f;
	//public int lane;
	public Vector3 spawnPlace = new Vector3 (5.32399f, 1f, -0.025f);
	public yellowPaint ypPrefab;
	public float x = 0;
	

	/* Use this for initialization
	void Start () {
		
	}*/
	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Random.value < spawnChance && ypPrefab)
		{
			x = Random.Range(0,100);
			
			if(x%2 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, -0.25f);
				Vector3 pos1 = new Vector3(5.32399f, 1f, -0.25f);
			
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
				
				yp.transform.animation.Play("spawningworks");
			
				yp.transform.parent = transform;
				
			}
			else if(x%3 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0f);
				Vector3 pos2 = new Vector3(5.32399f, 1f, 0f);
			
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
				
				yp.transform.animation.Play("spawningworks");
			
				yp.transform.parent = transform;
				
			}
			else if(x%5 == 0)
			{
				spawnPlace = new Vector3(5.32399f, 1f, 0.25f);
				Vector3 pos3 = new Vector3(5.32399f, 1f, 0.25f);
			
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
				
				yp.transform.animation.Play("spawningworks");
			
				yp.transform.parent = transform;
				
			}
		}

	}
}
