using UnityEngine;
using UnityEngine.SceneManagement;

public class UIActions : MonoBehaviour
{
    public void onPlayButtonClicked() {
        SceneManager.LoadSceneAsync("Level");
    }
}
