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
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (win == true)
		{
			if (timer < 0)
			{
				while (num == SceneManager.GetActiveScene().buildIndex)
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
