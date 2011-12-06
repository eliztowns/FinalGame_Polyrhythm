using UnityEngine;
using System.Collections;

public struct key_pair{
	public string name;
	public float time;
}

//MODIFIED SOUND CHART
//green - cymbal
//red - cymbal or tom-tom?
//yellow - snare
//blue - hi-hat

public class InputManager : MonoBehaviour {
	private static InputManager instance;
	public Queue keyQueue;
	public string test;
	public float num_input;
	
	//audio clips
	private AudioClip cymbal;
	private AudioClip kick;
	private AudioClip snare;
	private AudioClip hihat;
	private AudioClip tomtom;
	
	public static InputManager get{
		get{
			if(!instance)
				Debug.LogError("No InputManager in scene");
			return instance;
		}
	}
	
	private string[] keys = new string[]{"red", "yellow", "blue", 
		"green", "foot_pedal", "start", "back"};
	private AudioClip[] sounds;
	
	
	void Awake(){
		instance = this;
		keyQueue = new Queue();
		num_input = 0;
		
		sounds = new AudioClip[]{
			Resources.Load("best_cymbal") as AudioClip, //RED
			Resources.Load("best_snare") as AudioClip, //YELLOW
			Resources.Load("best_hihat") as AudioClip, //BLUE
			Resources.Load("best_cymbal") as AudioClip, //GREEN,
			Resources.Load("best_kick") as AudioClip //FOOT PEDAL
		};
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach (string key in keys){
			if(Input.GetButtonDown(key)){
				key_pair temp;
				temp.name = key;
				temp.time = Time.time;			
				keyQueue.Enqueue(temp);
				test = key;
				//play corresponding sounds
				if(i<5)
					audio.PlayOneShot(sounds[i]);
			}
			i++;
		}
		
		if(Input.GetButtonDown("blue") && Input.GetButtonDown("yellow"))
			num_input = Time.time;
	}
	
	public key_pair GetNextKey(){
		return (key_pair)keyQueue.Dequeue();
	}
	
	public bool HasKeys(){
		return keyQueue.Count > 0;
	}
}
