using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
	private GameObject GameObject;

	void Start()
	{
		GameObject = GameObject.Find("Ramp");
		GameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Ball")
		{
			StartCoroutine(RampEnabled());
		}
	}

	private IEnumerator RampEnabled()
	{
		yield return new WaitForSeconds(1f);
		GameObject.SetActive(true);
	}
}
