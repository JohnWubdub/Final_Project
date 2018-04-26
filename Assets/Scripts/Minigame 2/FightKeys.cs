using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightKeys : MonoBehaviour //fighting mini game main script
{
	
	private KeyCode[] keyChain = new KeyCode[8];
	private int count = 0;
	public GameObject timer;
	
	char[] fightChars = new char[8];
	
	// Use this for initialization
	void Start ()
	{

		Global.me.currentMinigame = 1;

		char[] textLetters = {'W','A','S','D'};
		string textChain = null;
		
		KeyCode[] keyLetters = new KeyCode[]{KeyCode.W, KeyCode.A,KeyCode.S,KeyCode.D};

		for (int i = 0; i < 8; i++)
		{
			int num = Random.Range(0, 4);

			fightChars[i] = textLetters[num];
			
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
	

	void Update ()
	{

		if (count < 8 && timer.GetComponent<Timer2>().timeUp == false)
		{
			if (Input.GetKeyUp(keyChain[count]))
			{
				count++;
				
				string textChain = null;
				
				for (int i = count; i < 8; i++)
				{
					if (i == 7)
					{
						textChain += fightChars[i];
					}
					else
					{
						textChain += fightChars[i] + " + ";
					}
				}
				
				this.GetComponent<TextMesh>().text = textChain;
			} 
			else if (Input.anyKey && !Input.GetKey(keyChain[count])) //failure
			{
				this.GetComponent<TextMesh>().text = "You Lose!";
				timer.GetComponent<Timer2>().subTime = false;
				Global.me.score1 = 0;
				Global.me.lives -= 1;
			}
		}
		else //winning
		{
			timer.GetComponent<Timer2>().subTime = false;
			this.GetComponent<TextMesh>().text = "You win!";
			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}
		
		if (timer.GetComponent<Timer2>().timeUp == true) //if the time runs out
		{
			Debug.Log("Fuck my dick");
			timer.GetComponent<Timer2>().subTime = false;
			this.GetComponent<TextMesh>().text = "You lose!";
			Global.me.lives -= 1;
		}

		Debug.Log(fightChars[0]);
		Debug.Log("Count = " + count);

		
		
	}

}
