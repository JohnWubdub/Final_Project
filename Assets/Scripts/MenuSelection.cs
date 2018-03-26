using System.Collections;
using System.Collections.Generic;
//using System.Management.Instrumentation;
using UnityEngine;
using UnityEngine.Networking;

public class MenuSelection : MonoBehaviour
{


	public GameObject option1;
	public GameObject option2;
	public GameObject text1;
	public GameObject text2;

	public GameObject answer;
	public GameObject response;

	public GameObject player;

	public bool yes = false;
	public bool no = false;
	
	private float timeAdd = 3f;
	private bool swapped = false;
	
	void Start () 
	{
		
	}
	

	void Update () 
	{
		
		if (Input.GetKey(KeyCode.W) == true && player.GetComponent<Timer>().timeUp == false)
		{
			option1.GetComponent<Renderer>().enabled = true;
			option2.GetComponent<Renderer>().enabled = false;
//			Debug.Log("fuck me");
			if (swapped == false)
			{
				yes = true;
				no = false;
			}
			else
			{
				yes = false;
				no = true;
			}
		}
		
		if (Input.GetKey(KeyCode.S) == true && player.GetComponent<Timer>().timeUp == false)
		{
			option1.GetComponent<Renderer>().enabled = false;
			option2.GetComponent<Renderer>().enabled = true;
//			Debug.Log("fuck you");
			if (swapped == false)
			{
				yes = false;
				no = true;
			}
			else
			{
				yes = true;
				no = false;
			}
		}

		
		if (yes == true && Input.GetKeyUp(KeyCode.Space) && player.GetComponent<Timer>().timeUp == false && player.GetComponent<Timer>().timeLeft > 0)
		{
			option1.GetComponent<Renderer>().enabled = false;
			option2.GetComponent<Renderer>().enabled = false;
			text1.SetActive(false);
			text2.SetActive(false);
			answer.GetComponent<TextMesh>().text = "Yes.";
			response.GetComponent<TextMesh>().text = "Haha fuck you.";
			player.GetComponent<Timer>().timeLeft = 0;
			player.GetComponent<Timer>().timeDisplay.GetComponent<TextMesh>().text = "You failed!";
		}
		
		if (no == true && Input.GetKeyUp(KeyCode.Space) && player.GetComponent<Timer>().timeUp == false && player.GetComponent<Timer>().timeLeft > 0)
		{
			float red = Random.Range(0, 1f);
			float green = Random.Range(0, 1f);
			float blue = Random.Range(0, 1f);
			int changeOptions = Random.Range(0, 2);
			
//			option1.GetComponent<Renderer>().enabled = false;
//			option2.GetComponent<Renderer>().enabled = false;
//			text1.SetActive(false);
//			text2.SetActive(false);
			answer.GetComponent<TextMesh>().text = "No.";
			answer.GetComponent<TextMesh>().color = new Color(red, green, blue);
			response.GetComponent<TextMesh>().text = "Please?";
			response.GetComponent<TextMesh>().characterSize += .01f;
			player.GetComponent<Timer>().timeDisplay.GetComponent<TextMesh>().text = "You did it!";
			player.GetComponent<Timer>().timeLeft += timeAdd;
			if (timeAdd > .5f)
			{
				timeAdd -= .5f;
			}

			if (changeOptions == 0)
			{
				text1.GetComponent<TextMesh>().text = "Yes";
				text2.GetComponent<TextMesh>().text = "No";
				swapped = false;
			}
			else
			{
				text1.GetComponent<TextMesh>().text = "No";
				text2.GetComponent<TextMesh>().text = "Yes";
				swapped = true;
			}
			
			option1.GetComponent<Renderer>().enabled = true;
			option2.GetComponent<Renderer>().enabled = true;
			yes = false;
			no = false;
		}
	}
}
