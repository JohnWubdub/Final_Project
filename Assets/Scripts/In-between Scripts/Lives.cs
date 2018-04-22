using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Lives : MonoBehaviour
{
	public GameObject gun1;
	public GameObject gun2;
	public GameObject gun3;

	private Vector3 gun1Size;
	private Vector3 gun2Size;
	private Vector3 gun3Size;

	private Vector3 endSize = new Vector3(0f,0f,0f);

	private void Start()
	{
		gun1Size = gun1.transform.localScale;
		gun2Size = gun2.transform.localScale;
		gun3Size = gun3.transform.localScale;
	}

	void Update ()
	{
		if (Global.me.lives == 2)
		{
			gun1.transform.localScale = Vector3.Lerp(gun1Size, endSize, .5f);
			//play sound
		}
		
		if(Global.me.lives == 1)
		{
			gun1.transform.localScale = endSize;
			gun3.transform.localScale = Vector3.Lerp(gun3Size, endSize, .5f);
			//play sound
		}
		
		if(Global.me.lives == 0)
		{
			gun1.transform.localScale = endSize;
			gun3.transform.localScale = endSize;
			gun2.transform.localScale = Vector3.Lerp(gun2Size, endSize, .5f);
			//play sound
		}
	}
}
