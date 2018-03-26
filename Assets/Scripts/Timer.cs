using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

	public float timeLeft = 5f;
	public GameObject timeDisplay;
	public bool timeUp = false;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		timeDisplay.GetComponent<TextMesh>().text = "Time Left: " + timeLeft;
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
		{
			timeUp = true;
			timeDisplay.GetComponent<TextMesh>().text = "Time Left: 0";
		}
	}
}
