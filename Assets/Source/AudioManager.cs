using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
	AudioSource m_sourceRadio;
	Coroutine m_currentRadio;

	// -------------------------------------------------------------------------------------------
	void Start()
	{
		m_sourceRadio = gameObject.AddComponent<AudioSource> ();
	}

	// -------------------------------------------------------------------------------------------
	public void PlayRadio(RadioDay _radioDay, Action _onComplete)
	{
		m_currentRadio = StartCoroutine (Co_PlayRadio(_radioDay.GetClips(), _onComplete));
	}

	// -------------------------------------------------------------------------------------------
	public void PlayRadio(AudioClip _clip, Action _onComplete)
	{
		m_currentRadio = StartCoroutine (Co_PlayRadio(new AudioClip[] {_clip}, _onComplete));
	}

	// -------------------------------------------------------------------------------------------
	IEnumerator Co_PlayRadio(AudioClip[] _clips, Action _onComplete)
	{
		WaitUntil wait = new WaitUntil(()=>{return !m_sourceRadio.isPlaying;});
		int idx = 0;
		do {
			m_sourceRadio.clip =_clips [idx++]; 
			m_sourceRadio.Play ();
			yield return wait;
		} while (idx < _clips.Length);
	}
}
