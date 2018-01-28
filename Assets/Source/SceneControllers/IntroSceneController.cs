using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoSingleton<IntroSceneController>
{
	[SerializeField] Button m_play;

	void Start()
	{
		m_play.onClick.AddListener (Play);
	}

	void Play()
	{
		SceneManager.LoadScene ("main");
	}
}
