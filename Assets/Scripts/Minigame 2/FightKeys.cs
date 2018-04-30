using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightKeys : MonoBehaviour //fighting mini game main script
{
	private KeyCode[] keyChain = new KeyCode[8];
	private int count = 0;
	public GameObject timer;
	
	public bool win = false;
	public bool fail = false;
	public int soundCount = 0;
	
	char[] fightChars = new char[8];
	
	// Use this for initialization
	void Start ()
	{

		//Global.me.currentMinigame = 1;  PLEASE IMPLIMENT LATER

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

		GetComponent<TextMesh>().text = textChain; //displays the text
		
	}
	

	void Update ()
	{

		if (count < 8 && timer.GetComponent<Timer2>().timeUp == false)
		{
			if (Input.GetKeyDown(keyChain[count]) && timer.GetComponent<Timer2>().subTime == true) //if they press da button
			{
				count++;
				
				//sound effect randomization
				int rand = Random.Range(1, 4);
				
				Debug.Log(rand);

				if (rand == 1)
				{
					GetComponent<Sound2>().Punch1(); //calling sound effect
				}
				if (rand == 2)
				{
					GetComponent<Sound2>().Punch2(); //calling sound effect
				}
				if (rand == 3)
				{
					GetComponent<Sound2>().Punch3(); //calling sound effect
				}
				
				
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
				fail = true;
				Global.me.score1 = 0;
				Global.me.lives -= 1;
			}
		}
		else //winning
		{
			timer.GetComponent<Timer2>().subTime = false;
			GetComponent<TextMesh>().text = "You win!";
			win = true;
			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}
		
		if (timer.GetComponent<Timer2>().timeUp == true) //if the time runs out
		{
			fail = true;
			timer.GetComponent<Timer2>().subTime = false;
			this.GetComponent<TextMesh>().text = "You lose!";
			Global.me.lives -= 1;
		}
 
		
		if (fail == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound3>().Fail();
			soundCount += 1;
		}
		if (win == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound3>().Win();
			soundCount += 1;
		}
		
	}

}
