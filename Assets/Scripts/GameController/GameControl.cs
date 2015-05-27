using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	void Update () {
	    
        // Press Start to go to main menu
        if(Input.GetButtonDown("Start"))
        {
            Application.LoadLevel(0);
            // Press Y to reset the current level
        }else if(Input.GetButtonDown("Reset"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

	}
}
