using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public List<AudioClip> AudioClips;
    public AudioClip CurrentClip;

    private GameObject TitlePanel;
    private GameObject ControlsPanel;
    private GameObject LevelPanel;

    private AudioSource AudioSource;

    void Start()
    {
        TitlePanel = GameObject.Find("TitlePanel");
        ControlsPanel = GameObject.Find("ControlsPanel");
        LevelPanel = GameObject.Find("LevelPanel");

        AudioSource = GetComponent<AudioSource>();

        ControlsPanel.SetActive(false);
        LevelPanel.SetActive(false);
    }

    public void LoadScene(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void PlaySound()
    {
        CurrentClip = AudioClips[Random.Range(0, AudioClips.Count)];
        AudioSource.clip = CurrentClip;
        AudioSource.Play();
    }

    public void StartButton()
    {
        TitlePanel.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void ControlsButton()
    {
        TitlePanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void BackButton()
    {
        TitlePanel.SetActive(true);
        ControlsPanel.SetActive(false);
    }
}
