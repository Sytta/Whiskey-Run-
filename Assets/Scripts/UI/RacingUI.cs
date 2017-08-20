using System;
using UnityEngine;
using UnityEngine.UI;

public class RacingUI : MonoBehaviour
{
	[SerializeField] private Text[] playerCurrency;
	[SerializeField] private Text[] countDown;
	[SerializeField] private GameObject[] playerAbilities;

	void Start()
	{
		SetUpAbilities ();
        for (int i = 0; i < playerCurrency.Length; i++)
        {
            playerCurrency[i].text = GameManager.instance.players[i].money.ToString() + "$";
        }
    }

	private void SetUpAbilities()
	{
		for (int i = 0; i < playerAbilities.Length; i++)
		{
			foreach (BaseAbilityComponent comp in GameManager.instance.players[i].abilityController.components)
			{
				GameObject ab = Instantiate (GameManager.instance.PrefabManager.AbilitySlot, playerAbilities [i].transform);
				ab.GetComponent<AbilitySlot> ().SetComponent (comp);
				ab.GetComponent<AbilitySlot> ().playerId = i;
			}
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

