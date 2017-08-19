using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	[SerializeField] private Text name;
	[SerializeField] private Image image;
	[SerializeField] private Text description;

	public void SetName(string name)
	{
		this.name.text = name;
	}

	public void SetDescription(string description)
	{
		this.description.text = description;
	}
}

