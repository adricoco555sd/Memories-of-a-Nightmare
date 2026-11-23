using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMinigameMS : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Level");
        }
    }
}
