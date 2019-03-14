using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    public delegate void DangerLevelDelegate(GameObject emitter, CharacterBase owner, float radiusOfDanger,
        float maxDamageAmount);

    public static event DangerLevelDelegate OnDanger;

    /// Be careful with this, because EVERYONE will receive it and need to do expensive checks etc. Probably ping it every x seconds using a Coroutine, instead on in Update
    public static void OnDangerInvoke(GameObject emitter, CharacterBase owner, float radiusOfDanger, float maxDamageAmount)
    {
        OnDanger?.Invoke(emitter, owner, radiusOfDanger, maxDamageAmount);
    }
}
