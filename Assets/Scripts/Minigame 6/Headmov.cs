using System.Collections;
using System.Collections.Generic;
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
		xRand = Random.Range(5.5f, 6.5f);
		yRand = Random.Range(5.5f, 6.5f);
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
