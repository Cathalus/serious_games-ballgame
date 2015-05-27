using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour {

    private Button _btn;

    void Awake()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(() => { ButtonClicked(); });
    }

    void ButtonClicked()
    {
        Application.Quit();
    }
}
