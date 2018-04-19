﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer4 : MonoBehaviour //timer 4
{

	private float timeLeft = 10f;
	public bool timeUp = false;
	public bool subTime = true;
	public GameObject sound; 

	
	void Update () 
	{
		GetComponent<TextMesh>().text = "Time Left: " + timeLeft.ToString("F");
		timing();
		
		if (timeLeft == 3)
		{
			sound.GetComponent<Sound4>().Hurry();
		}
		
		if (timeLeft == 2)
		{
			sound.GetComponent<Sound4>().Hurry();
		}
		
		if (timeLeft == 1)
		{
			sound.GetComponent<Sound4>().Hurry();
		}
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
