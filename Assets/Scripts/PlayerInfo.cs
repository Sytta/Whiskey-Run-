using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    string id;
    int money;
    // Key mapping for abilities
    Dictionary<BaseAbility, Input> abilitySelection;
    ArrayList crates;
}
