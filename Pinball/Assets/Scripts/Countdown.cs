using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [Header("Time\n")]
    public float RemainingTime = 1.0f;
    public TMP_Text TimerText;

    private bool TimerIsRunning = false;
    private Gameplay GameplayScript;

    void Start()
    {
        GameplayScript = GameObject.FindObjectOfType<Gameplay>();
    }

    void Update()
    {
        if (TimerIsRunning)
        {
            if (RemainingTime > 0)
            {
                RemainingTime -= Time.deltaTime;
                DisplayTime(RemainingTime);
            }
            else
            {
                RemainingTime = 0;
                TimerIsRunning = false;
                GameplayScript.WinGame();
                Destroy(this.gameObject);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StartTime()
    {
        TimerIsRunning = true;
    }

    public void EndTime()
    {
        RemainingTime = 0;
        TimerIsRunning = false;
        Destroy(this.gameObject);
    }
}
