using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings -1 ) { Application.Quit(); return; }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public static void Quit()
    {
        Application.Quit(); return; 
    }

    public static void LoadPrevScene()
    {
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0) return;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}
