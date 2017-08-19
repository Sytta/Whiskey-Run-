using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
	[SerializeField] public string slotId;
	[SerializeField] private Image background;
	[SerializeField] private Image fill;

	private BaseAbilityComponent abilityComponent;

	public void SetImage(Sprite image)
	{
		background.sprite = image;
		fill.sprite = image;
	}

	public void UpdateFill(float fillAmount)
	{
		fill.fillAmount = fillAmount;
	}

	public void SetComponent(BaseAbilityComponent comp)
	{
		abilityComponent = comp;
	}
}

