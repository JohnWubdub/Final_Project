using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGameStartScript : MonoBehaviour
{
	
	public Button mgStart1;
	public Button mgStart2;
	public Button mgStart3;
	
	public Image img;
	
	//hey guys check out this spaghetti code bc i couldnt gt it to work w an array (':
	// Use this for initialization
	void Start ()
	{
		img.enabled = false;
		
		Button btn = mgStart1.GetComponent<Button> ();
		Button btn2 = mgStart2.GetComponent<Button> ();
		Button btn3 = mgStart3.GetComponent<Button> ();
		
		btn.onClick.AddListener(TaskOnClick);	
		btn2.onClick.AddListener(TaskOnClick);
		btn3.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick (){
		img.enabled = true;
	}
}