using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ShortGirlMovement : MonoBehaviour
{

	public bool active = false;

	public GameObject timer;

	public GameObject tallGirl;

	private int end = 10;

	private bool w = false;
	private bool d = false;

	public int count = 0;

	public float moveT = 1.5f; //falling behind
	public float moveF = 3f; // falling behind
	
	private Vector3 inc = new Vector3(2f, 0, 0);

	private Vector3 fail = new Vector3(-7.76f, -2.45f, -0.05f);
	
	void Start () 
	{
		
	}
	
	
	void Update () //I want this to check if the current object is active and it is not then they will be able to press the space bar which activates it
	{
		if(active == false)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				active = true;
				tallGirl.GetComponent<TallGirlMovement>().active = false;
			}
		}

		if (active == true && Input.GetKeyDown(KeyCode.W) && w == false)
		{
			Debug.Log("yes");
			w = true;
			d = false;
			wMovement();
		}

		if (active == true && Input.GetKeyDown(KeyCode.D) && d == false)
		{
			Debug.Log("yes");
			w = false;
			d = true;
			dMovement();
		}

		if (active == false)
		{
			laggingBehind();
		}

		if (transform.position == fail)
		{
			timer.GetComponent<Timer5>().subTime = false;
		}
		
		if (timer.GetComponent<Timer5>().timeUp == true)
		{
			timer.GetComponent<TextMesh>().text = "You were killed!";
		}

		if (count >= end && timer.GetComponent<Timer5>().timeUp == false && tallGirl.GetComponent<TallGirlMovement>().count >= end)
		{
			timer.GetComponent<TextMesh>().text = "You did it!";
		}
	}
	
	void wMovement()
	{
		if (w == true)
		{
			count += 1;
			transform.position = Vector3.Lerp(this.transform.position, (this.transform.position + inc), moveT); //lerping to new position
			Debug.Log("fuck me");
			w = false;
		}
	}

	void dMovement()
	{
		if (d == true);
		{
			count += 1;
			Vector3.Lerp(this.transform.position, (this.transform.position + inc), moveT); //lerping to new position
			d = false;
		}
	}

	void laggingBehind()
	{
		Vector3.Lerp(this.transform.position, fail , moveF);
		Debug.Log("moving back");
	}
}
