using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Controls the in-game HUD
/// </summary>
public class HUDController : MonoBehaviour {

    /// <summary>
    /// Text that is displayed on the Keys Counter
    /// </summary>
    public string KeysText = "Keys: ";
    /// <summary>
    /// Text that is display on the Coins Counter
    /// </summary>
    public string CoinsText = "Coins: ";


    /// <summary>
    /// Reference to the CollectableItems script
    /// </summary>
    private CollectableItems _collectableItems;
    /// <summary>
    /// Reference to the LevelController
    /// </summary>
    private LevelController _levelController;

    /// <summary>
    /// Reference to the key counter text
    /// </summary>
    private Text _keyText;
    /// <summary>
    /// Reference to the timer text
    /// </summary>
    private Text _timerText;
    /// <summary>
    /// Reference to the coin counter text
    /// </summary>
    private Text _coinsText;
    /// <summary>
    /// Reference to the final score text
    /// </summary>
    private Text _scoreText;
    
    /// <summary>
    /// Reference to the HUD GameObject
    /// </summary>
    private GameObject _hud;
    /// <summary>
    /// Reference to the "Level Finished"-Screen Gameobject
    /// </summary>
    private GameObject _finished;

	void Awake () {
        _collectableItems = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<CollectableItems>();
        _levelController = GameObject.FindGameObjectWithTag(Tags.GameController).GetComponent<LevelController>();
        
        _keyText = GameObject.FindGameObjectWithTag(Tags.KeysText).GetComponent<Text>();
        _timerText = GameObject.FindGameObjectWithTag(Tags.TimerText).GetComponent<Text>();
        _coinsText = GameObject.FindGameObjectWithTag(Tags.CoinsText).GetComponent<Text>();
        _scoreText = GameObject.FindGameObjectWithTag(Tags.ScoreText).GetComponent<Text>();

        _hud = GameObject.FindGameObjectWithTag(Tags.HUD);
        _finished = GameObject.FindGameObjectWithTag(Tags.FinishedGame);
        _finished.SetActive(false);
	}
	
	void Update () {
        // Update Text to display the current status
        _keyText.text = KeysText + _collectableItems.CollectedKeys;
        _coinsText.text = CoinsText + _collectableItems.CollectedCoins;
        _timerText.text = (_levelController.Minutes < 10 ? "0" + _levelController.Minutes : "" + _levelController.Minutes) + ":" + (_levelController.Seconds < 10 ? "0" + _levelController.Seconds : "" + _levelController.Seconds);

        // Show "Level Finished" Screen when the level is finished
        if(_levelController.FinishedLevel)
        {
            _hud.SetActive(false);
            _finished.SetActive(true);

            // TODO: Better calculation
            int score = _levelController.Minutes*60+_levelController.Seconds + _collectableItems.CollectedCoins * 5;
            _scoreText.text = "Score: " + score;
        }
	}
}
