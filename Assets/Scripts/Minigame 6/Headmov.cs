using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Headmov : MonoBehaviour
{

	private float xPos = 0;
	private float yPos = 0;

	private float xRand;
	private float yRand;
	
	void Start () 
	{
		xRand = Random.Range(1f, 3f);
		yRand = Random.Range(1f, 3f);
	}
	

	void Update () 
	{
		
		this.transform.position = new Vector3(5 * Mathf.Sin(xPos * xRand), Mathf.Cos(yPos * yRand) - 2f, 0);

		xPos += Time.deltaTime;
		yPos += Time.deltaTime;

	}
}
