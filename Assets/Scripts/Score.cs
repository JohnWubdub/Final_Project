using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int game1;
	public int game2;
	public int game3;
	public int game4;
	public int game5;

	public int[] played = {-1,-1,-1,-1,-1,-1};
	public int playCount = 0;
	
	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		if (Global.me.currentMinigame == 7 || Global.me.currentMinigame == 6)
		{
			GameObject.Find("ScoreText").GetComponent<TextMesh>().text = "" + (game1 + game2 + game3 + game4 + game5);
		}

/*		Debug.Log("Score1:" + game1);
		Debug.Log("Score2:" + game2);
		Debug.Log("Score3:" + game3);
		Debug.Log("Score4:" + game4);
		Debug.Log("Score5:" + game5);
*/	}
}
