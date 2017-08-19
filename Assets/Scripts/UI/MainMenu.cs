using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Button startButton;

	void Start()
	{
		startButton.onClick.AddListener (delegate
		{
		});
	}
}

