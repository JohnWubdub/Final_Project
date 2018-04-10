using System.Collections;
using System.Collections.Generic;
//using System.Management.Instrumentation;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.WSA;

public class MenuSelection : MonoBehaviour //main script for first minigame interaction
{
	public GameObject[] options;

	public GameObject[] text;

	public GameObject answer;
	public GameObject response;
	public GameObject timer;

	public bool first = false;
	public bool second = false;
	public bool wrong = false;

	public int current = 0;
	
	private bool check = false;
	private bool check2 = false;

	void Update () 
	{
		cursor();
		winLose();
		Debug.Log("current = " + current);
	}


	
	
	
	void cursor()
	{
		
		if (Input.GetKeyUp(KeyCode.W) == true && timer.GetComponent<Timer>().timeUp == false) //scrolling through the options (going up)
		{
			current -= 1;
			GetComponent<Sound>().Menu();
		}
		
		if (Input.GetKeyUp(KeyCode.S) == true && timer.GetComponent<Timer>().timeUp == false) //scrolling through the options (going down)
		{
			current += 1;
			GetComponent<Sound>().Menu();
		}
		
		options[current].GetComponent<Renderer>().enabled = true;

		

		if (((current + 1) < 6))
		{
			if (options[current + 1].GetComponent<Renderer>().enabled == true) //checks
			{
				options[current + 1].GetComponent<Renderer>().enabled = false;
			}
		}

		if ((current - 1) > -1)
		{
			if (options[current - 1].GetComponent<Renderer>().enabled == true) //and balances
			{
				options[current - 1].GetComponent<Renderer>().enabled = false;
			}
		}

		

	}



	void winLose()
	{
		if (current == 3 && Input.GetKeyUp(KeyCode.Space)) //if right the first time
		{
			first = true;
			this.GetComponent<Sound>().Select();
		}

		if (first == true)
		{
			text[0].GetComponent<TextMesh>().text = "No";
			text[1].GetComponent<TextMesh>().text = "Yes";
			text[2].GetComponent<TextMesh>().text = "Fuck you";
			text[3].GetComponent<TextMesh>().text = "I will kill you";
			text[4].GetComponent<TextMesh>().text = "Fuck off";
			text[5].GetComponent<TextMesh>().text = "I hate you";
		}

		if (current == 0 && Input.GetKeyUp(KeyCode.Space) && first == true) //if right again
		{
			second = true;
			this.GetComponent<Sound>().Select();
		}

		if (first == true && second == true) //winning
		{
			for (int i = 0; i < 6; i++)
			{
				options[i].GetComponent<Renderer>().enabled = false;
				text[i].GetComponent<TextMesh>().text = " ";
			}
			answer.GetComponent<TextMesh>().text = "No";
			timer.GetComponent<Timer>().subTime = false;
			response.GetComponent<TextMesh>().text = "   ";
		}
		
		
		if ((current != 3 && Input.GetKeyUp(KeyCode.Space) && first == false) ||
		    (current != 0 && Input.GetKeyDown(KeyCode.Space) && first == true) ||
		    (timer.GetComponent<Timer>().timeUp == true)) //failure
		{
			wrong = true;
		}

		if (wrong == true) //losing
		{
			for (int i = 0; i < 6; i++)
			{
				options[i].GetComponent<Renderer>().enabled = false;
				text[i].GetComponent<TextMesh>().text = " ";
			}
			timer.GetComponent<TextMesh>().text = "You fucking failed";
			timer.GetComponent<Timer>().subTime = false;

			response.GetComponent<TextMesh>().text = "I fucking hate you";
		}
	}
}
