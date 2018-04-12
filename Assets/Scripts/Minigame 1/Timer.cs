using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

	private float timeLeft = 5f;
	public bool timeUp = false;
	public bool subTime = true;

	
	void Update () 
	{
		GetComponent<TextMesh>().text = "Time Left: " + (int)timeLeft;
		timing();
	}

	void timing()
	{
		if (subTime == true)
		{
			timeLeft -= Time.deltaTime;
		}
		
		if (timeLeft < 0)
		{
			timeUp = true;
			GetComponent<TextMesh>().text = "Time Left: 0";
		}
	}
}
