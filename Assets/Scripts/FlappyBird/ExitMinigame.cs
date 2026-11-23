using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMinigameFB : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Level");
        }
    }
}
