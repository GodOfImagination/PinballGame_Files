using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Gameplay GameplayScript;

    void Start()
    {
        GameplayScript = GameObject.FindObjectOfType<Gameplay>();
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball" || other.gameObject.name == "Ball(Clone)")
		{
			Destroy(other.gameObject);
			GameplayScript.CheckCount(false);
		}
	}
}
