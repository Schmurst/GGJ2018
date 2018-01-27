﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoSingleton<GameManager>
{
	public EGameState PrevState { get ; protected set; }
	public EGameState State { get { return m_currentState != null ? m_currentState.Type : EGameState.nullOrLength; } }
	IGameState m_currentState;

	// -------------------------------------------------------------------------------------------
	void StartGame()
	{
		SetState (IntroGameState.Me);
	}

	// -------------------------------------------------------------------------------------------
	public void SetState(IGameState _state)
	{
		PrevState = State;
		_state.EnterState ();
		m_currentState = _state;
	}

	// -------------------------------------------------------------------------------------------
	[CustomEditor(typeof(GameManager))]	
	public class GameManagerEditor : Editor
	{
		GameManager me;
		public override bool RequiresConstantRepaint (){return true;}
		public override void OnInspectorGUI ()
		{
			if (!Application.isPlaying)
			{
				DrawDefaultInspector ();
				return;
			}
			
			if (me == null)
				me = GameManager.Me;
			if (me == null)
				return;

			if (GUILayout.Button("Start Intro"))
			{
				me.StartGame ();
			}

			string msg = string.Format ("State: {0}", me.m_currentState != null ? 
				me.m_currentState.ToString() : "None");
			EditorGUILayout.LabelField (msg);
		}
	}
}