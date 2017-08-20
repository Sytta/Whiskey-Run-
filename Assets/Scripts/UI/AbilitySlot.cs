using System;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
	[HideInInspector] public int playerId;
	[SerializeField] public BaseAbilityComponent comp;
	[SerializeField] private Image background;
	[SerializeField] private Image fill;
	[SerializeField] private Text charge;

	public void SetComponent(BaseAbilityComponent comp)
	{
		this.comp = comp;
		SetInfo ();
	}

	private void SetInfo()
	{
		this.background.sprite = comp.Ability.Image;
		this.fill.sprite = comp.Ability.Image;
	}

	void Update()
	{
		if (comp == null)
			return;

		UpdateCharges ();
		this.fill.fillAmount = (comp.Ability.CoolDown - comp.currentCoolDownTimer) / comp.Ability.CoolDown;
	}

	void UpdateCharges()
	{
		if (comp.Ability.Consumable)
		{
			this.charge.text = GameManager.instance.players [playerId].Abilities [comp.Ability.Id].ToString ();
		}
		else
		{
			this.charge.text = "∞";
		}
	}
}

