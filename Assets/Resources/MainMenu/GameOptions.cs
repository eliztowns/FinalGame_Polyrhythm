using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class GameOptions : MonoBehaviour {

    public string difficulty = "medium";
    private string old_diff = "nope";
    public int volume = 100;
    
	public List<string> red_combo = new List<string>();
	public List<string> blue_combo = new List<string>();
	public List<string> yellow_combo = new List<string>();
    
    public TextAsset comboListFile;
    
	void Start () {
    
	}
	
    void Awake() {
        if(GameObject.FindGameObjectsWithTag("GameOptions").Length > 1){
            Destroy(transform.gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        comboListFile = Resources.Load("combos") as TextAsset; 
        if(difficulty != old_diff){
            ParseCombos();
            old_diff = difficulty;
        }	
    }
    
	// Update is called once per frame
	void Update () {
        if(difficulty != old_diff){
            ParseCombos();
            old_diff = difficulty;
        }	
	}
    
    void ParseCombos() {
        List<string> theText = new List<string>();
        MemoryStream stream = new MemoryStream(comboListFile.bytes);
        StreamReader sr = new StreamReader(stream);
        red_combo = new List<string>();
        blue_combo = new List<string>();
        yellow_combo = new List<string>();
        while (!sr.EndOfStream)
            theText.Add(sr.ReadLine());
            
        for (int i = 0; i < theText.Count; i++) {
            if(theText[i] == difficulty){
                string combo_piece = theText[i+1].Substring(7, theText[i+1].Length - 7);
                foreach (char c in combo_piece)
                    red_combo.Add(getString(c));
                combo_piece = theText[i+2].Substring(7, theText[i+2].Length - 7);
                foreach (char c in combo_piece)
                    yellow_combo.Add(getString(c));
                combo_piece = theText[i+3].Substring(7, theText[i+3].Length - 7);
                foreach (char c in combo_piece)
                    blue_combo.Add(getString(c));
                break;
            }
        } 
    }
    
    string getString(char c) {
        if(c == 'y')
            return "yellow";
        else if(c == 'b')
            return "blue";
        else if(c == 'c')
            return "combo";
        
        return "shit";
    }
}