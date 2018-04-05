using UnityEngine;
using System.Collections;

public class Global : MonoBehaviourSingleton<Global> //acts almost like a bank for the global variables to be called later
{
	public static Global me;

	public int score; 

	private void Awake()
	{
		me = this; //awakens the script
	}
}