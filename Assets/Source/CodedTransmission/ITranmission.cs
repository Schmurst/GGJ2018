using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransmissionType
{
	news = 0,
	weather = 1,
	lotto = 2,
	sport = 3,
}

public interface ITranmission
{
	TransmissionType Type { get; }
	int CalculateCode (int _val);
}