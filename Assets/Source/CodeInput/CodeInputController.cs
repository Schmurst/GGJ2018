using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInputController : MonoSingleton<CodeInputController>
{
	[SerializeField] CodeDigitController[] m_digits; 

	public float DigitZeroPos = 365f;
	public float DigitRotorHeight = 800f;
	public float DigitHeight = 80f;
	public float DigitUpperLimit;
	public float DigitUpperReset;
	public float DigitLowerLimit; 
	public float DigitLowerReset;
	public float DigitLerpPower = 0.1f;

	void Start()
	{
		for (int i = 0; i < m_digits.Length; i++)
			m_digits [i].Initialise ();
	}

	void ResetAllDigits()
	{
		for (int i = 0; i < m_digits.Length; i++)
			m_digits [i].ResetToZero ();
	}
}