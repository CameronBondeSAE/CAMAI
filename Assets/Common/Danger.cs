using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WARNING: Everything in this is STATIC. Use it by simply typing the CLASS name, then a dot.
// THERE IS ONLY EVER ONE OF THESE. You can't add more than one to the world.
public static class Danger
{
    // Didn't use the "Action<>" shortcut, because it doesn't allow naming of parameters.
    // Since we've got quite a few, I really want the names (I use Action when there's only 1 or 2 usually)
    public delegate void DangerLevelDelegate(GameObject emitter, CharacterBase owner, float radiusOfDanger,
        float maxDamageAmount);

    // Note: This is STATIC. So you don't even need to add the danger component
    public static event DangerLevelDelegate OnDanger;

    /// Be careful with this, because EVERYONE will receive it and need to do expensive checks etc. Probably ping it every x seconds using a Coroutine, instead on in Update
    public static void OnDangerInvoke(GameObject emitter, CharacterBase owner, float radiusOfDanger, float maxDamageAmount)
    {
        OnDanger?.Invoke(emitter, owner, radiusOfDanger, maxDamageAmount);
    }
}
