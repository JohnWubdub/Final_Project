using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer3 : MonoBehaviour //timer 3
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
			sound.GetComponent<Sound3>().Hurry();
		}
		
		if (timeLeft <= 2 && timeLeft >= 1.98)
		{
			sound.GetComponent<Sound3>().Hurry();
		}
		
		if (timeLeft <= 1 && timeLeft >= 0.98)
		{
			sound.GetComponent<Sound3>().Hurry();
		}
		
//scoring__________________________________________________________________________
		
		if (subTime == false && timeLeft >= 2)
		{
			Global.me.score2 = 100;
			GameObject.Find("Score").GetComponent<Score>().game2 = 100;
		}

		if (subTime == false && timeLeft < 2 && timeLeft > 1.5)
		{
			Global.me.score2 = 75;
			GameObject.Find("Score").GetComponent<Score>().game2 = 75;
		}
		
		if (subTime == false && timeLeft < 1.5 && timeLeft > .5)
		{
			Global.me.score2 = 50;
			GameObject.Find("Score").GetComponent<Score>().game2 = 50;
		}
		
		if (subTime == false && timeLeft < .5 && timeLeft > 0)
		{
			Global.me.score2 = 25;
			GameObject.Find("Score").GetComponent<Score>().game2 = 25;
		}
		
		if (timeLeft < 0)
		{
			Global.me.score2 = 0;
			GameObject.Find("Score").GetComponent<Score>().game2 = 0;
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
