using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacingUI : MonoBehaviour
{
	[SerializeField] private List<AbilitySlot> abilitiesPlayer1; 

	public void ToggleUI(bool enable)
	{
		this.gameObject.SetActive (enable);
	}

	public void SetUp()
	{
		for (int i = 0; i < abilitiesPlayer1.Count; i++)
		{
			if (GameManager.instance.players [0].abilitiesInputMapping.ContainsKey (abilitiesPlayer1 [i].slotId))
			{
				//BaseAbilityComponent comp = GameManager.instance.players [0].
				//abilitiesPlayer1[i].SetComponent(comp);
			}
		}
	}
}

