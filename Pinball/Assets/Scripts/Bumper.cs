using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	public int PointsRewarded;

	public float BumperForce = 300f;
	public float BumperFlash = 0.1f;

	private Light BumperLight;

	private GameObject Ball;
	private Rigidbody BallRigidbody;

	private Gameplay GameplayScript;

    void Start()
    {
		BumperLight = GetComponent<Light>();

		Ball = GameObject.Find("Ball");
		BallRigidbody = Ball.GetComponent<Rigidbody>();

		GameplayScript = GameObject.FindObjectOfType<Gameplay>();

		BumperLight.intensity = 0;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball")
		{
			StartCoroutine(LightFlash());

			Vector3 Direction = transform.position - Ball.transform.position;
			BallRigidbody.AddForce(-Direction * BumperForce);

			GameplayScript.AddPoints(PointsRewarded);
		}
	}

	private IEnumerator LightFlash()
    {
		BumperLight.intensity = 100;
		yield return new WaitForSeconds(BumperFlash);
		BumperLight.intensity = 0;
	}		
}
