using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameplay : MonoBehaviour
{
    public int PointsNumber = 0;
    public TMP_Text PointsText;

    private GameObject TitlePanel;
    private GameObject StartPanel;
    private GameObject GamePanel;

    private GameObject WinPanel;
    private GameObject LosePanel;

    private Countdown CountdownScript;
    private bool GameStarted = false;
    private bool GameFinished = false;

    void Start()
    {
        TitlePanel = GameObject.Find("TitlePanel");
        StartPanel = GameObject.Find("StartPanel");
        GamePanel = GameObject.Find("GamePanel");

        WinPanel = GameObject.Find("WinPanel");
        LosePanel = GameObject.Find("LosePanel");

        CountdownScript = GameObject.FindObjectOfType<Countdown>();

        StartPanel.SetActive(false);
        GamePanel.SetActive(false);
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && GameStarted)
        {
            StartPanel.SetActive(false);
            GamePanel.SetActive(true);

            CountdownScript.StartTime();
            GameStarted = false;
        }
    }

    public void StartButton()
    {
        TitlePanel.SetActive(false);
        StartPanel.SetActive(true);

        GameStarted = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        if (GameFinished == false)
        {
            GamePanel.SetActive(false);
            WinPanel.SetActive(true);

            CountdownScript.EndTime();
            GameFinished = true;
        }
    }

    public void LoseGame()
    {
        if (GameFinished == false)
        {
            GamePanel.SetActive(false);
            LosePanel.SetActive(true);

            CountdownScript.EndTime();
            GameFinished = true;
        }
    }

    public void AddPoints(int PointsEarned)
    {
        PointsNumber += PointsEarned;
        PointsText.text = PointsNumber.ToString();
        if (PointsNumber > 4)
        {
            WinGame();
        }
    }
}
