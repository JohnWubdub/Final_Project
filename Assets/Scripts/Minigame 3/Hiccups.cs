﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiccups : MonoBehaviour
{

	public GameObject timer;

	public bool space = false;
	public bool win = false;

	public int hiccupNum;

	public float tinyTimer = .5f;

	private float stanAddingTime = 2f;

	private float addTimer = 2f;
	
	void Start ()
	{
		hiccupNum = Random.Range(70, 75);
	}
	

	void Update ()
	{
		GetComponent<TextMesh>().text = "Hiccups: " + hiccupNum;
		
		if (timer.GetComponent<Timer3>().timeUp == false && space == false && win == false)
		{
			addingHiccup();
		}

		if (Input.GetKey(KeyCode.Space) && hiccupNum <= 99 && timer.GetComponent<Timer3>().timeUp == false )
		{
			tinyTimer -= Time.deltaTime;
			space = true;
		}
		else
		{
			space = false;
		}
		
		if (tinyTimer < 0 && hiccupNum <= 99 && timer.GetComponent<Timer3>().timeUp == false)
		{
			GetComponent<TextMesh>().text = "You win";
			timer.GetComponent<Timer3>().subTime = false;
			win = true;
//			Placeholder for global win state boolean
		}

		if (hiccupNum > 99)
		{
			timer.GetComponent<Timer3>().subTime = false;
			this.GetComponent<TextMesh>().text = "You were killed!";
		}

		if (timer.GetComponent<Timer3>().timeUp == true)
		{
			this.GetComponent<TextMesh>().text = "Done";
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