using UnityEngine;
using System.Collections;

/// <summary>
/// Controls the time and flow oth the level
/// </summary>
public class LevelController : MonoBehaviour {
    
    /// <summary>
    /// Time that is available to the player to finish the level
    /// </summary>
    public int LevelTime = 125;
    /// <summary>
    /// Remaining minutes
    /// </summary>
    public int Minutes { get { return _minutes; } }
    /// <summary>
    /// Remaining seconds
    /// </summary>
    public int Seconds { get { return _seconds; } }

    /// <summary>
    /// Defines if the timer is stopped
    /// </summary>
    public bool TimerStopped = false;
    /// <summary>
    /// Defines if the level is finished
    /// </summary>
    public bool FinishedLevel = false;
    /// <summary>
    /// Defines what the next level is
    /// </summary>
    public int NextLevel = -1;

    private int _seconds;
    private int _minutes;
    private int _time;
    private float _acc;

	void Awake () {
        _time = LevelTime;
	}

	void Update () {
        // Reset level when the time has run out
        if (_time <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        // Update Timer
        _acc += Time.deltaTime;
        if(_acc >= 1 && !TimerStopped)
        {
            _acc = 0;
            _time--;
            _minutes = Mathf.FloorToInt(_time / 60);
            _seconds = _time - _minutes * 60;
        }
	}

    /// <summary>
    /// Allows to add a certain amount of time to the clock
    /// </summary>
    /// <param name="time">Amount of time that is going to be added</param>
    public void AddTime(int time)
    {
        _time += time;
    }
}
