using UnityEngine;
using System.Collections;

public class skyboxscript : MonoBehaviour {
	private int count;
	// Use this for initialization
	void Start () {
		count=0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(count==20)
		{
			RenderSettings.skybox = Resources.Load("materials/skybox2") as Material;
		}
		else if(count==40)
		{
			RenderSettings.skybox = Resources.Load("materials/skybox") as Material;
			count=0;
		}
		count++;
	
	}
}
