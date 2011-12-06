using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
    public Texture2D hardGameTexture;
    public Texture2D mediumGameTexture;
    public Texture2D easyGameTexture;
    public Texture2D backTexture;
    public Texture2D sparkleTexture;
    
    public float gap_from_top_ratio;
    public float outer_ratio_gap;
    public float inner_ratio_gap;
    
    private GameOptions gameOptions;
    
    private float gap;
    private float ratio;
    private float icon_dim;
    private float selection_dim;
    private float selection_mod;
    private int selection = 0;
    
	// Use this for initialization
	void Start () {
        gap = Screen.width / 25.0f;
        ratio = Screen.width / (5.0f * hardGameTexture.width);
        icon_dim = ratio * hardGameTexture.width;
        selection_dim = icon_dim * 1.5f;
        selection_mod = (selection_dim - icon_dim)/2.0f;
        GameObject temp_Thing = GameObject.Find("GameOptions");
        gameOptions = temp_Thing.GetComponent<GameOptions>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
            selection = Min(selection + 1, 3);
        if (Input.GetKeyDown("q"))
            selection = Max(selection - 1, 0);
        if (Input.GetKeyDown("space")){
            if(selection == 0)
                HardButton();
            else if(selection == 1)
                MediumButton();
            else if(selection == 2)
                EasyButton();
            else if(selection == 3)
                BackButton();
        }
	}
    
    void OnGUI () {
    
        if (selection == 0 || selection == 3)
            GUI.DrawTexture(new Rect(gap * (selection + 1) + icon_dim * selection - selection_mod, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap - selection_mod, selection_dim, selection_dim), sparkleTexture);
        else
            GUI.DrawTexture(new Rect(gap * (selection + 1) + icon_dim * selection - selection_mod, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap - selection_mod, selection_dim, selection_dim), sparkleTexture);
        
        if (GUI.Button (new Rect (gap * 1 + icon_dim * 0, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), hardGameTexture, ""))
            HardButton();
            
        if (GUI.Button (new Rect (gap * 2 + icon_dim * 1, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), mediumGameTexture, ""))
            MediumButton();
            
        if (GUI.Button (new Rect (gap * 3 + icon_dim * 2, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), easyGameTexture, ""))
            EasyButton();
            
        if (GUI.Button (new Rect (gap * 4 + icon_dim * 3, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), backTexture, ""))
            BackButton();
    }
    
    void HardButton() {
        gameOptions.difficulty = "hard";
    }
    
    void MediumButton() {
        gameOptions.difficulty = "medium";
    }
    
    void EasyButton() {
        gameOptions.difficulty = "easy";
    }
    
    void BackButton() {
        Application.LoadLevel("MainMenu-Lummis-Mouse"); 
    }
    
    int Min(int a, int b) {
        if(a > b)
            return b;
        else
            return a;
    }
    
    int Max(int a, int b) {
        if(a < b)
            return b;
        else
            return a;
    }
}
