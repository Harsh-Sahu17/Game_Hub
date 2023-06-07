using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneloader1 : MonoBehaviour
{
    public void LoadNextScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+2);
    }

    public void LoadStartScene(){
        SceneManager.LoadScene(0);
    }
}