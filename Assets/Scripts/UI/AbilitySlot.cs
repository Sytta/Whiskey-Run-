using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
	[SerializeField] public int slotId;
	[SerializeField] private Image background;
	[SerializeField] private Image fill;

	public void SetImage(Sprite image)
	{
		background.sprite = image;
		fill.sprite = image;
	}
}

