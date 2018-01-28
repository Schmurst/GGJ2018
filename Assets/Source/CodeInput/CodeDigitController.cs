using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeDigitController : MonoBehaviour
{
	[SerializeField] Button m_buttonUp;
	[SerializeField] Button m_buttonDown;
	[SerializeField] RectTransform m_scrollTrans;

	public int Value;
	float m_targetPosition;

	public void Initialise()
	{
		ResetToZero ();
		m_buttonUp.onClick.AddListener (ValueUp);
		m_buttonDown.onClick.AddListener (ValueDown);
	}

	void ValueUp()
	{
		Value++;
		m_targetPosition = m_targetPosition - CodeInputController.Me.DigitHeight;
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
	}

	void ValueDown()
	{
		Value--;
		m_targetPosition = m_targetPosition + CodeInputController.Me.DigitHeight;
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
	}

	public void ResetToZero()
	{
		m_scrollTrans.anchoredPosition = new Vector2(0f, CodeInputController.Me.DigitZeroPos);
		m_targetPosition = m_scrollTrans.localPosition.y;
		Value = 0;
	}

	void Update ()
	{
		var pos = m_scrollTrans.anchoredPosition;
		if (pos.y > CodeInputController.Me.DigitUpperLimit)
			m_targetPosition = pos.y = CodeInputController.Me.DigitUpperReset;
		if (pos.y < CodeInputController.Me.DigitLowerLimit)
			m_targetPosition = pos.y = CodeInputController.Me.DigitLowerReset;

		pos = Vector2.Lerp (pos, Vector2.up * m_targetPosition, CodeInputController.Me.DigitLerpPower);

		m_scrollTrans.anchoredPosition = pos;
	}
}
