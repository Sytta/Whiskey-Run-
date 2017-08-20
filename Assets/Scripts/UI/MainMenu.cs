using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] public GameObject[] buttons;
	public int selectedButton;

	void Start()
	{
		selectedButton = 0;
		UpdateSelectedButtonDisplay ();
	}

	void Update()
	{
		if (Input.GetAxis ("Vertical_P1") > 0.0f || Input.GetAxis ("Vertical_P2") > 0.0f)
		{
			DecrementSelectedButtonIndex ();
		}
		if (Input.GetAxis ("Vertical_P1") < 0.0f || Input.GetAxis ("Vertical_P2") < 0.0f)
		{
			IncrementSelectedButtonIndex ();
		}
	}

	void DecrementSelectedButtonIndex()
	{
		if (selectedButton > 0)
		{
			selectedButton--;
			UpdateSelectedButtonDisplay ();
		}
	}

	void IncrementSelectedButtonIndex()
	{
		if (selectedButton < buttons.Length - 1)
		{
			selectedButton++;
			UpdateSelectedButtonDisplay ();
		}
	}

	void UpdateSelectedButtonDisplay()
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

