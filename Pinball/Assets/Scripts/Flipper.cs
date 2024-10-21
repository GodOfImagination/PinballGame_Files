using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
	public float RestPosition = 0f;
	public float PressedPosition = 45f;
	public float FlipperStrength = 10f;
	public float FlipperDamper = 1f;
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

		FlipperSpring.spring = FlipperStrength;
		FlipperSpring.damper = FlipperDamper;

		if (Input.GetButton(ButtonName))
			FlipperSpring.targetPosition = PressedPosition;
		else
			FlipperSpring.targetPosition = RestPosition;

		FlipperHinge.spring = FlipperSpring;
		FlipperHinge.useLimits = true;
		FlipperLimits.min = RestPosition;
		FlipperLimits.max = PressedPosition;
	}
}
