using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [Header("Points")]
    public int PointsNumber = 0;
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
    private GameObject GamePanel;
    private GameObject EndPanel;

    private GameObject ScoreTime;
    private GameObject ScorePoints;
    private GameObject ScoreConclusion;

    private GameObject RightButton;
    private GameObject MiddleButton;
    private GameObject LeftButton;

    private AudioSource AudioSource;

    private Countdown CountdownScript;
    private bool GameFinished = false;

    void Start()
    {
        Ball = GameObject.Find("Ball");

        StartPanel = GameObject.Find("StartPanel");
        GamePanel = GameObject.Find("GamePanel");
        EndPanel = GameObject.Find("EndPanel");

        ScoreTime = GameObject.Find("Text1Right");
        ScorePoints = GameObject.Find("Text2Right");
        ScoreConclusion = GameObject.Find("Text3Right");

        RightButton = GameObject.Find("RightButton");
        MiddleButton = GameObject.Find("MiddleButton");
        LeftButton = GameObject.Find("LeftButton");

        AudioSource = GetComponent<AudioSource>();
        CountdownScript = GameObject.FindObjectOfType<Countdown>();

        GamePanel.SetActive(false);
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartPanel.SetActive(false);
            GamePanel.SetActive(true);

            CountdownScript.StartTime();
        }
    }

    public void LoadScene(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void AddPoints(int PointsEarned)
    {
        PointsNumber += PointsEarned;
        PointsText.text = PointsNumber.ToString();

        AudioSource.clip = PointSound;
        AudioSource.Play();
    }

    public void EndGame()
    {
        if (GameFinished == false)
        {
            Destroy(Ball);

            GamePanel.SetActive(false);
            EndPanel.SetActive(true);

            CountdownScript.EndTime();
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
        ScoreTimeText.text = "00:00";

        AudioSource.clip = ScoreSound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        ScorePoints.SetActive(true);
        ScorePointsText.text = PointsNumber.ToString();

        AudioSource.clip = ScoreSound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = ConclusionSound;
        AudioSource.Play();

        yield return new WaitForSeconds(1.8f);

        if (PointsNumber > 4)
        {
            ScoreConclusion.SetActive(true);
            ScoreConclusionText.text = "Victory";

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

            RightButton.SetActive(true);
            MiddleButton.SetActive(true);

            AudioSource.clip = LoseSound;
            AudioSource.Play();
        }
    }
}
