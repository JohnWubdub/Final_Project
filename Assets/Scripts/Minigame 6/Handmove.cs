using System.Collections;
using UnityEngine;
using UnityEngine.Collections;

public class Handmove : MonoBehaviour
{

	public GameObject timer; 
	
	public int pleasure = 0;

	public GameObject headText;

	public GameObject head;

	private float moveSpeed = .23f;

	private float maxExtend = 5.83f;

	private float maxRetract = 8.74f;

	
	void Update () 
	{
		if (Input.GetKey(KeyCode.S) && timer.GetComponent<Timer6>().timeUp == false)
		{
			transform.position += new Vector3(0f, -moveSpeed, 0f);
			if (transform.position.y <= maxExtend)
			{
				transform.position = new Vector3(transform.position.x, maxExtend, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.W) && timer.GetComponent<Timer6>().timeUp == false)
		{
			transform.position += new Vector3(0f, moveSpeed, 0f);
			if (transform.position.y >= maxRetract)
			{
				transform.position = new Vector3(transform.position.x, maxRetract, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.A) && timer.GetComponent<Timer6>().timeUp == false)
		{
			transform.position += new Vector3(-moveSpeed, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.D) && timer.GetComponent<Timer6>().timeUp == false)
		{
			transform.position += new Vector3(moveSpeed, 0f, 0f);
		}

		if (pleasure >= 10 && timer.GetComponent<Timer6>().timeUp == false)
		{
			timer.GetComponent<Timer6>().subTime = false;
			headText.GetComponent<TextMesh>().text = "OH YEAH!";
			//stop the head
		}

		if (pleasure < 10 && timer.GetComponent<Timer6>().timeUp == true)
		{
			timer.GetComponent<Timer6>().subTime = false;
			headText.GetComponent<TextMesh>().text = "FUCK YOU!";
		}
		
	}

	private void OnCollisionStay(Collision other)
	{
		pleasure += 1;
		Debug.Log("Fuck me");
		//changing the hand model to look like they are petting them
	}
}
