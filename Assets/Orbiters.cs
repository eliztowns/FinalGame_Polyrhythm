using UnityEngine;
using System.Collections;

public class Orbiters : MonoBehaviour {

    private float start_time;
    public float time_per_loop;
    public float top_radius;
    public float bottom_radius;
    public float height;
    public float yoffset;
	// Use this for initialization
	void Start () {
		float r1 = Random.value;
		float r2 = Random.value;
		time_per_loop = r1*2 + 3;
		top_radius =1;
		bottom_radius =1;
		height = .1F;
		yoffset=r2 +.7F;
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
		transform.localPosition = new Vector3(actual_radius * Mathf.Cos(radian_val), 
                                         height * Mathf.Sin(radian_val)+yoffset,
										actual_radius * Mathf.Sin(radian_val));
	}
}
