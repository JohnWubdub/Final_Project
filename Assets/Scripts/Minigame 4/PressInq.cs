using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PressInq : MonoBehaviour 
{

	private KeyCode[] keyChain = new KeyCode[6];
	
	private KeyCode[] keyLetters = new KeyCode[]{KeyCode.A,KeyCode.D, KeyCode.Space}; 

	public bool left = false;
	public bool right = false;
	public bool friend = false;

	public GameObject leftMan;
	public GameObject rightMan;
	
	public GameObject rightFriend;
	public GameObject leftFriend;
	
	void Start () 
	{
		for (int i = 0; i < 7; i++)
		{
			int num = Random.Range(0, 2);
			
			keyChain[i] = keyLetters[num];
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		int i = 0;

		for (int k = 0; k < 7; k++)
		{
			Debug.Log(keyChain[k]);
		}
		
		if (keyChain[i] == keyLetters[0]) //if it's A (the left side)
		{
			left = true;
		}

		if (left == true) //activate the renderer
		{
			leftMan.GetComponent<Renderer>().enabled = true;
		}

		if (left == true && Input.GetKeyUp(KeyCode.A)) //checking to see if they are right
		{
			leftMan.GetComponent<Renderer>().enabled = false;
			i += 1;
			left = false;
		}
		else
		{
			Debug.Log("no 1");
		}
		
		
//_________________________________________________________________________________________________		
		
		if (keyChain[i] == keyLetters[1]) //if it's D (the right side)
		{
			right = true;
		}

		if (right == true) //activate the renderer
		{
			rightMan.GetComponent<Renderer>().enabled = true;
		}

		if (right == true && Input.GetKeyUp(KeyCode.D)) //checking to see if they are right
		{
			rightMan.GetComponent<Renderer>().enabled = false;
			i += 1;
			right = false;
		}
		else
		{
			Debug.Log("no 2");
		}
		
//_________________________________________________________________________________________________
		
		
		if (keyChain[i] == keyLetters[3]) //if it's Space (popokumo)
		{
			friend = true;
		}

		if (friend == true) //activate the renderer
		{
			int j = Random.Range(1, 2);
			
			if (j == 1)
			{
				rightFriend.GetComponent<Renderer>().enabled = true;
			}
			if (j == 2)
			{
				leftFriend.GetComponent<Renderer>().enabled = true;
			}
		}

		if (friend == true && Input.GetKeyUp(KeyCode.Space)) //checking to see if they are right
		{
			leftFriend.GetComponent<Renderer>().enabled = false;
			rightFriend.GetComponent<Renderer>().enabled = false;
			i += 1;
			friend = false;
		}
		else
		{
			Debug.Log("no daddy");
		}

	}
}
