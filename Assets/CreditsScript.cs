using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {

    public Texture2D creditscreen;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("foot_pedal"))
            Application.LoadLevel("ultimate_mainmenu_chucknorris");
	}
    
    void OnGUI () {
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), creditscreen);
    }
}
