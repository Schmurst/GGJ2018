using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
	public int ClipIdx { get; private set; }

	AudioSource m_sourceRadio;
	Coroutine m_currentRadio;

	// -------------------------------------------------------------------------------------------
	void Start()
	{
		m_sourceRadio = gameObject.AddComponent<AudioSource> ();
	}

	// -------------------------------------------------------------------------------------------
	public void Debug_SkipAudio()
	{
		if (GameManager.IS_DEBUG && m_currentRadio != null)
		{
			m_sourceRadio.Stop ();
		}
	}

	// -------------------------------------------------------------------------------------------
	public void PlayRadio(RadioDay _radioDay, Action _onComplete)
	{
		m_currentRadio = StartCoroutine (Co_PlayRadio(_radioDay.AudioClips, _onComplete));
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
		ClipIdx = 0;
		do {
			Debug.LogFormat("Starting to play audio clip; {0}", ClipIdx);
			m_sourceRadio.clip =_clips [ClipIdx++]; 
			m_sourceRadio.Play ();
			yield return wait;
		} while (ClipIdx < _clips.Length);

		Debug.LogFormat("Finished playing {0} clips", ClipIdx);
		if (_onComplete != null)
			_onComplete ();
		ClipIdx = 0;
	}
}