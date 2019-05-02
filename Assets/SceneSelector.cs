using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
//    public Object[] scenes;

//    private string nextButton = "Load Next Scene";
//    private string nextScene;
//    private static bool created = false;

//    private Rect buttonRect;
//    private int width, height;
    private int nextSceneIndex;

//    BuildPlayerOptions b;
    
    void Awake()
    {
        
        Debug.Log("Scene swapper awake:" + SceneManager.GetActiveScene().name);

        // Ensure the script is not deleted while loading.
//        if (!created)
//        {
//            DontDestroyOnLoad(this.gameObject);
//            created = true;
//        }
//        else
//        {
//            Destroy(this.gameObject);
//        }

        // Specify the items for each scene.
//        Camera.main.clearFlags = CameraClearFlags.SolidColor;
//        width = Screen.width / 4;
//        height = Screen.height / 4;
//        buttonRect = new Rect(width / 8, height / 3, 3 * width / 4, height / 3);
        
//        BuildPipeline.BuildPlayer(b);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            LoadNextScene();
        }
    }


    public void LoadNextScene()
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene scene = SceneManager.GetActiveScene();

        nextSceneIndex = scene.buildIndex + 1;
        if (nextSceneIndex >= EditorBuildSettings.scenes.Length)
        {
            nextSceneIndex = 0;
        }

        // Check if the name of the current Active Scene is your first Scene.
//        nextButton = "Load Next Scene";

        SceneManager.LoadScene(nextSceneIndex);
    }
}