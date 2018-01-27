using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoCode : MonoBehaviour, ICodedTranmission
{
	public enum LottoType
	{
		add3rd,
		lastIsEven,
		repeated,
	}

	public LottoType Type;

	public int CalculateCode (int _val)
	{
		return 0;
	}
}