using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioWeek : MonoBehaviour
{
	[SerializeField] RadioDay[] m_days;

	public RadioDay[] Days { get { return m_days; } }
}