using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour {

	[System.Serializable]
	public class SFXMapping
	{
		public string Name;
		public AudioClip Clip;
	}

	[SerializeField]
	List<SFXMapping> SFXDatabase;
	[SerializeField]
	List<SFXMapping> MusicDatabase;
	[SerializeField]
	AudioSource musicSource;
	[SerializeField]
	List<AudioSource> SFXSources;
	bool fadingIn;

	[SerializeField]
	float fadeSpeed = 1.5f;

	AudioClip nextClip;

	/// <summary>
	/// Plays the given tune
	/// </summary>
	/// <param name="music"> play music. "menu" or "race"</param>
	public void PlayMusic(string musicName)
	{
		foreach (var music in MusicDatabase)
		{
			if (music.Name == musicName)
			{
				if (music.Clip != null && musicSource.clip != music.Clip)
				{
					nextClip = music.Clip;
				}
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {
		//PlayMusic("Race");
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

	AudioSource GetAvailableSFXSource()
	{
		for (int i = 0; i < SFXSources.Count; ++i)
		{
			if (!SFXSources[i].isPlaying)
			{
				return SFXSources[i];
			}
		}

		return null;
	}

	void PlayOneShotSFX(string sfxName)
	{
		// picks next available audio source and plays a sound unless all are in use
		foreach (var sfx in SFXDatabase)
		{
			if (sfx.Name == sfxName)
			{
				var source = GetAvailableSFXSource();
				if(source != null)
				{
					source.PlayOneShot(sfx.Clip);
				}
				break;
			}
		}
		
	}
}
