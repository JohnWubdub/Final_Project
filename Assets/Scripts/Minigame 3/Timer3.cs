using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer3 : MonoBehaviour 
{

	public float timeLeft = 10f;
	public GameObject timeDisplay;
	public bool timeUp = false;
	public bool subTime = true;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		timeDisplay.GetComponent<TextMesh>().text = "Time Left: " + timeLeft;
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
			this.GetComponent<TextMesh>().text = "Time Left: 0";
		}
	}
}
