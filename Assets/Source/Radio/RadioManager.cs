﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RadioManager : MonoSingleton<RadioManager>
{
	[SerializeField] RadioWeek[] m_weeks;

	public int WeekIdx { get; protected set; }
	public int DayIdx { get; protected set; }
	public RadioWeek Week { get { return m_weeks [WeekIdx]; } }
	public RadioDay Day { get { return Week.Days [DayIdx]; } }

	// -------------------------------------------------------------------------------------------
	void Start()
	{
		WeekIdx = DayIdx = 0;
	}

	// -------------------------------------------------------------------------------------------
	public void IncrementToNextDay()
	{
		if (DayIdx + 1 >= Week.Days.Length)
		{
			DayIdx = 0;
			WeekIdx++;
		}
		else
		{
			DayIdx++;
		}
	}

	// -------------------------------------------------------------------------------------------
	void OnBroadCastComplete()
	{
		RadioGameState.Me.OnRadioDayBroadcastComplete ();
	}

	// -------------------------------------------------------------------------------------------
	public void PlayDay()
	{
		AudioManager.Me.PlayRadio (Day, OnBroadCastComplete);
	}

	#if UNITY_EDITOR
	// -------------------------------------------------------------------------------------------
	[CustomEditor(typeof(RadioManager))]	
	public class RadioManagerEditor : Editor
	{
		RadioManager me;
		public override void OnInspectorGUI ()
		{
			if (me == null)
				me = RadioManager.Me;
			if (me == null)
				return;

			if (GUILayout.Button ("Play Day 1"))
			{
				me.WeekIdx = me.DayIdx = 0;
				me.PlayDay ();
			}

			EditorGUILayout.LabelField ("Week", me.WeekIdx.ToString ());
			EditorGUILayout.LabelField ("Day", me.DayIdx.ToString ());

			DrawDefaultInspector ();
		}
 	}
	#endif
}