using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RadioDay : MonoBehaviour
{
	[SerializeField] RadioSnippet[] m_snippets;	
	[SerializeField] RadioSnippet m_countDownTrack;
	[SerializeField] float m_timeLimit = 30f;

	public float TimeLimit { get { return m_timeLimit; } }
	public AudioClip[] AudioClips{get{return m_snippets.Select (x => x.Clip).ToArray ();}}
	public ITranmission[] Transmissions {get{return m_snippets.Select (x=>x.Code).ToArray();}}
}
