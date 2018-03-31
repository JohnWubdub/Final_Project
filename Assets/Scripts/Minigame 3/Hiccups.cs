using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiccups : MonoBehaviour
{

	public GameObject timer;

	public int hiccupNum;

	public float tinyTimer = .5f;
	
	void Start ()
	{
		hiccupNum = Random.RandomRange(80, 84);
	}
	

	void Update ()
	{
		this.GetComponent<TextMesh>().text = "Hiccups: " + hiccupNum;
		
		if (Input.GetKeyUp(KeyCode.Space) && timer.GetComponent<Timer3>().timeUp == false)
		{
			hiccupNum += 1;
		}

		if (hiccupNum == 99 && timer.GetComponent<Timer3>().timeUp == false)
		{
			tinyTimer -= Time.deltaTime;
			
		}
		
		if (tinyTimer < 0 && hiccupNum == 99 && timer.GetComponent<Timer3>().timeUp == false)
		{
			this.GetComponent<TextMesh>().text = "You did it!";
			timer.GetComponent<Timer3>().subTime = false;
		}

		if (hiccupNum > 99)
		{
			timer.GetComponent<Timer3>().subTime = false;
			this.GetComponent<TextMesh>().text = "You fucking failed!";
		}

		if (timer.GetComponent<Timer3>().timeUp == true)
		{
			this.GetComponent<TextMesh>().text = "You fucking failed!";
		}
	}
}