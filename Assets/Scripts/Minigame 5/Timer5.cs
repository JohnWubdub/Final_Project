﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer5 : MonoBehaviour 
{

	private float timeLeft = 8f;
	public bool timeUp = false;
	public bool subTime = true;
	public GameObject sound; 
	
	void Update () 
	{
		GetComponent<TextMesh>().text = "Time Left: " + timeLeft.ToString("F");
		timing();
		
		if (timeLeft <= 3 && timeLeft >= 2.98)
		{
			sound.GetComponent<Sound5>().Hurry();
		}
		
		if (timeLeft <= 2 && timeLeft >= 1.98)
		{
			sound.GetComponent<Sound5>().Hurry();
		}
		
		if (timeLeft <= 1 && timeLeft >= 0.98)
		{
			sound.GetComponent<Sound5>().Hurry();
		}

//scoring__________________________________________________________________________
/*		
		if (subTime == false && timeLeft >= 3)
		{
			Global.me.score1 = 100;
		}

		if (subTime == false && timeLeft < 3 && timeLeft > 2)
		{
			Global.me.score1 = 75;
		}
		
		if (subTime == false && timeLeft < 2 && timeLeft > 1)
		{
			Global.me.score1 = 50;
		}
		
		if (subTime == false && timeLeft < 1 && timeLeft > 0)
		{
			Global.me.score1 = 25;
		}
		
		if (timeLeft < 0)
		{
			Global.me.score1 = 0;
		}
*/	}

	void timing()
	{
		if (subTime == true)
		{
			timeLeft -= Time.deltaTime;
		}
		
		if (timeLeft <= 0)
		{
			timeUp = true;
			GetComponent<TextMesh>().text = "Time Left: 0";
		}
	}
}
