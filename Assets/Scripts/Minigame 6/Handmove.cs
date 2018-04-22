using System.Collections;
using UnityEngine;
using UnityEngine.Collections;

public class Handmove : MonoBehaviour
{

	public GameObject timer; 
	
	public int pleasure = 0;

	private int win = 200;

	public GameObject headText;

	public GameObject head;

	private float moveSpeed = .24f;

	private float maxExtend = 4.09f;

	private float maxRetract = 8.74f;

	public bool end = false;


	private void Start()
	{
		Global.me.currentMinigame = 5;
	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.S) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(0f, -moveSpeed, 0f);
			if (transform.position.y <= maxExtend)
			{
				transform.position = new Vector3(transform.position.x, maxExtend, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.W) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(0f, moveSpeed, 0f);
			if (transform.position.y >= maxRetract)
			{
				transform.position = new Vector3(transform.position.x, maxRetract, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.A) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(-moveSpeed, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.D) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(moveSpeed, 0f, 0f);
		}

		if (pleasure >= win && timer.GetComponent<Timer6>().timeUp == false) //winning
		{
			timer.GetComponent<Timer6>().subTime = false;
			headText.GetComponent<TextMesh>().text = "OH YEAH!";
			end = true;
		}

		if (pleasure < win && timer.GetComponent<Timer6>().timeUp == true) //fail
		{
			timer.GetComponent<Timer6>().subTime = false;
			headText.GetComponent<TextMesh>().text = "FUCK YOU!";
			Global.me.lives -= 1;
			end = true;
		}
		
	}

	private void OnCollisionStay(Collision other)
	{
		pleasure += 1;
		Debug.Log("Fuck me");
		//changing the hand model to look like they are petting them
	}
}
