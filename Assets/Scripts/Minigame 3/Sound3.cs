﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound3 : MonoBehaviour
{

	public AudioClip hiccupSound;
	public AudioClip backSound;
	public AudioClip winSound;
	public AudioClip failSound;
	public AudioClip beep;

	private float effectVolume = 3f;
	private float backvolume = 1f;
	private float endVolume = 3.5f;
	private float beepVolume = 2.5f;

	//array and audio source
	private AudioSource[] audSources;
	public GameObject audSource;


	void Start() //Creates an array of game objects and assigns aduio sources to the game objects
	{
		audSources = new AudioSource[32]; //32, why? Fuck you that's why
		for (int i = 0; i < audSources.Length; i++)
		{
			audSources[i] = (Instantiate(audSource, Vector3.zero, Quaternion.identity) as GameObject).GetComponent<AudioSource>();
		}
		audSources[0].PlayOneShot(backSound, backvolume); //background music
	}

	//plays sound on the assigned game object
	public void Hiccup()
	{
		audSources[1].PlayOneShot(hiccupSound, effectVolume);
	}
	
	public void Win()
	{
		audSources[3].PlayOneShot(winSound, endVolume);
	}
	public void Fail()
	{
		audSources[4].PlayOneShot(failSound, endVolume);
	}
	
	public void Hurry()
	{
		audSources[5].PlayOneShot(beep, beepVolume);
	}
}
