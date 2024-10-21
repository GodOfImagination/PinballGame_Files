using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip Second1Sound;
    public AudioClip Second2Sound;
    public AudioClip Second3Sound;
    public AudioClip Second4Sound;
    public AudioClip Second5Sound;

    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void StartTheCountdown()
    {
        StartCoroutine(BeginCountdown());
    }

    public void End()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator BeginCountdown()
    {
        AudioSource.clip = Second5Sound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = Second4Sound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = Second3Sound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = Second2Sound;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = Second1Sound;
        AudioSource.Play();
    }
}
