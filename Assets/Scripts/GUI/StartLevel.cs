using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour {

    public int Level = -1;

    private Button _btn;

    void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => { ButtonClicked(); });
    }
    
    void ButtonClicked()
    {
        if(Level != -1)
        {
            Application.LoadLevel(Level);
        }
    }
	
}
