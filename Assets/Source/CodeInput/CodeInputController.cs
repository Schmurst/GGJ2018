using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CodeInputController : MonoSingleton<CodeInputController>
{
	[SerializeField] CodeSignController m_sign; 
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
		m_sign.Initialise ();
		for (int i = 0; i < m_digits.Length; i++)
			m_digits [i].Initialise ();
	}

	public void ResetAllDigits()
	{
		m_sign.ResetToZero ();
		for (int i = 0; i < m_digits.Length; i++)
			m_digits [i].ResetToZero ();
	}

	public int GetPlayerCode()
	{
		int val = 0;
		for (int i = 0; i < m_digits.Length; i++)
			val += m_digits [i].Value * 10 * i;
		return (m_sign.Value ? 1 : -1) * val;
	}
}