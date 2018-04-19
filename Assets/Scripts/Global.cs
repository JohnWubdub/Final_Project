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

	public int finalScore = Global.me.score1 + Global.me.score2 + Global.me.score3 +
	                        Global.me.score4 + Global.me.score5;

	private void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		me = this; //awakens the script
	}
}