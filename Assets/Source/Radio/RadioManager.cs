using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoSingleton<RadioManager>
{
	[SerializeField] RadioWeek[] m_weeks;
}