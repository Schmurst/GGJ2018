﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSnippet : MonoBehaviour
{	
	[SerializeField] AudioClip m_clip;

	public AudioClip Clip { get { return m_clip; } }
	public ICodedTranmission Code { get { return gameObject.GetComponent<ICodedTranmission> (); } }
}
