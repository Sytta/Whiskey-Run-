using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	[SerializeField] private Text itemName;
	[SerializeField] private Text description;
	[SerializeField] private Text cost;
	[SerializeField] private Image image;
	[SerializeField] private Image selectedImg;
	[SerializeField] private Image controls;
	[SerializeField] private GameObject locked;

	public void SetInfo(string name, string desc, int cost, Sprite image,
		Sprite controls, bool locked)
	{
		SetName (name);
		SetDescription (desc);
		SetCost (cost);
		SetImage (image);
		SetControls (controls);

		ToggleLock (locked);
	}

	public void SetName(string name)
	{
		this.itemName.text = name;
	}

	public void SetDescription(string description)
	{
		this.description.text = description;
	}

	public void SetCost(int cost)
	{
		this.cost.text = cost + "$";
	}

	public void SetImage(Sprite image)
	{
		this.image.sprite = image;
	}

	public void SetControls(Sprite image)
	{
		if (image == null)
		{
			this.controls.gameObject.SetActive (false);
			return;
		}

		this.controls.sprite = image;
	}

	public void ToggleLock(bool enable)
	{
		locked.SetActive (enable);
	}

	public void EnableSelected()
	{
		selectedImg.gameObject.SetActive (true);
	}

	public void DisableSelected()
	{
		selectedImg.gameObject.SetActive (false);
	}
}

