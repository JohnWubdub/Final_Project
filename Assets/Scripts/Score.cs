using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	public int game1;
	public int game2;
	public int game3;
	public int game4;
	public int game5;
	
	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad (this.gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		GameObject.Find("ScoreText").GetComponent<TextMesh>().text = "Score: " + (game1 + game2 + game3 + game4 + game5);
		
		Debug.Log("Score1:" + game1);
		Debug.Log("Score2:" + game2);
		Debug.Log("Score3:" + game3);
		Debug.Log("Score4:" + game4);
		Debug.Log("Score5:" + game5);
	}
}
