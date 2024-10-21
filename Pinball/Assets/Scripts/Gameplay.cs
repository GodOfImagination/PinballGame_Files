using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [Header("Timer\n")]
    public float RemainingTime = 1.0f;
    public TMP_Text TimeText;

    [Header("Points")]
    public int PointsCount = 0;
    public int PointsNeeded = 0;
    public TMP_Text PointsNeededText;
    public TMP_Text PointsText;

    [Header("Score")]
    public TMP_Text ScoreTimeText;
    public TMP_Text ScorePointsText;
    public TMP_Text ScoreConclusionText;

    [Header("Sounds")]
    public AudioClip PointSound;

    [Space(10)]
    public AudioClip EndSound;
    public AudioClip ScoreSound;
    public AudioClip ConclusionSound;

    [Space(10)]
    public AudioClip WinSound;
    public AudioClip LoseSound;

    private GameObject Ball;

    private GameObject StartPanel;
    private GameObject EndPanel;

    private GameObject ScoreTime;
    private GameObject ScorePoints;
    private GameObject ScoreConclusion;

    private GameObject RightButton;
    private GameObject MiddleButton;
    private GameObject LeftButton;

    private AudioSource AudioSource;

    private Countdown CountdownScript;

    private bool TimerIsRunning = false;
    private bool CountdownStarted = false;
    private bool GameFinished = false;

    void Start()
    {
        Ball = GameObject.Find("Ball");

        StartPanel = GameObject.Find("StartPanel");
        EndPanel = GameObject.Find("EndPanel");

        ScoreTime = GameObject.Find("Text1Right");
        ScorePoints = GameObject.Find("Text2Right");
        ScoreConclusion = GameObject.Find("Text3Right");

        RightButton = GameObject.Find("RightButton");
        MiddleButton = GameObject.Find("MiddleButton");
        LeftButton = GameObject.Find("LeftButton");

        AudioSource = GetComponent<AudioSource>();

        CountdownScript = GameObject.FindObjectOfType<Countdown>();

        PointsNeededText.text = (PointsNeeded + 1).ToString();

        EndPanel.SetActive(false);

        ScoreTime.SetActive(false);
        ScorePoints.SetActive(false);
        ScoreConclusion.SetActive(false);

        RightButton.SetActive(false);
        MiddleButton.SetActive(false);
        LeftButton.SetActive(false);
    }

    void Update()
    {
        if (TimerIsRunning)
        {
            if (RemainingTime > 0)
            {
                RemainingTime -= Time.deltaTime;
                DisplayTime(RemainingTime, true);
            }
            else
            {
                RemainingTime = 0;
                TimerIsRunning = false;
                EndGame();
            }

            if (RemainingTime < 6 && CountdownStarted == false)
            {
                CountdownScript.StartTheCountdown();
                CountdownStarted = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && GameFinished == false)
        {
            StartPanel.SetActive(false);

            TimerIsRunning = true;
        }
    }

    public void LoadScene(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    private void DisplayTime(float TimeToDisplay, bool GameIsRunning)
    {
        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        if (GameIsRunning)
            TimeText.text = $"{minutes:00}:{seconds:00}";
        else
            ScoreTimeText.text = $"{minutes:00}:{seconds:00}";
    }

    public void AddPoints(int PointsEarned)
    {
        PointsCount += PointsEarned;
        PointsText.text = PointsCount.ToString();

        AudioSource.clip = PointSound;
        AudioSource.Play();
    }

    public void EndGame()
    {
        if (GameFinished == false)
        {
            Destroy(Ball);

            EndPanel.SetActive(true);

            CountdownScript.End();

            TimerIsRunning = false;
            GameFinished = true;

            StartCoroutine(Conclusion());
        }
    }

    private IEnumerator Conclusion()
    {
        AudioSource.clip = EndSound;
        AudioSource.Play();

        yield return new WaitForSeconds(2f);

        ScoreTime.SetActive(true);
        DisplayTime(RemainingTime, false);

        AudioSource.clip = ScoreSound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        ScorePoints.SetActive(true);
        ScorePointsText.text = PointsCount.ToString();

        AudioSource.clip = ScoreSound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = ConclusionSound;
        AudioSource.Play();

        yield return new WaitForSeconds(1.8f);

        if (PointsCount > PointsNeeded)
        {
            ScoreConclusion.SetActive(true);
            ScoreConclusionText.text = "Victory";
            ScoreConclusionText.color = Color.green;

            RightButton.SetActive(true);
            MiddleButton.SetActive(true);
            LeftButton.SetActive(true);

            AudioSource.clip = WinSound;
            AudioSource.Play();
        }
        else
        {
            ScoreConclusion.SetActive(true);
            ScoreConclusionText.text = "Failed";
            ScoreConclusionText.color = Color.red;

            RightButton.SetActive(true);
            MiddleButton.SetActive(true);

            AudioSource.clip = LoseSound;
            AudioSource.Play();
        }
    }
}
