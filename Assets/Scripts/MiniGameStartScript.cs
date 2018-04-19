using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameStartScript : MonoBehaviour //Menu script used to select the minigame they want to play
{
	
/*	public Button mgStart1;
	public Button mgStart2;
	public Button mgStart3;
	public Button mgStart4;
    public Button mgStart5;
	
	//hey guys check out this spaghetti code bc i couldnt gt it to work w an array (':
	// Use this for initialization
	void Start ()
	{
		
		Button btn = mgStart1.GetComponent<Button> ();
		Button btn2 = mgStart2.GetComponent<Button> ();
		Button btn3 = mgStart3.GetComponent<Button> ();
		Button btn4 = mgStart2.GetComponent<Button> ();
		Button btn5 = mgStart2.GetComponent<Button> ();

		btn.onClick.AddListener(delegate {TaskOnClick(1);});	
		btn2.onClick.AddListener(delegate {TaskOnClick(2);});
		btn3.onClick.AddListener(delegate {TaskOnClick(3);});
		btn4.onClick.AddListener(delegate {TaskOnClick(4);});
		btn5.onClick.AddListener(delegate {TaskOnClick(5);});
	
	}

	void TaskOnClick (int level){
//		img.enabled = true;
		SceneManager.LoadScene(level);
	}

*/ 	public void StartGame1()
	{
		SceneManager.LoadScene(1);
	}
	public void StartGame2()
	{
		SceneManager.LoadScene(2);
	}
	public void StartGame3()
	{
		SceneManager.LoadScene(3);
	}
	public void StartGame4()
	{
		SceneManager.LoadScene(4);
	}
	public void StartGame5()
	{
		SceneManager.LoadScene(5);
	}
}