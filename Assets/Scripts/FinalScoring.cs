using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoring : MonoBehaviour
{
	private int finalScore;

	void Update ()
	{
		finalScore = Global.me.score1 + Global.me.score2 + Global.me.score3 + Global.me.score4 + Global.me.score5;
		this.GetComponent<TextMesh>().text = "" + finalScore;
	}
}
