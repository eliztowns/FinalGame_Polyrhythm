using UnityEngine;
using System.Collections;

public class GameOptions : MonoBehaviour {

    public string difficulty = "medium";
    public int volume = 100;
    
	// Use this for initialization
	void Start () {
    
	}
	
    void Awake() {
        if(GameObject.FindGameObjectsWithTag("GameOptions").Length > 1){
            Destroy(transform.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}