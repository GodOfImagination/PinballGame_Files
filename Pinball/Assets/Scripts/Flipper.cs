using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
	public float restPosition = 0f;
	public float pressedPosition = 45f;
	public float flipperStrength = 10f;
	public float flipperDamper = 1f;
	public string ButtonName = "Flipper";

	private HingeJoint FlipperHinge;

	void Awake()
	{
		FlipperHinge = GetComponent<HingeJoint>();
		FlipperHinge.useSpring = true;
	}

	void Update()
	{
		JointSpring FlipperSpring = FlipperHinge.spring;
		JointLimits FlipperLimits = FlipperHinge.limits;

		FlipperSpring.spring = flipperStrength;
		FlipperSpring.damper = flipperDamper;

		if (Input.GetButton(ButtonName))
			FlipperSpring.targetPosition = pressedPosition;
		else
			FlipperSpring.targetPosition = restPosition;

		FlipperHinge.spring = FlipperSpring;
		FlipperHinge.useLimits = true;
		FlipperLimits.min = restPosition;
		FlipperLimits.max = pressedPosition;
	}
}
