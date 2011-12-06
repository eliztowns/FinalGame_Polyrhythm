using UnityEngine;
using System.Collections;

public class particlescript : MonoBehaviour {
	private float speed_constant;
	
	void Start () {
		speed_constant=particleEmitter.worldVelocity.x;
	}
	
	// Update is called once per frame
	void Update () {
		//change intial speed of particles to be emmited
		float new_velx = speed_constant * GameObject.Find("GUI - Bar").GetComponent<GUIScript>().beats_per_second;
		particleEmitter.worldVelocity=new Vector3(new_velx,0,0);
		//change the speed of all the particles already in the scene
		Particle [] particles = particleEmitter.particles;
		for(int i=0; i<particles.Length; i++)
		{
			particles[i].velocity = new Vector3(new_velx,0,0);
		}
		particleEmitter.particles=particles;
	}
}
