﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GirlRunning : MonoBehaviour
{

	public GameObject tallGirl;
	public GameObject shortGirl;
	public GameObject runText;

	private bool run;
	private GameObject currentGirl;
	private GameObject otherGirl;
	private float tallTimer;
	private float shortTimer;
	
	private KeyCode[] keyLetters = {KeyCode.W, KeyCode.A,KeyCode.S,KeyCode.D};
	private string[] textLetters = {"W","A","S","D"};
	private KeyCode firstKey;
	private KeyCode secondKey;
	private string firstLetter;
	private string secondletter;
	private int num1;
	private int num2;
	
	// Use this for initialization
	void Start ()
	{

		currentGirl = tallGirl;
		otherGirl = shortGirl;
		firstKey = KeyCode.A;
		secondKey = KeyCode.S;
		firstLetter = "A";
		secondletter = "S";

	}
	
	// Update is called once per frame
	void Update () {

		if ((run && Input.GetKeyUp(firstKey)) || (!run && Input.GetKeyUp(secondKey)))
		{
			currentGirl.transform.position += new Vector3(.5f,0,0);
			run = !run;
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (currentGirl == tallGirl)
			{
				currentGirl = shortGirl;
				otherGirl = tallGirl;
			}
			else
			{
				currentGirl = tallGirl;
				otherGirl = shortGirl;
			}

			num1 = Random.Range(0, 4);
			num2 = Random.Range(0, 4);
			while (num1 == num2)
			{
				num2 = Random.Range(0, 4);
			}

			firstKey = keyLetters[num1];
			secondKey = keyLetters[num2];
			firstLetter = textLetters[num1];
			secondletter = textLetters[num2];

			runText.GetComponent<TextMesh>().text = "Press " + firstLetter + " + " + secondletter + "!";
		}

		otherGirl.transform.position -= new Vector3(Time.deltaTime, 0, 0);
	}
}