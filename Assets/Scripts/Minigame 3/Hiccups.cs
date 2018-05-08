using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hiccups : MonoBehaviour
{
	public GameObject girl;
	Animator anime;
	//private int hash = Animator.StringToHash("hiccup");
	
	public GameObject timer;

	public bool space = false;
	
	public bool win = false;
	public bool fail = false;

	private int hiccupNum;

	private float tinyTimer = .2f;

	private float addTimer = 2f;

	private float waitTimer = 0;

	private int soundCount = 0;
	
	void Start ()
	{
		hiccupNum = Random.Range(0, 5);
		anime = girl.GetComponent<Animator>();
		Global.me.currentMinigame = 2;
	}
	

	void Update ()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			anime.SetBool("trig", true);	
		}
		else
		{
			anime.SetBool("trig", false);
		}
		
		GetComponent<TextMesh>().text = "Hiccups: " + hiccupNum;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			hiccupNum++;
			
			GetComponent<Sound3>().Hiccup();
		}
		
		if (Input.GetKey(KeyCode.Space)) 
		{
			anime.SetTrigger("hiccup");
			waitTimer += .1f;
			if (waitTimer >= 1f)
			{
				
				hiccupNum++;
			}
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			waitTimer = 0;
		}

		if (hiccupNum == 99 && timer.GetComponent<Timer3>().timeUp == false) //almost win condition
		{
			tinyTimer -= Time.deltaTime;
			space = true;
		}
		else
		{
			space = false;
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
		
		if (tinyTimer <= 0 && hiccupNum == 99 && timer.GetComponent<Timer3>().timeUp == false) //win condition
		{
			GetComponent<TextMesh>().text = "You win";
			timer.GetComponent<Timer3>().subTime = false;
			win = true;
			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}

		if (hiccupNum > 99 || timer.GetComponent<Timer3>().timeUp == true)  //failure
		{
			timer.GetComponent<Timer3>().subTime = false;
			GetComponent<TextMesh>().text = "You died!";
			anime.SetTrigger("lose");
			Global.me.lose = true;
			fail = true;
			Global.me.lives -= 1;
		}

		

	}

}