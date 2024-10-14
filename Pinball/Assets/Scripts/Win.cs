using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private Gameplay GameplayScript;

    void Start()
    {
        GameplayScript = GameObject.FindObjectOfType<Gameplay>();
    }

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Ball")
		{
			GameplayScript.WinGame();
		}
	}
}
