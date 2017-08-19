using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour {
	[SerializeField]
	AudioSource audioSource;
	[SerializeField]
	AudioClip RaceMusic, MenuMusic;
	bool fadingIn;

	[SerializeField]
	float fadeSpeed = 1.5f;

	AudioClip nextClip;

	/// <summary>
	/// Plays the given tune
	/// </summary>
	/// <param name="music"> play music. "menu" or "race"</param>
	public void PlayMusic(string music)
	{
		// set next song
		AudioClip selectedClip = null;
		switch (music)
		{
			case "menu":
				selectedClip = MenuMusic;
				break;
			case "race":
				selectedClip = RaceMusic;
				break;
		}
		if(selectedClip != null && audioSource.clip != selectedClip)
		{
			nextClip = selectedClip;
		}
		audioSource.clip = selectedClip;
		audioSource.Play();
	}

	// Use this for initialization
	void Start () {
		PlayMusic("menu");
	}
	
	// Update is called once per frame
	void Update () {
		if(nextClip != null)
		{
			//lowerVolume till nill
			if ((audioSource.volume -= fadeSpeed * Time.deltaTime) == 0)
			{
				fadingIn = true;
				audioSource.clip = nextClip;
				audioSource.Play();
			}
		}
		if (fadingIn)
		{
			//raise volume till full
			if ((audioSource.volume += fadeSpeed * Time.deltaTime)==1)
			{
				nextClip = null;
			}
		}
	}
}
