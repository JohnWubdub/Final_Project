using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenTimer : MonoBehaviour 
{
	
	private float timeLeft = 10f;
	public bool timeUp = false;
	
	void Update () 
	{
		timeLeft -= Time.deltaTime;
		
		if (timeLeft <= 0)
		{
			//change to next minigame
		}
	}

}

