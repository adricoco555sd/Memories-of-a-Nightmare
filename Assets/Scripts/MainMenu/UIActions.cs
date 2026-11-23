using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class UIActions : MonoBehaviour
    {
        public void onPlayButtonClicked() {
            SceneManager.LoadSceneAsync("MinigameSelection");
        }
    }
}
