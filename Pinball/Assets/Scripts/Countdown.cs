using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [Header("Sounds\n")]
    public AudioClip SoundCountdown1;
    public AudioClip SoundCountdown2;
    public AudioClip SoundCountdown3;
    public AudioClip SoundCountdown4;
    public AudioClip SoundCountdown5;

    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void CountdownStart()
    {
        StartCoroutine(CountdownBegin());
    }

    public void CountdownEnd()
    {
        Destroy(this.gameObject);
    }

    private IEnumerator CountdownBegin()
    {
        AudioSource.clip = SoundCountdown5;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = SoundCountdown4;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = SoundCountdown3;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = SoundCountdown2;
        AudioSource.Play();

        yield return new WaitForSeconds(1f);

        AudioSource.clip = SoundCountdown1;
        AudioSource.Play();
    }
}
