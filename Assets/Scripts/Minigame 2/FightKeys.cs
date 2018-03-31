using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class FightKeys : MonoBehaviour //fighting mini game main script
{
	
	private KeyCode[] keyChain = new KeyCode[4];
	private int count = 0;
	public GameObject timer;
	
	// Use this for initialization
	void Start ()
	{

		string[] textLetters = new string[]{"W","A","S","D"};
		string textChain = null;
		
		KeyCode[] keyLetters = new KeyCode[]{KeyCode.W, KeyCode.A,KeyCode.S,KeyCode.D};

		for (int i = 0; i < 4; i++)
		{
			int num = Random.Range(0, 4);

			textChain += textLetters[num];
			keyChain[i] = keyLetters[num];
		}

		this.GetComponent<TextMesh>().text = textChain;
	}
	
	// 
	void Update ()
	{

		if (count < 4 && timer.GetComponent<Timer2>().timeUp == false)
		{
			if (Input.GetKeyUp(keyChain[count]))
			{
				count++;
			} 
			else if (Input.anyKey && !Input.GetKey(keyChain[count]) || timer.GetComponent<Timer2>().timeUp == true)
			{
				this.GetComponent<TextMesh>().text = "You Lose!";
			}
		}
		else
		{
			this.GetComponent<TextMesh>().text = "You Win!";
			timer.GetComponent<Timer2>().subTime = false;
		}
		
		Debug.Log(keyChain[0] + "" + keyChain[1] + "" + keyChain[2] + "" + keyChain[3]);
		Debug.Log("Count = " + count);

	}

}
