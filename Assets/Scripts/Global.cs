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
	
	private int game1;
	private int game2;
	private int game3;
	private int game4;
	private int game5;

	public int lives = 3;

	public int currentMinigame = 0;

	private void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
		me = this; //awakens the script
	}

	private void Update()
	{
		if (score1 > 0 || score2 > 0 || score3 > 0 || score4 > 0 || score5 > 0)
		{
			game1 += score1;
			game2 += score2;
			game3 += score3;
			game4 += score4;
			game5 += score5;

			score1 = 0;
			score2 = 0;
			score3 = 0;
			score4 = 0;
			score5 = 0;
		}
		
/*		GameObject.Find("ScoreText").GetComponent<TextMesh>().text = "Score: " + (game1 + game2 + game3 + game4 + game5);
		
		Debug.Log("Score1:" + score1);
		Debug.Log("Score2:" + score2);
		Debug.Log("Score3:" + score3);
		Debug.Log("Score4:" + score4);
		Debug.Log("Score5:" + score5);
*/	}
}