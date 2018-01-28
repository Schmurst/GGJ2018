using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeSignController : MonoBehaviour
{
	[SerializeField] Button m_buttonUp;
	[SerializeField] Button m_buttonDown;
	[SerializeField] RectTransform m_scrollTrans;

	public float Zero;
	public float Height;
	public float UpperLimit;
	public float UpperReset;
	public float LowerLimit;
	public float LowerReset;

	public bool Value = true;
	float m_targetPosition;

	public void Initialise()
	{
		ResetToZero ();
		m_buttonUp.onClick.AddListener (ValueUp);
		m_buttonDown.onClick.AddListener (ValueDown);
	}

	void ValueUp()
	{
		Value = !Value;
		m_targetPosition = m_targetPosition - Height;
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
	}

	void ValueDown()
	{
		Value = !Value;
		m_targetPosition = m_targetPosition + Height;
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
	}

	public void ResetToZero()
	{
		m_scrollTrans.anchoredPosition = new Vector2(0f, Zero);
		m_targetPosition = m_scrollTrans.localPosition.y;
		Value = true;
	}

	void Update ()
	{
		var pos = m_scrollTrans.anchoredPosition;
		if (pos.y > UpperLimit)
			m_targetPosition = pos.y = UpperReset;
		if (pos.y < LowerLimit)
			m_targetPosition = pos.y = LowerReset;

		pos = Vector2.Lerp (pos, Vector2.up * m_targetPosition, CodeInputController.Me.DigitLerpPower);

		m_scrollTrans.anchoredPosition = pos;
	}
}
