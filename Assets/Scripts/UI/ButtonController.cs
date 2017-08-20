using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
	[SerializeField] private GameObject selectedImg;

	public void EnableSelected()
	{
		selectedImg.SetActive (true);
	}

	public void DisableSelected()
	{
		selectedImg.SetActive (false);
	}
}

