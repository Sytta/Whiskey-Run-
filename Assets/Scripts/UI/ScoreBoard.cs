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
	[SerializeField] public GameObject[] buttons;
	public int selectedButton;

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
			SetCrates(i, GameManager.instance.players[i].Abilities["Crate"]);

            // Set crates income
			SetCratesBonus(i, GameManager.instance.players[i].Abilities["Crate"] * cratePrice);

            // Set total income
            SetTotalIncome(i, GameManager.instance.players[i].totalIncome);

        }

		selectedButton = 0;
		UpdateSeletedButtonDisplay ();
    }

	void Update()
	{
		if (Input.GetAxis ("Horizontal_P1") > 0.0f || Input.GetAxis ("Horizontal_P2") > 0.0f)
		{
			IncrementSelectedButtonIndex ();
		}
		if (Input.GetAxis ("Horizontal_P1") < 0.0f || Input.GetAxis ("Horizontal_P2") < 0.0f)
		{
			DecrementSelectedButtonIndex ();
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

	void DecrementSelectedButtonIndex()
	{
		if (selectedButton > 0)
		{
			selectedButton--;
			UpdateSeletedButtonDisplay ();
		}
	}

	void IncrementSelectedButtonIndex()
	{
		if (selectedButton < buttons.Length - 1)
		{
			selectedButton++;
			UpdateSeletedButtonDisplay ();
		}
	}

	void UpdateSeletedButtonDisplay()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			if (i == selectedButton)
			{
				buttons [i].GetComponent<ButtonController> ().EnableSelected();
			}
			else
			{
				buttons [i].GetComponent<ButtonController> ().DisableSelected();
			}
		}
	}
}

