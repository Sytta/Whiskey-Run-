using System;
using UnityEngine;
using UnityEngine.UI;

public class RacingUI : MonoBehaviour
{
	[SerializeField] private Text[] playerCurrency;
	[SerializeField] private Text[] countDown;

    private void Start()
    {
        for (int i = 0; i < playerCurrency.Length; i++)
        {
            playerCurrency[i].text = GameManager.instance.players[i].money.ToString() + "$";
        }
    }

    public void InitCountDown(string text)
	{
		for (int i = 0; i < countDown.Length; i++)
		{
			countDown [i].gameObject.SetActive (true);
		}
		SetCountDown (text);
	}

	public void SetCountDown(string text)
	{
		for (int i = 0; i < countDown.Length; i++)
		{
			countDown [i].text = text;
		}
	}

    public void SetWinner(int player, string text)
    {
        countDown[player].text = text;

        countDown[player].gameObject.SetActive(true);
    }

	public void DisableCountDown()
	{
		for (int i = 0; i < countDown.Length; i++)
		{
			countDown [i].gameObject.SetActive (false);
		}
		SetCountDown ("");
	}
}

