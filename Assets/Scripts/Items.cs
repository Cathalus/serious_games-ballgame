using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Items : MonoBehaviour {

    public int Keys = 0;
    public int CollectedKeys = 0;
    public int CollectedCoins = 0;
    public int LevelTime = 125;
    public bool TimerStopped = false;
    public bool FinishedLevel = false;

    private Text _keyText;
    private Text _timerText;
    private Text _coinsText;
    private Text _scoreText;

    private int _time;
    private float acc;
    private GameObject _hud;
    private GameObject _finished;

    public void Awake()
    {
        _keyText = GameObject.FindGameObjectWithTag(Tags.KeysText).GetComponent<Text>();
        _timerText = GameObject.FindGameObjectWithTag(Tags.TimerText).GetComponent<Text>();
        _coinsText = GameObject.FindGameObjectWithTag(Tags.CoinsText).GetComponent<Text>();
        _scoreText = GameObject.FindGameObjectWithTag(Tags.ScoreText).GetComponent<Text>();
        _time = LevelTime;

        _hud = GameObject.FindGameObjectWithTag(Tags.HUD);
        _finished = GameObject.FindGameObjectWithTag(Tags.FinishedGame);
        _finished.SetActive(false);
    }

    public void Update()
    {
        _keyText.text = "Keys: " + CollectedKeys;
        _coinsText.text = "Coins: " + CollectedCoins;

        acc += Time.deltaTime;

        if(acc >= 1 && !TimerStopped)
        {
            acc = 0;
            _time--;
        }

        int minutes = Mathf.FloorToInt(_time / 60);
        int seconds = _time - minutes * 60;

        _timerText.text = (minutes < 10? "0"+minutes : ""+minutes) + ":" + (seconds < 10 ? "0"+seconds : ""+seconds);

        // TODO: Time runs out
        if(_time <= 0)
        {

        }

        if(FinishedLevel)
        {
            _hud.SetActive(false);
            _finished.SetActive(true);

            // TODO: Better calculation
            int score = _time + CollectedCoins * 5;
            _scoreText.text = "Score: " + score;
        }
    }

    public bool KeysCollected()
    {
        return CollectedKeys >= Keys;
    }

    public void AddTime(int time)
    {
        _time += time;
    }

}
