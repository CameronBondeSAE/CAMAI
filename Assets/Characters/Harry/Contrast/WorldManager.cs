using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    public static bool Paused = false;

    public float fadeDelay;
    public float fadeSpeed;
    
    public CanvasGroup fade;

    private void Awake()
    {
        Paused = false;
       
        fade.alpha = 1;

        StartCoroutine(Fade(fade, 0, 0.7f));
    }

    private IEnumerator Fade(CanvasGroup c, float FadeTo, float speedMod)
    {
        while (c.alpha != FadeTo)
        {
            yield return new WaitForSecondsRealtime(fadeDelay);

            c.alpha = Mathf.Lerp(c.alpha, FadeTo, fadeSpeed * speedMod);

            if (Mathf.Abs(c.alpha - FadeTo) < 0.03f) c.alpha = FadeTo;
        }
    }
    
}
