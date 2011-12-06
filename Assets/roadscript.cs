using UnityEngine;
using System.Collections;

public class roadscript : MonoBehaviour {
	private Vector3 startpos;
	private float halflength;
	public float speed_constant;
	private float speed;
	
	// Use this for initialization
	void Start () {
		startpos = transform.position;
		halflength = renderer.bounds.max.x - renderer.bounds.center.x;
	}
	
	// Update is called once per frame
	void Update () {
		speed=speed_constant * GameObject.Find("GUI - Bar").GetComponent<GUIScript>().beats_per_second;
		transform.Translate(speed,0,0);
		Camera camera = Camera.main;
		GameObject road2 = GameObject.Find("road2");
		Vector3 viewPos = camera.WorldToViewportPoint(renderer.bounds.max);
		if(viewPos.y<0)//viewPos.y because it becomes y when converted to viewportPoint
			transform.position= new Vector3(road2.renderer.bounds.max.x + halflength, startpos.y, startpos.z);
	}
}
