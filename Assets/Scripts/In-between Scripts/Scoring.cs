using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour 
{

	
	void Update () 
	{
		if (Global.me.currentMinigame == 1)
		{
			GetComponent<TextMesh>().text = "" + Global.me.score1;
		}
		
		if (Global.me.currentMinigame == 2)
		{
			GetComponent<TextMesh>().text = "" + Global.me.score2;
		}
		
		if (Global.me.currentMinigame == 3)
		{
			GetComponent<TextMesh>().text = "" + Global.me.score3;
		}
		
		if (Global.me.currentMinigame == 4)
		{
			GetComponent<TextMesh>().text = "" + Global.me.score4;
		}
		
		if (Global.me.currentMinigame == 5)
		{
			GetComponent<TextMesh>().text = "" + Global.me.score5;
		}
	}
}
