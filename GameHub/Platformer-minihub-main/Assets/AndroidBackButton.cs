using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidBackButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the main menu scene asynchronously
            SceneManager.LoadSceneAsync("START");
        }
    }
}
