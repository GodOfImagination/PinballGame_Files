using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	public int PointsRewarded;
	public float BumperForce = 0f;

	private GameObject Ball;
	private Rigidbody BallRigidbody;

	private Gameplay GameplayScript;

    void Start()
    {
		Ball = GameObject.Find("Ball");
		BallRigidbody = Ball.GetComponent<Rigidbody>();

		GameplayScript = GameObject.FindObjectOfType<Gameplay>();
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball")
		{
			GameplayScript.AddPoints(PointsRewarded);

			Vector3 Direction = transform.position - Ball.transform.position;
			BallRigidbody.AddForce(-Direction * BumperForce);
		}
	}
}
