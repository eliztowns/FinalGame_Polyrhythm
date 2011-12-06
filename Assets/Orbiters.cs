using UnityEngine;
using System.Collections;

public class Orbiters : MonoBehaviour {

    private float start_time;
    public float time_per_loop=5;
    public float top_radius=10;
    public float bottom_radius=10;
    public float height=10;
    
	// Use this for initialization
	void Start () {
		time_per_loop = 5;
		top_radius = 10;
		bottom_radius = 10;
		height = 10;
        start_time = Time.time;
        float time_val = (start_time - Time.time) % time_per_loop;
        float radian_val = (2 * Mathf.PI) * (time_val / time_per_loop);
        transform.position = new Vector3(Mathf.Cos(radian_val), Mathf.Sin(radian_val), Mathf.Sin(radian_val));
	}
	
	// Update is called once per frame
	void Update () {
        float time_val = (start_time - Time.time) % time_per_loop;
        float radian_val = (2 * Mathf.PI) * (time_val / time_per_loop);
        float actual_radius = Mathf.Sin(radian_val) * (top_radius - bottom_radius) + bottom_radius;
		transform.position = new Vector3(actual_radius * Mathf.Cos(radian_val), 
                                         actual_radius * Mathf.Sin(radian_val), 
                                         height * Mathf.Sin(radian_val));
	}
}
