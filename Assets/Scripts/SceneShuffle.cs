using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneShuffle : MonoBehaviour
{

	public bool win;

	private int num;
	private int games = 4;
	private float timer = 2f;
	
	// Use this for initialization
	void Start ()
	{
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
				while (num == GameObject.Find("Score").GetComponent<Score>().played[0] ||
				       num == GameObject.Find("Score").GetComponent<Score>().played[1] ||
				       num == GameObject.Find("Score").GetComponent<Score>().played[2] ||
				       num == GameObject.Find("Score").GetComponent<Score>().played[3])
				{
					num = Random.Range(1, games + 1);
				}
				SceneManager.LoadScene(num);
			}
			else
			{
				timer -= Time.deltaTime;
			}
		}
		
	}
}
