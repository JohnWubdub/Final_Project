using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialGo : MonoBehaviour {
	
	public Button tutButton;
	
	// Use this for initialization
	void Start () {
		Button tutbtn = tutButton.GetComponent<Button> ();
		tutbtn.onClick.AddListener(TaskOnClick);	
	}
	
	void TaskOnClick (){
		SceneManager.LoadScene("Tutorial Scene");
	}
}
