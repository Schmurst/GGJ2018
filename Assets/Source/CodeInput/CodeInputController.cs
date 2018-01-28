using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CodeInputController : MonoSingleton<CodeInputController>
{
	[SerializeField] CodeSignController m_sign; 
	[SerializeField] CodeDigitController[] m_digits; 
	[SerializeField] Button m_enterCodeBtn; 

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
		m_enterCodeBtn.onClick.AddListener (ManualCodeEnter);

		m_sign.Initialise ();
		for (int i = 0; i < m_digits.Length; i++)
			m_digits [i].Initialise ();
	}

	void ManualCodeEnter()
	{

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
			val += m_digits [i].Value * (int) Mathf.Pow(10,i);
		return (m_sign.Value ? 1 : -1) * val;
	}
}