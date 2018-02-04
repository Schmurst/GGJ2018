using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
	public int ClipIdx { get; private set; }

	[SerializeField] float m_timeToFade = 1f;

	AudioSource m_sourceRadio;
	Coroutine m_currentRadio;

	// -------------------------------------------------------------------------------------------
	void Awake()
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
	public void ForceFadeAudio()
	{
		StopCoroutine (m_currentRadio);
		StartCoroutine (Co_FadeAudioThenStop ());
	}

	// -------------------------------------------------------------------------------------------
	IEnumerator Co_FadeAudioThenStop()
	{
		float pcnt = 0f;
		while (pcnt < 1f)
		{
			pcnt += Time.deltaTime / m_timeToFade;
			m_sourceRadio.volume = pcnt;
			yield return null;
		}

		m_sourceRadio.Stop ();
		m_sourceRadio.volume = 1f;
	}

	// -------------------------------------------------------------------------------------------
	public void PlayRadio(RadioDay _radioDay, Action _onComplete)
	{
		Debug.LogFormat("Starting to play radio day");
		m_currentRadio = StartCoroutine (Co_PlayRadio(_radioDay.AudioClips, _onComplete));
	}

	// -------------------------------------------------------------------------------------------
	public void PlayRadio(AudioClip _clip, Action _onComplete)
	{
		Debug.LogFormat("Starting to play radio clip");
		m_currentRadio = StartCoroutine (Co_PlayRadio(new AudioClip[] {_clip}, _onComplete));
	}

	// -------------------------------------------------------------------------------------------
	IEnumerator Co_PlayRadio(AudioClip[] _clips, Action _onComplete)
	{
		WaitUntil wait = new WaitUntil(()=>{return !m_sourceRadio.isPlaying;});
		ClipIdx = 0;
		do {
			Debug.LogFormat("Starting to play audio clip; {0} of  {1}", ClipIdx, _clips.Length);
			m_sourceRadio.clip =_clips [ClipIdx++]; 
			m_sourceRadio.Play ();
			yield return wait;
		} while (ClipIdx < _clips.Length);

		m_sourceRadio.Stop ();
		Debug.LogFormat("Finished playing {0} clips", ClipIdx);
		if (_onComplete != null)
			_onComplete ();
		ClipIdx = 0;
	}
}