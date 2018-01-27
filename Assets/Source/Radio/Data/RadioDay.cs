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
	public ITranmission[] GetTransmissions() 
	{
		var transmissions = new List<ITranmission> ();
		ITranmission[] val;
		for (int i = 0; i < m_snippets.Length; i++)
		{
			val = m_snippets [i].Transmissions;
			for (int j = 0; j < val.Length; j++)
				transmissions.Add (val[j]);
		}
			
		return transmissions.ToArray();
	}
}
