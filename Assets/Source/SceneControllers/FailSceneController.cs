using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailSceneController : MonoBehaviour
{
	void Start () {
		StartCoroutine (Co_wait ());	
	}

	IEnumerator Co_wait()
	{
		yield return new WaitForSeconds (5f);
		SceneManager.LoadScene ("intro");
	}
}
