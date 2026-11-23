using MinigameSelection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MinigameOption : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Minigame minigame;
    [SerializeField] private string levelSceneName = "Level";

    public void OnPointerClick(PointerEventData eventData)
    {
        MinigameSelection.MinigameSelection.Selected = minigame;
        SceneManager.LoadScene(levelSceneName);
    }
}