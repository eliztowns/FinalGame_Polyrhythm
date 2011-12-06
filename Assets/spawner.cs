using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
	public float paint_timer;
	private float[] lanes = {-0.25f, 0.0f, 0.25f};
	
	public yellowPaint ypPrefab;
	public bluePaint bpPrefab;
	public redPaint rpPrefab;
	
	public int color;
	public int lane;
	public float paint_frequency = 4.0f;
	
	
	// Use this for initialization
	void Start () {
		paint_timer = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		paint_timer += Time.deltaTime;
		
		if(paint_timer > paint_frequency){
			color = Random.Range(0, 3);
			lane = Random.Range(0, 3);
			Vector3 spawnPlace = new Vector3(5.32399f, 1f, lanes[lane]);
			
			if(color == 0){//red
				redPaint rp = (redPaint)Instantiate(rpPrefab);
				rp.transform.position = spawnPlace;
				rp.transform.parent = transform;
			}
			else if(color == 1){//blue
				bluePaint bp = (bluePaint)Instantiate(bpPrefab);
				bp.transform.position = spawnPlace;
				bp.transform.parent = transform;
			}
			else{//yellow
				yellowPaint yp = (yellowPaint)Instantiate(ypPrefab);
				yp.transform.position = spawnPlace;
				yp.transform.parent = transform;
			}
			
			paint_timer -= paint_frequency;	
		}
	
	}
	


}
