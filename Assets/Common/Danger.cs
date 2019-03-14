using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public delegate void DangerLevelDelegate(GameObject emitter, CharacterBase owner, float radiusOfDanger,
        float maxDamageAmount);

    public static event DangerLevelDelegate OnDanger;

    public static void OnDangerInvoke(GameObject emitter, CharacterBase owner, float radiusOfDanger, float maxDamageAmount)
    {
        OnDanger?.Invoke(emitter, owner, radiusOfDanger, maxDamageAmount);
    }
}
