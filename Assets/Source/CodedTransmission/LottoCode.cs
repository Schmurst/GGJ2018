using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LottoCode : MonoBehaviour, ITranmission
{
	public TransmissionType Type { get { return TransmissionType.lotto; } }

	public enum LottoType
	{
		add3rd,
		lastIsEven,
		repeated,
	}

	public LottoType lottoType;

	public int CalculateCode (int _val)
	{
		return 0;
	}
}