using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer6 : MonoBehaviour 
{

	private float timeLeft = 7f;
	public bool timeUp = false;
	public bool subTime = true;
	public GameObject sound;
	
	void Update () 
	{
		GetComponent<TextMesh>().text = "Time Left: " + timeLeft.ToString("F");
		timing();
		
		if (timeLeft <= 3 && timeLeft >= 2.98)
		{
			sound.GetComponent<Sound6>().Hurry();
		}
		
		if (timeLeft <= 2 && timeLeft >= 1.98)
		{
			sound.GetComponent<Sound6>().Hurry();
		}
		
		if (timeLeft <= 1 && timeLeft >= 0.98)
		{
			sound.GetComponent<Sound6>().Hurry();
		}
		
//scoring__________________________________________________________________________
		
		if (subTime == false && timeLeft >= 3)
		{
			GameObject.Find("Score").GetComponent<Score>().game5 = 100;
		}

		if (subTime == false && timeLeft < 3 && timeLeft > 2)
		{
			GameObject.Find("Score").GetComponent<Score>().game5 = 75;
		}
		
		if (subTime == false && timeLeft < 2 && timeLeft > 1)
		{
			GameObject.Find("Score").GetComponent<Score>().game5 = 50;
		}
		
		if (subTime == false && timeLeft < 1 && timeLeft > 0)
		{
			GameObject.Find("Score").GetComponent<Score>().game5 = 25;
		}
		
		if (timeLeft < 0)
		{
			GameObject.Find("Score").GetComponent<Score>().game5 = 0;
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
