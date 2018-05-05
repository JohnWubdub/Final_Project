using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneShuffle : MonoBehaviour
{
	private Pokemon_Shader_Transtion transition;
	
	public bool win;

	private int num;
	private int games = 5;
	private float timer = 1f;
	
	// Use this for initialization
	void Start ()
	{
		transition = GameObject.FindObjectOfType<Pokemon_Shader_Transtion>();
		num = SceneManager.GetActiveScene().buildIndex;
		GameObject.Find("Score").GetComponent<Score>().played[GameObject.Find("Score").GetComponent<Score>().playCount] = num;
		GameObject.Find("Score").GetComponent<Score>().playCount++;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (win == true)
		{
			if (timer < 0)
			{
				while ((num == GameObject.Find("Score").GetComponent<Score>().played[0] ||
				        num == GameObject.Find("Score").GetComponent<Score>().played[1] ||
				        num == GameObject.Find("Score").GetComponent<Score>().played[2] ||
				        num == GameObject.Find("Score").GetComponent<Score>().played[3] ||
						num == GameObject.Find("Score").GetComponent<Score>().played[4]) &&
				       GameObject.Find("Score").GetComponent<Score>().playCount < games)
				{
					num = Random.Range(1, games + 1);
				}

				if (GameObject.Find("Score").GetComponent<Score>().playCount < games)
				{
					transition.Can_Transition = true;
					Global.me.nextMinigame = num;
					SceneManager.LoadScene(7);
				}
				else
				{
					SceneManager.LoadScene(6);
				}
		}
			else
			{
				timer -= Time.deltaTime;
			}
		}
		
	}
}
