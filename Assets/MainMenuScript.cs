using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public Texture2D startGameTexture;
    public Texture2D optionsTexture;
    public Texture2D creditsTexture;
    public Texture2D exitTexture;
    public Texture2D sparkleTexture;
    
    public float gap_from_top_ratio;
    public float outer_ratio_gap;
    public float inner_ratio_gap;
    
    private float gap;
    private float ratio;
    private float icon_dim;
    private float selection_dim;
    private float selection_mod;
    private int selection = 0;
    
	// Use this for initialization
	void Start () {
        gap = Screen.width / 25.0f;
        ratio = Screen.width / (5.0f * startGameTexture.width);
        icon_dim = ratio * startGameTexture.width;
        selection_dim = icon_dim * 1.5f;
        selection_mod = (selection_dim - icon_dim)/2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
            selection = Min(selection + 1, 3);
        if (Input.GetKeyDown("q"))
            selection = Max(selection - 1, 0);
        if (Input.GetKeyDown("space")){
            if(selection == 0)
                StartButton();
            else if(selection == 1)
                OptionsButton();
            else if(selection == 2)
                CreditsButton();
            else if(selection == 3)
                ExitButton();
        }
	}
    
    void OnGUI () {
    
        if (selection == 0 || selection == 3)
            GUI.DrawTexture(new Rect(gap * (selection + 1) + icon_dim * selection - selection_mod, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap - selection_mod, selection_dim, selection_dim), sparkleTexture);
        else
            GUI.DrawTexture(new Rect(gap * (selection + 1) + icon_dim * selection - selection_mod, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap - selection_mod, selection_dim, selection_dim), sparkleTexture);
        
        if (GUI.Button (new Rect (gap * 1 + icon_dim * 0, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), startGameTexture, ""))
            StartButton();
            
        if (GUI.Button (new Rect (gap * 2 + icon_dim * 1, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), optionsTexture, ""))
            OptionsButton();
            
        if (GUI.Button (new Rect (gap * 3 + icon_dim * 2, Screen.height * gap_from_top_ratio + icon_dim * inner_ratio_gap, icon_dim, icon_dim), creditsTexture, ""))
            CreditsButton();
            
        if (GUI.Button (new Rect (gap * 4 + icon_dim * 3, Screen.height * gap_from_top_ratio + icon_dim * outer_ratio_gap, icon_dim, icon_dim), exitTexture, ""))
            ExitButton();
    }
    
    void StartButton() {
        Application.LoadLevel("beth_scene_whaleshark"); 
    }
    
    void OptionsButton() {
        Application.LoadLevel("Options-Lummis-Mouse"); 
    }
    
    void CreditsButton() {
        int blarg;
    }
    
    void ExitButton() {
        Application.Quit();
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
