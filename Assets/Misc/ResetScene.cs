using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ResetScene : MonoBehaviour
{
    public float resetTime = 180;
    public float originalResetTime = 180;
    SceneSelector sceneSelector;

    // Use this for initialization
    void Awake()
    {
        sceneSelector = FindObjectOfType<SceneSelector>();
        originalResetTime = resetTime;

        SceneManager.activeSceneChanged += delegate(Scene sceneOriginal, Scene sceneNew)
        {
            StopAllCoroutines();
            StartCoroutine(ResetOnNewScene());
        };

//        ResetOnNewScene();
    }

    private void Update()
    {
        // If user is messing with the mouse, don't auto change
        if (Input.GetAxisRaw("Mouse X") > 0)
        {
            StopAllCoroutines();
            StartCoroutine(ResetOnNewScene());
        }
    }

    private IEnumerator ResetOnNewScene()
    {
        // Scenes can add this component to customise the reset time
        SceneTimingOverride sceneTimingOverride = FindObjectOfType<SceneTimingOverride>();
        if (sceneTimingOverride != null)
        {
            resetTime = sceneTimingOverride.timeToNextScene;
        }
        else
        {
            resetTime = originalResetTime;
        }

        while (true)
        {
            Debug.Log("Waiting for : " + resetTime);
            yield return new WaitForSeconds(resetTime);
            NextScene();
        }
    }

    void NextScene()
    {
        if (sceneSelector != null) sceneSelector.LoadNextScene();
    }
}