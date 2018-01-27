using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsCode : MonoBehaviour, ITranmission
{
	public TransmissionType Type { get { return TransmissionType.news; } }

	public enum NewsType
	{
		WarEffort,
		Zarot,
		Teamwork,
		David
	}

	public NewsType newsType;

	public int CalculateCode (int _val)
	{
		return 0;
	}
}