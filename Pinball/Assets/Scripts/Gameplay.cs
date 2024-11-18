using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [Header("Screens\n")]
    public GameObject ScreenStart;
    public GameObject ScreenEnd;

    [Space(10)]

    public GameObject ScoreTime;
    public GameObject ScorePoints;
    public GameObject ScoreConclusion;

    [Space(10)]

    public GameObject ButtonsVictory;
    public GameObject ButtonsFailed;

    [Space(20)]

    [Header("Timer\n")]
    public float RemainingTime = 120;
    public TMP_Text TimeText;

    [Space(20)]

    [Header("Points\n")]
    public int Points = 0;
    public TMP_Text PointsText;
    public int PointsNeeded = 0;
    public TMP_Text PointsNeededText;

    [Space(20)]

    [Header("Score\n")]
    public TMP_Text ScoreTimeText;
    public TMP_Text ScorePointsText;
    public TMP_Text ScoreConclusionText;

    [Space(20)]

    [Header("Other\n")]
    public int BallCount = 1;

    [Space(10)]

    public GameObject Arrow;
    public float MoveLimit = 30;
    public float MoveSpeed = 10;
    private Vector3 StartPosition;

    [Space(20)]

    [Header("Sounds\n")]
    public AudioClip SoundStart;
    public AudioClip SoundEnd;

    [Space(10)]

    public AudioClip SoundDing;
    public AudioClip SoundScore;
    public AudioClip SoundConclusion;

    [Space(10)]

    public AudioClip SoundVictory;
    public AudioClip SoundFailed;

    private AudioSource AudioSource;
    private Countdown CountdownScript;

    private bool TimerIsRunning = false;
    private bool CountdownStarted = false;
    private bool GameStarted = false;
    private bool GameFinished = false;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        CountdownScript = GameObject.FindObjectOfType<Countdown>();

        PointsNeededText.text = (PointsNeeded + 1).ToString();

        StartPosition = Arrow.transform.position;
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
                ConcludeGame();
            }

            if (RemainingTime < 6 && CountdownStarted == false)
            {
                CountdownScript.CountdownStart();
                CountdownStarted = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && GameStarted == false)
        {
            GameStarted = true;

            ScreenStart.SetActive(false);

            TimerIsRunning = true;

            AudioSource.clip = SoundStart;
            AudioSource.Play();
        }

        if (GameFinished)
        {
            if (GameObject.Find("Ball"))
                Destroy(GameObject.Find("Ball"));

            if (GameObject.Find("Ball(Clone)"))
                Destroy(GameObject.Find("Ball(Clone)"));
        }

        Vector3 MoveVector = StartPosition;
        MoveVector.x += MoveLimit * Mathf.Sin(Time.time * MoveSpeed);
        Arrow.transform.position = MoveVector;
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
        Points += PointsEarned;
        PointsText.text = Points.ToString();

        AudioSource.clip = SoundDing;
        AudioSource.Play();
    }

    public void CheckCount(bool Add)
    {
        if (Add)
            BallCount = BallCount + 1;
        else
            BallCount = BallCount - 1;

        if (BallCount == 0)
        {
            ConcludeGame();
        }
    }

    public void ConcludeGame()
    {
        if (GameFinished == false)
        {
            ScreenEnd.SetActive(true);

            CountdownScript.CountdownEnd();

            TimerIsRunning = false;
            GameFinished = true;



            StartCoroutine(Conclusion());
        }
    }

    private IEnumerator Conclusion()
    {
        AudioSource.clip = SoundEnd;
        AudioSource.Play();

        yield return new WaitForSeconds(2f);

        ScoreTime.SetActive(true);
        DisplayTime(RemainingTime, false);

        AudioSource.clip = SoundScore;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        ScorePoints.SetActive(true);
        ScorePointsText.text = Points.ToString();

        AudioSource.clip = SoundScore;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        ScoreConclusion.SetActive(true);

        AudioSource.clip = SoundScore;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = SoundConclusion;
        AudioSource.Play();

        yield return new WaitForSeconds(1.8f);

        if (Points > PointsNeeded)
        {
            ScoreConclusionText.text = "Victory";
            ScoreConclusionText.color = Color.green;

            ButtonsVictory.SetActive(true);

            AudioSource.clip = SoundVictory;
            AudioSource.Play();
        }
        else
        {
            ScoreConclusionText.text = "Failed";
            ScoreConclusionText.color = Color.red;

            ButtonsFailed.SetActive(true);

            AudioSource.clip = SoundFailed;
            AudioSource.Play();
        }
    }
}
