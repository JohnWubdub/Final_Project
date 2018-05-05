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
	

	void Start ()
	{
		transition = GameObject.FindObjectOfType<Pokemon_Shader_Transtion>();
		num = SceneManager.GetActiveScene().buildIndex;
		GameObject.Find("Score").GetComponent<Score>().played[GameObject.Find("Score").GetComponent<Score>().playCount] = num;
		GameObject.Find("Score").GetComponent<Score>().playCount++;
	}
	

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
					Global.me.currentMinigame = 7;
					SceneManager.LoadScene(7);//inbetween
				}
				else
				{
					transition.Can_Transition = true;
					SceneManager.LoadScene(6);//final score
				}
		}
			else
			{
				timer -= Time.deltaTime;
			}
		}
		
	}
}
