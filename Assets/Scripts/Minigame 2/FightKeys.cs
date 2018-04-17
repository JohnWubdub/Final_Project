using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightKeys : MonoBehaviour //fighting mini game main script
{
	
	private KeyCode[] keyChain = new KeyCode[8];
	private int count = 0;
	public GameObject timer;
	
	// Use this for initialization
	void Start ()
	{

		string[] textLetters = new string[]{"W","A","S","D"};
		string textChain = null;
		
		KeyCode[] keyLetters = new KeyCode[]{KeyCode.W, KeyCode.A,KeyCode.S,KeyCode.D};

		for (int i = 0; i < 8; i++)
		{
			int num = Random.Range(0, 4);

			if (i == 7)
			{
				textChain += textLetters[num];
			}
			else
			{
				textChain += textLetters[num] + " + ";
			}
			
			keyChain[i] = keyLetters[num];
		}

		this.GetComponent<TextMesh>().text = textChain;
	}
	
	// 
	void Update ()
	{

		if (count < 8 && timer.GetComponent<Timer2>().timeUp == false)
		{
			if (Input.GetKeyUp(keyChain[count]))
			{
				count++;
			} 
			else if (Input.anyKey && !Input.GetKey(keyChain[count])) //wrong input
			{
				this.GetComponent<TextMesh>().text = "You Lose!";
				timer.GetComponent<Timer2>().subTime = false;
			}
		}
		else //winning
		{
			timer.GetComponent<Timer2>().subTime = false;
			this.GetComponent<TextMesh>().text = "You win!";
//			Placeholder for global win state boolean
		}
		
		if (timer.GetComponent<Timer2>().timeUp == true) //if the time runs out
		{
			Debug.Log("Fuck my dick");
			timer.GetComponent<Timer2>().subTime = false;
			this.GetComponent<TextMesh>().text = "You lose!";
		}
		
		Debug.Log(keyChain[0] + " + " + keyChain[1] + " + " + keyChain[2] + " + " + keyChain[3] + " + " + keyChain[4] + " + " + keyChain[5] + " + ");
		Debug.Log("Count = " + count);

		
		
	}

}
