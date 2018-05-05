using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MinigameTutorials : MonoBehaviour 
{
	private Pokemon_Shader_Transtion transition;
	
	float timer = 4f;

	public GameObject prompt;
	public GameObject controls;

	void Start()
	{
		transition = GameObject.FindObjectOfType<Pokemon_Shader_Transtion>();
	}

	void Update ()
	{
		timer -= Time.deltaTime;
		
		if(timer > 0)
		{
			if (Global.me.nextMinigame == 1)
			{
				prompt.GetComponent<TextMesh>().text = "Combo Code";
				controls.GetComponent<TextMesh>().text = "WASD";
			}

			if (Global.me.nextMinigame == 2)
			{
				prompt.GetComponent<TextMesh>().text = "99 Hiccups";
				controls.GetComponent<TextMesh>().text = "Press or Hold SPACE";
			}

			if (Global.me.nextMinigame == 3)
			{
				prompt.GetComponent<TextMesh>().text = "The Right Press";
				controls.GetComponent<TextMesh>().text = "AD + SPACE";
			}

			if (Global.me.nextMinigame == 4)
			{
				prompt.GetComponent<TextMesh>().text = "Try to Run";
				controls.GetComponent<TextMesh>().text = "AS + SPACE to Switch Girl";
			}

			if (Global.me.nextMinigame == 5)
			{
				prompt.GetComponent<TextMesh>().text = "Touch Her";
				controls.GetComponent<TextMesh>().text = "WASD to Move";
			}
		}
		else
		{
			SceneManager.LoadScene(Global.me.nextMinigame);
		}
	}
}
