using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	public int PointsRewarded;

	private float BumperForce = 300;
	private float BumperFlash = 0.1f;
	private Light BumperLight;
	private Gameplay GameplayScript;

    void Start()
    {
		BumperLight = GetComponent<Light>();
		BumperLight.intensity = 0;
		GameplayScript = GameObject.FindObjectOfType<Gameplay>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball" || other.gameObject.name == "Ball(Clone)")
		{
			StartCoroutine(LightFlash());

			Vector3 Direction = transform.position - other.gameObject.transform.position;
			Rigidbody BallRigidbody = other.gameObject.GetComponent<Rigidbody>();
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
