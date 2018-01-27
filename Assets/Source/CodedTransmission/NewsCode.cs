using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsCode : MonoBehaviour, ICodedTranmission
{
	public enum NewsType
	{
		WarEffort,
		Zarot,
		Teamwork,
		David
	}

	public NewsType Type;

	public int CalculateCode (int _val)
	{
		return 0;
	}
}