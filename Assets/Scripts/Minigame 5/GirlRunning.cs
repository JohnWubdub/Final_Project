using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using JetBrains.Annotations;
using UnityEngine;

public class GirlRunning : MonoBehaviour
{

	public GameObject tallGirl;
	public GameObject shortGirl;
	public GameObject runText;
	public GameObject timer;

	private bool run;
	private GameObject currentGirl;
	private GameObject otherGirl;
	private float tallTimer;
	private float shortTimer;
	
	private KeyCode[] keyLetters = {KeyCode.W, KeyCode.A,KeyCode.S,KeyCode.D};
	private string[] textLetters = {"W","A","S","D"};
	private KeyCode firstKey;
	private KeyCode secondKey;
	private string firstLetter;
	private string secondletter;
	private int num1;
	private int num2;
	
	public bool win = false;
	public bool fail = false;
	private int soundCount = 0;
	
	// Use this for initialization
	void Start ()
	{
		//Global.me.currentMinigame = 4; IMPLIMENT LATER
		currentGirl = tallGirl;
		otherGirl = shortGirl;
		firstKey = KeyCode.A;
		secondKey = KeyCode.S;
		firstLetter = "A";
		secondletter = "S";
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (otherGirl.transform.position.x >= -5f)
		{
			if (timer.GetComponent<Timer5>().timeUp == false)
			{
				if ((run && Input.GetKeyUp(firstKey)) || (!run && Input.GetKeyUp(secondKey)))
				{
					
					currentGirl.transform.position += new Vector3(.50f, .05f, 0);
					if (currentGirl == tallGirl)
					{
						GetComponent<Sound5>().TallRun();
					}
					if (currentGirl == shortGirl)
					{
						GetComponent<Sound5>().SmallRun();
					}
					run = !run;
				}

				if (Input.GetKeyUp(KeyCode.Space))
				{
					if (currentGirl == tallGirl)
					{
						currentGirl = shortGirl;
						otherGirl = tallGirl;
					}
					else
					{
						currentGirl = tallGirl;
						otherGirl = shortGirl;
					}

					num1 = Random.Range(0, 4);
					num2 = Random.Range(0, 4);
					while (num1 == num2)
					{
						num2 = Random.Range(0, 4);
					}

					firstKey = keyLetters[num1];
					secondKey = keyLetters[num2];
					firstLetter = textLetters[num1];
					secondletter = textLetters[num2];

					runText.GetComponent<TextMesh>().text = firstLetter + " + " + secondletter;
				}

				otherGirl.transform.position -= new Vector3(Time.deltaTime * 2f, Time.deltaTime * .2f, 0);
				runText.transform.position = currentGirl.transform.position + new Vector3(0, 2f, 0);
			}

			if (timer.GetComponent<Timer5>().timeUp == true)
			{
				win = true;
				
				if (tallGirl.transform.position.x > -5 && shortGirl.transform.position.x > -5)
				{
					GameObject.Find("Score").GetComponent<Score>().game5 = 25;
				}
				if (tallGirl.transform.position.x > -1 && shortGirl.transform.position.x > -1)
				{
					GameObject.Find("Score").GetComponent<Score>().game5 = 50;
				}
				if (tallGirl.transform.position.x > 2 && shortGirl.transform.position.x > 2)
				{
					GameObject.Find("Score").GetComponent<Score>().game5 = 75;
				}
				if (tallGirl.transform.position.x > 5 && shortGirl.transform.position.x > 5)
				{
					GameObject.Find("Score").GetComponent<Score>().game5 = 100;
				}

			}
		}
		
		if(tallGirl.transform.position.x <= -5f || shortGirl.transform.position.x <= -5f)
		{
			fail = true;
			timer.GetComponent<Timer5>().subTime = false;
			runText.GetComponent<TextMesh>().text = "You Failed!";
			GameObject.Find("Score").GetComponent<Score>().game5 = 0;
			Global.me.lose = true;
//			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}
		
		if (fail == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound5>().Fail();
			soundCount += 1;
		}
		
		if (win == true && soundCount < 2) //sound stuff
		{
			Debug.Log("Help me");
			GetComponent<Sound5>().Win();
			soundCount += 1;
		}

		if (win == true)
		{
			runText.GetComponent<TextMesh>().text = "You Win!";
			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}
		
	}
}
