using System.Collections;
using UnityEngine;
using UnityEngine.Collections;

public class Handmove : MonoBehaviour
{

	public GameObject timer; 
	
	public int pleasure = 0;

	private int endNum = 95;

	public GameObject headText;

	public GameObject head;

	private float moveSpeed = .4f;

	private float maxExtend = 2.3f;

	private float maxRetract = 8.74f;

	public bool end = false;
	
	public bool win = false;
	public bool fail = false;
	private int soundCount = 0;

	private float tinyTimer = .5f;


	private void Start()
	{
		//Global.me.currentMinigame = 5; IMPLIMENT LATER
	}

	void Update () 
	{
		if (Input.GetKey(KeyCode.S) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(0f, -moveSpeed, 0f);
			if (transform.position.y <= maxExtend)
			{
				transform.position = new Vector3(transform.position.x, maxExtend, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.W) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(0f, moveSpeed, 0f);
			if (transform.position.y >= maxRetract)
			{
				transform.position = new Vector3(transform.position.x, maxRetract, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.A) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(-moveSpeed, 0f, 0f);
		}

		if (Input.GetKey(KeyCode.D) && timer.GetComponent<Timer6>().timeUp == false && end == false)
		{
			transform.position += new Vector3(moveSpeed, 0f, 0f);
		}

		if (pleasure >= endNum && timer.GetComponent<Timer6>().timeUp == false) //winning
		{
			timer.GetComponent<Timer6>().subTime = false;
			headText.GetComponent<TextMesh>().text = "OH YEAH!";
			end = true;
			win = true;
			GameObject.Find("SceneShuffler").GetComponent<SceneShuffle>().win = true;
		}

		if (pleasure < endNum && timer.GetComponent<Timer6>().timeUp == true) //fail
		{
			timer.GetComponent<Timer6>().subTime = false;
			headText.GetComponent<TextMesh>().text = "FUCK YOU!";
			Global.me.lives -= 1;
			end = true;
			fail = true;
			Global.me.lose = true;
		}
		
		if (fail == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound6>().Fail();
			soundCount += 1;
		}
		if (win == true && soundCount < 2) //sound stuff
		{
			GetComponent<Sound6>().Moan();
			soundCount += 1;
		}
		
	}

	private void OnCollisionStay(Collision other)
	{
		pleasure += 1;
		Debug.Log("Fuck me");
		tinyTimer -= Time.deltaTime;
		if (tinyTimer <= 0f)
		{
			GetComponent<Sound6>().Pet();
			tinyTimer = .5f;
		}
	}
}
