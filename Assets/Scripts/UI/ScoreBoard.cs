using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	[SerializeField] Text[] positions;
	[SerializeField] Text[] positionsBonus;
	[SerializeField] Text[] nbCrates;
	[SerializeField] Text[] cratesBonus;
	[SerializeField] Text[] total;
	[SerializeField] Button continueButton;
	[SerializeField] Button quitButton;

	public void SetPosition(int playerIndex, int position)
	{
		positions [playerIndex].text = "POSITION : " + position.ToString ();
	}

	public void SetPositionBonus(int playerIndex, int bonus)
	{
		positionsBonus [playerIndex].text = "POSITION BONUS CASH : " + bonus.ToString ();
	}

	public void SetCrates(int playerIndex, int nCrates)
	{
		nbCrates [playerIndex].text = "NUMBER OF CRATES : " + nCrates.ToString ();
	}

	public void SetCratesBonus(int playerIndex, int bonus)
	{
		cratesBonus [playerIndex].text = "CRATES INCOME : " + bonus.ToString ();
	}

	public void SetTotalIncome(int playerIndex, int income)
	{
		total [playerIndex].text = "TOTAL INCOME - " + income.ToString ();
	}
}

