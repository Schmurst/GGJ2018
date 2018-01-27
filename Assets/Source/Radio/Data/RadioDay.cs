using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RadioDay : MonoBehaviour
{
	[SerializeField] RadioSnippet[] m_snippets;	

	public AudioClip[] GetClips()
	{
		return m_snippets.Select (x => x.Clip).ToArray();
	}
}
