using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMinigame : MonoBehaviour
{
    private void OnMouseDown()
    {
        string scene = MinigameSelection.MinigameSelection.SceneName(MinigameSelection.MinigameSelection.Selected);
        if (scene != null)
            SceneManager.LoadScene(scene);
    }
}