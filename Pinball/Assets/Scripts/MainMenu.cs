using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Screens\n")]
    public GameObject ScreenTitle;
    public GameObject ScreenLevels;
    public GameObject ScreenControls;

    public void LoadScene(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void ButtonStart()
    {
        ScreenTitle.SetActive(false);
        ScreenLevels.SetActive(true);
    }

    public void ButtonControls()
    {
        ScreenTitle.SetActive(false);
        ScreenControls.SetActive(true);
    }

    public void ButtonBack()
    {
        ScreenTitle.SetActive(true);
        ScreenControls.SetActive(false);
    }
}
