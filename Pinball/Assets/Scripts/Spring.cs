using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
	public float MoveDistance = 0;
	public float MoveSpeed = 1;
	public float LaunchPower = 2000;
	public string ButtonName = "Pull";

	private float MoveCount = 0;
	private bool IsReady = false;
	private bool Launch = false;
	private GameObject Ball;
	private Rigidbody BallRigidbody;

	void Start()
    {
		Ball = GameObject.Find("Ball");
		BallRigidbody = Ball.GetComponent<Rigidbody>();
	}

    void Update()
	{
		if (Input.GetButton(ButtonName)) // As the button is held down, slowly move the piece.
		{
			if (MoveCount < MoveDistance)
			{
				transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
				MoveCount += MoveSpeed * Time.deltaTime;
				Launch = true;
			}
		}
		else if (MoveCount > 0)
		{
			if (Launch && IsReady) // Shoot the ball!
			{
				Ball.transform.TransformDirection(Vector3.forward * 10);
				BallRigidbody.AddForce(0, 0, MoveCount * LaunchPower);
				Launch = false;
				IsReady = false;
			}
			// Once we have reached the starting position fire off!
			transform.Translate(0, 0, 20 * Time.deltaTime);
			MoveCount -= 20 * Time.deltaTime;
		}
		if (MoveCount <= 0) // Just ensure we don't go past the end.
		{
			Launch = false;
			MoveCount = 0;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball")
		{
			IsReady = true;
		}
	}
}