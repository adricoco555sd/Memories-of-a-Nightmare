using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMinigame : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadSceneAsync("Minesweeper");
    }
}
