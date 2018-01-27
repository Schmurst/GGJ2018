using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RadioManager : MonoSingleton<RadioManager>
{
	[SerializeField] RadioWeek[] m_weeks;

	public int Week { get; protected set; }
	public int Day { get; protected set; }

	// -------------------------------------------------------------------------------------------
	void Start()
	{
		Week  = Day = 0;
	}

	// -------------------------------------------------------------------------------------------
	void PlayDay()
	{

	}

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
				me.Week = me.Day = 0;
				me.PlayDay ();
			}

			EditorGUILayout.LabelField ("Week", me.Week.ToString ());
			EditorGUILayout.LabelField ("Day", me.Day.ToString ());

			DrawDefaultInspector ();
		}
	}
}