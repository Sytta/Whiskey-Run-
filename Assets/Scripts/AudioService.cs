using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour {
	[SerializeField]
	AudioSource musicSource;
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
		if(selectedClip != null && musicSource.clip != selectedClip)
		{
			nextClip = selectedClip;
		}
		musicSource.clip = selectedClip;
		musicSource.Play();
	}

	// Use this for initialization
	void Start () {
		PlayMusic("race");
	}
	
	// Update is called once per frame
	void Update () {
		if(nextClip != null)
		{
			//lowerVolume till nill
			if ((musicSource.volume -= fadeSpeed * Time.deltaTime) <= 0)
			{
				musicSource.clip = nextClip;
				musicSource.Play();
				nextClip = null;
				fadingIn = true;
			}
		}
		if (fadingIn)
		{
			//raise volume till full
			if ((musicSource.volume += fadeSpeed * Time.deltaTime)==1)
			{
				fadingIn = false;
			}
		}
	}
}
