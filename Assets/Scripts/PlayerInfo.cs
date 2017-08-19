using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    string id;
    int money;
    // Key mapping for abilities
	Dictionary<Input, BaseAbilityComponent> abilitySelection;
    ArrayList crates;
}
