using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverAction : MonoBehaviour
{
    [SerializeField] private Button _confirmButton;

    private void Awake()
    {
        _confirmButton.onClick.AddListener(OnLoginClicked);
    }
    
    private void OnLoginClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    
}
