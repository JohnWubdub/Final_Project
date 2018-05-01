using System.Collections;
using UnityEngine;

public class PressInq : MonoBehaviour 
{

	private KeyCode[] keyChain = new KeyCode[10];
	
	private KeyCode[] keyLetters = new KeyCode[]{KeyCode.A,KeyCode.D, KeyCode.Space}; 

	public bool left = false;
	public bool right = false;
	public bool friend = false;

	public GameObject leftMan;
	public GameObject rightMan;
	
	public GameObject rightFriend;
	public GameObject leftFriend;

	public GameObject timer;
	public GameObject helpText;
	
	private int i = 0;
	private bool advance = false;
	private int j = 0;
	private bool spaghetti;
	
	public bool win = false;
	public bool fail = false;
	private int soundCount = 0;
	
	void Start () 
	{
		//Global.me.currentMinigame = 3; IMPLIMENT LATER
		
		for (int i = 0; i < 10; i++)
		{
			keyChain[i] = keyLetters[Random.Range(0, 3)];
			if (i > 0)
			{
				while (keyChain[i] == keyChain[i - 1])
				{
					keyChain[i] = keyLetters[Random.Range(0, 3)];
				}
			}
		}
	}
	

	void Update ()
	{
		if (i < 10 && i >= 0)
		{

			if (keyChain[i] == keyLetters[0]) //if it's A (the left side)
			{
				left = true;
			}

			if (left == true) //activate the renderer
			{
				leftMan.GetComponent<Renderer>().enabled = true;
				helpText.GetComponent<TextMesh>().text = "A";
				helpText.transform.position = leftMan.transform.position + new Vector3(0,2f,0);
			}

			if (left == true && Input.GetKeyUp(KeyCode.A)) //checking to see if they are right
			{
				leftMan.GetComponent<Renderer>().enabled = false;
				advance = true;
				left = false;
				GetComponent<Sound4>().Flip();
			}
			

//_________________________________________________________________________________________________		

			if (keyChain[i] == keyLetters[1]) //if it's D (the right side)
			{
				right = true;
			}

			if (right == true) //activate the renderer
			{
				rightMan.GetComponent<Renderer>().enabled = true;
				helpText.GetComponent<TextMesh>().text = "D";
				helpText.transform.position = rightMan.transform.position + new Vector3(0,2f,0);
			}

			if (right == true && Input.GetKeyUp(KeyCode.D)) //checking to see if they are right
			{
				rightMan.GetComponent<Renderer>().enabled = false;
				advance = true;
				right = false;
				GetComponent<Sound4>().Flip();
			}
			

//_________________________________________________________________________________________________


			if (keyChain[i] == keyLetters[2]) //if it's Space (popokumo)
			{
				friend = true;
			}

			if (friend == true) //activate the renderer
			{
				while (spaghetti == false)
				{
					j = Random.Range(1, 3);
					spaghetti = true;
				}

				if (j == 1)
				{
					rightFriend.GetComponent<Renderer>().enabled = true;
					helpText.transform.position = rightFriend.transform.position + new Vector3(0,2f,0);
				}

				if (j == 2)
				{
					leftFriend.GetComponent<Renderer>().enabled = true;
					helpText.transform.position = leftFriend.transform.position + new Vector3(0,2f,0);
				}
				
				helpText.GetComponent<TextMesh>().text = "Space";
			}

			if (friend == true && Input.GetKeyUp(KeyCode.Space)) //checking to see if they are right
			{
				GetComponent<Sound4>().Love();
				leftFriend.GetComponent<Renderer>().enabled = false;
				rightFriend.GetComponent<Renderer>().enabled = false;
				advance = true;
				friend = false;
				spaghetti = false;
			}
			
			
			if ((left == true && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Space))) ||
			     (right == true && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.Space))) ||
			      (friend == true && (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))) ||
			    timer.GetComponent<Timer4>().timeUp == true) 
			{
				GameObject.Find("WinText").GetComponent<TextMesh>().text = "You Lose!";
				i = -1;
				timer.GetComponent<Timer4>().subTime = false;
				Global.me.lose = true;
				fail = true;
				Global.me.lives -= 1;
			}

			if (advance == true)
			{
				i++;
				advance = false;
			}

		}
		else
		{
			// Maximum spaghetti initiated. Change with VU
			if (i > -1)
			{
				GameObject.Find("WinText").GetComponent<TextMesh>().text = "You Win!";
				win = true;
				helpText.GetComponent<Renderer>().enabled = false;
				timer.GetComponent<Timer4>().subTime = false;
				GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
			}
		}
		
		if (fail == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound4>().Fail();
			soundCount += 1;
		}
		if (win == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound4>().Win();
			soundCount += 1;
		}
	}
}
