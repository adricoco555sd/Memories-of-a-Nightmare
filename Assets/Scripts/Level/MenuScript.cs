using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject canvasObject;
    public void onMenuButtonClicked() {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    
    public void onQuitButtonClicked() {
            Application.Quit();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (!canvasObject.activeInHierarchy)
            {
                canvasObject.SetActive(true);
            }
            else
            {
                canvasObject.SetActive(false);
            }
        }
    }
}
