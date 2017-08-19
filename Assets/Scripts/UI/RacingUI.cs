using System;
using UnityEngine;
using UnityEngine.UI;

public class RacingUI : MonoBehaviour
{
	[SerializeField] private Text[] playerCurrency;
	[SerializeField] private Text[] countDown;

	public void SetCountDown(string text)
	{
		for (int i = 0; i < countDown.Length; i++)
		{
			countDown [i].text = text;
		}
	}
}

