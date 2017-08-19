using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : MonoBehaviour {

    float cost;

    void OnSetup() { }

    void Use(Vector3 direction) { }

    bool IsReady() { return false; }

    float GetCoolDown() { return 0.0f; }
}
