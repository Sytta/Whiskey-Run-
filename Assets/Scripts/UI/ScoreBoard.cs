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

    [SerializeField] int cratePrice = 100;

    public void Initialize()
    {

        for (int i = 0; i < GameManager.instance.players.Length; i ++)
        {
            // Set position
            if (GameManager.instance.players[i].isWinner)
            {
                SetPosition(i, 1);
                SetPositionBonus(i, 200);
            } else
            {
                SetPosition(i, 2);
                SetPositionBonus(i, 0);
            }

            // Set nb crates
            SetCrates(i, GameManager.instance.players[i].nbCrates);

            // Set crates income
            SetCratesBonus(i, GameManager.instance.players[i].nbCrates * cratePrice);

            // Set total income
            SetTotalIncome(i, GameManager.instance.players[i].totalIncome);

        }
    }

    public void SetPosition(int playerIndex, int position)
	{
		positions [playerIndex].text = "POSITION : " + position.ToString ();
	}

	public void SetPositionBonus(int playerIndex, int bonus)
	{
		positionsBonus [playerIndex].text = "POSITION BONUS CASH : " + bonus.ToString () + "$";
        GameManager.instance.players[playerIndex].totalIncome += bonus;

    }

	public void SetCrates(int playerIndex, int nCrates)
	{
		nbCrates [playerIndex].text = "NUMBER OF CRATES : " + nCrates.ToString ();
    }

	public void SetCratesBonus(int playerIndex, int bonus)
	{
		cratesBonus [playerIndex].text = "CRATES INCOME : " + bonus.ToString () + "$";
        GameManager.instance.players[playerIndex].totalIncome += bonus;
    }

	public void SetTotalIncome(int playerIndex, int income)
	{
		total [playerIndex].text = "TOTAL INCOME - " + income.ToString () + "$";
        Debug.Log("Income: " + GameManager.instance.players[playerIndex].totalIncome + " Money: " + GameManager.instance.players[playerIndex].money);
        GameManager.instance.players[playerIndex].money += income;
        Debug.Log("Income: " + GameManager.instance.players[playerIndex].totalIncome + " Money: " + GameManager.instance.players[playerIndex].money);
    }
}

