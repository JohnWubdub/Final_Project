using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound4 : MonoBehaviour {

	public AudioClip flipSound;
	public AudioClip loveSound;
	public AudioClip backSound;
	public AudioClip winSound;
	public AudioClip failSound;

	public float volume = .1f;
	public float backvolume = .25f;

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
	public void Flip()
	{
		audSources[1].PlayOneShot(flipSound, volume);
	}
	
	public void Love()
	{
		audSources[2].PlayOneShot(loveSound, volume);
	}
	
	public void Win()
	{
		audSources[3].PlayOneShot(winSound, volume);
	}
	public void Fail()
	{
		audSources[4].PlayOneShot(failSound, volume);
	}
}
