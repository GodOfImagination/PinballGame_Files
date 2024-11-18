using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiball : MonoBehaviour
{
	[Header("Other\n")]
	public GameObject Ball;

	[Space(10)]

	public int TimesHit;
	public TMP_Text TimesHitText;

	[Space(20)]

	[Header("Sounds\n")]
	public AudioClip SoundDing;
	public AudioClip SoundReward;

	private Light BumperLight;
	private AudioSource AudioSource;
	private Gameplay GameplayScript;

	private bool IsReady = true;

    void Start()
    {
		BumperLight = GetComponent<Light>();
		BumperLight.intensity = 0;
		AudioSource = GetComponent<AudioSource>();
		GameplayScript = GameObject.FindObjectOfType<Gameplay>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball" || other.gameObject.name == "Ball(Clone)")
		{
			if (IsReady)
            {
				StartCoroutine(LightFlash());

				Vector3 Direction = transform.position - other.gameObject.transform.position;
				Rigidbody BallRigidbody = other.gameObject.GetComponent<Rigidbody>();
				BallRigidbody.AddForce(-Direction * 300);

				TimesHit = TimesHit - 1;
				TimesHitText.text = TimesHit.ToString();

				AudioSource.clip = SoundDing;
				AudioSource.Play();
			}

			if (TimesHit == 0 && IsReady)
            {
				IsReady = false;
				Vector3 SpawnPosition = new Vector3(15, 0.5f, 25);
				Instantiate(Ball, SpawnPosition, transform.rotation);
				StartCoroutine(Cooldown());
				GameplayScript.CheckCount(true);

				AudioSource.clip = SoundReward;
				AudioSource.Play();
			}
		}
	}

	private IEnumerator LightFlash()
    {
		BumperLight.intensity = 100;
		yield return new WaitForSeconds(0.1f);
		BumperLight.intensity = 0;
	}

	private IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(10);
		TimesHit = 5;
		TimesHitText.text = TimesHit.ToString();
		IsReady = true;
	}
}
