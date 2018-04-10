using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class TallGirlMovement : MonoBehaviour
{
	public GameObject shortGirl;

	public GameObject timer;
	
	public bool active = true;

	private int end = 10;
	
	private bool a = false;
	private bool s = false;

	public int count = 0;

	public float moveT = 1.5f; //falling behind
	public float moveF = 3f; // falling behind
	
	private Vector3 inc = new Vector3(2f, 0, 0);

	private Vector3 fail = new Vector3(-7.76f, -2.45f, -0.05f);

	

	void Update () 
	{
		if(active == false)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				active = true;
				shortGirl.GetComponent<TallGirlMovement>().active = false;
			}
		}

		if (active == true && Input.GetKeyDown(KeyCode.A) && a == false)
		{
			Debug.Log("yes");
			a = true;
			s = false;
			aMovement();
		}
		
		if (active == true && Input.GetKeyDown(KeyCode.S) && s == false)
		{
			Debug.Log("yes");
			a = false;
			s = true;
			sMovement();
		}

		if (active == false)
		{
			laggingBehind();
		}

		if (this.transform.position == fail)
		{
			timer.GetComponent<Timer5>().subTime = false;
		}

		if (timer.GetComponent<Timer5>().timeUp = true)
		{
			timer.GetComponent<TextMesh>().text = "You were killed!";
		}
		
	}

	void aMovement()
	{
		if (a == true)
		{
			count += 1;
			transform.position = Vector3.Lerp(this.transform.position, (this.transform.position + inc), moveT); //lerping to new position
			Debug.Log("fuck me");
			a = false;
		}
	}

	void sMovement()
	{
		if (s == true)
		{
			count += 1;
			transform.position = Vector3.Lerp(this.transform.position, (this.transform.position + inc), moveT); //lerping to new position
			Debug.Log("fuck me");
			s = false;
		}
	}

	void laggingBehind()
	{
		Vector3.Lerp(this.transform.position, fail , moveF);
		Debug.Log("moving back");
	}
}
