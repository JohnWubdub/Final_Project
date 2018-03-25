using System.Collections;
using System.Collections.Generic;
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
	
	void Start () 
	{
		
	}
	

	void Update () 
	{
		if (Input.GetKey(KeyCode.W) == true)
		{
			option1.GetComponent<Renderer>().enabled = true;
			option2.GetComponent<Renderer>().enabled = false;
			Debug.Log("fuck me");
			yes = true;
		}
		
		if (Input.GetKey(KeyCode.S) == true)
		{
			option1.GetComponent<Renderer>().enabled = false;
			option2.GetComponent<Renderer>().enabled = true;
			Debug.Log("fuck you");
			no = true;
		}

		
		if (yes = true && Input.GetKeyUp(KeyCode.Space) && player.GetComponent<Timer>().timeUp == false && player.GetComponent<Timer>().timeLeft > 0)
		{
			option1.GetComponent<Renderer>().enabled = false;
			option2.GetComponent<Renderer>().enabled = false;
			text1.SetActive(false);
			text2.SetActive(false);
			answer.GetComponent<TextMesh>().text = "Yes.";
			response.GetComponent<TextMesh>().text = "Haha fuck you.";
			player.GetComponent<Timer>().timeDisplay.GetComponent<TextMesh>().text = "You failed!";
		}
		
		if (no = true && Input.GetKeyUp(KeyCode.Space) && player.GetComponent<Timer>().timeUp == false && player.GetComponent<Timer>().timeLeft > 0)
		{
			option1.GetComponent<Renderer>().enabled = false;
			option2.GetComponent<Renderer>().enabled = false;
			text1.SetActive(false);
			text2.SetActive(false);
			answer.GetComponent<TextMesh>().text = "No.";
			response.GetComponent<TextMesh>().text = " ";
			player.GetComponent<Timer>().timeDisplay.GetComponent<TextMesh>().text = "You did it!";
		}
	}
}
