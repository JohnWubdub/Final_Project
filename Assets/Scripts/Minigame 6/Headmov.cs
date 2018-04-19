using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEditor.Rendering;
using UnityEngine;

public class Headmov : MonoBehaviour
{

	private float xPos = 0;
	private float yPos = 0;

	private float xRand;
	private float yRand;

	public GameObject hand;
	
	void Start () 
	{
		xRand = Random.Range(5f, 6f);
		yRand = Random.Range(5f, 6f);
	}
	

	void Update () 
	{
		if (hand.GetComponent<Handmove>().end == false)
		{
			this.transform.position = new Vector3(5 * Mathf.Sin(xPos * xRand), Mathf.Cos(yPos * yRand) - 2f, 0);

			xPos += Time.deltaTime;
			yPos += Time.deltaTime;
		}

	}
}
