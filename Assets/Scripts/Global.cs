using UnityEngine;
using System.Collections;

public class Global : MonoBehaviourSingleton<Global> //acts almost like a bank for the global variables to be called later
{
	public static Global me;
	
	public int score1;
	public int score2;
	public int score3;
	public int score4;
	public int score5;

	public int lives = 3;

	public int currentMinigame = 0;

	private void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		me = this; //awakens the script
	}
}