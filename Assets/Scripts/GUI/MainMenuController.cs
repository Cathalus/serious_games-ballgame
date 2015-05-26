using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    [SerializeField]
    private Transform LevelButtonPanel = null; 
    [SerializeField]
    private Button LevelButtonPrefab = null;
    [SerializeField]
    private Button ExitGameButton = null;
	
    void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            
        }
    }

}
