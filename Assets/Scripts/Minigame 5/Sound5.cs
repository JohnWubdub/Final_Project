using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound5 : MonoBehaviour //sounds for scene 5
{

	public AudioClip smallRunSound;
	public AudioClip tallRunSound;
	public AudioClip backSound;
	public AudioClip winSound;
	public AudioClip failSound;
	public AudioClip beep;

	private float effectVolume = 2f;
	private float smallVolume = 1.5f;
	private float backvolume = 2f;
	private float endVolume = 5f;
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
	public void SmallRun()
	{
		audSources[1].PlayOneShot(smallRunSound, smallVolume);
	}
	
	public void TallRun()
	{
		audSources[2].PlayOneShot(tallRunSound, effectVolume);
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
