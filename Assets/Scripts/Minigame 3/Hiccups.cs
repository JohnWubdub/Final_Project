using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiccups : MonoBehaviour
{

	public GameObject timer;

	public bool space = false;
	public bool win = false;

	private int hiccupNum;

	private float tinyTimer = .2f;

	private float stanAddingTime = 2f;

	private float addTimer = 2f;

	private float waitTimer = 0;
	
	void Start ()
	{
		hiccupNum = Random.Range(0, 5);
		Global.me.currentMinigame = 2;
	}
	

	void Update ()
	{
		GetComponent<TextMesh>().text = "Hiccups: " + hiccupNum;
		
		if (Input.GetKey(KeyCode.Space) && timer.GetComponent<Timer3>().timeUp == false && win == false)
		{
//			addingHiccup();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			hiccupNum++;
		}
		
		if (Input.GetKey(KeyCode.Space))
		{
			waitTimer += .1f;
			if (waitTimer >= 2f)
			{
				hiccupNum++;
			}
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			waitTimer = 0;
		}

		if (hiccupNum == 99 && timer.GetComponent<Timer3>().timeUp == false) //almost win condition
		{
			tinyTimer -= Time.deltaTime;
			space = true;
		}
		else
		{
			space = false;
		}
		
		if (tinyTimer <= 0 && hiccupNum == 99 && timer.GetComponent<Timer3>().timeUp == false) //win condition
		{
			GetComponent<TextMesh>().text = "You win";
			timer.GetComponent<Timer3>().subTime = false;
			win = true;
			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}

		if (hiccupNum > 99 || timer.GetComponent<Timer3>().timeUp == true || hiccupNum < 99 &&
		    timer.GetComponent<Timer3>().timeUp == true)  //failure
		{
			timer.GetComponent<Timer3>().subTime = false;
			GetComponent<TextMesh>().text = "You were killed!";
			Global.me.lives -= 1;
		}

	}

	void addingHiccup()
	{
		if (addTimer <= stanAddingTime)
		{
			hiccupNum += 1;
			addTimer -= Time.deltaTime;
		}

		if (addTimer <= 0)
		{
			addTimer = stanAddingTime;
		}
		
	}
}