using System.Collections.Generic;
using CEVideojocs.Bloc2;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

// Versió adaptada: el botó que ja tens a l'escena (_confirmButton) passa a ser "Menú principal"
// (FormerlySerializedAs conserva la referència). Cal afegir un segon botó per a "Reiniciar".
public class GameOverAction : MonoBehaviour
{
    [FormerlySerializedAs("_confirmButton")]
    [SerializeField] private Button _menuButton;

    [SerializeField] private TMP_Text _scoreText;   // l'objecte "Puntuacio"
    [SerializeField] private TMP_Text _statusText;  // text nou per a missatges d'estat

    [Header("Leaderboard")]
    [SerializeField] private Transform _content;    // Content del Scroll View
    [SerializeField] private LeaderboardRowUI _rowPrefab;

    private void Awake()
    {
        _menuButton.onClick.AddListener(OnMenuClicked);
    }

    private void Start()
    {
        ClearRows();

        int score = PlayerData.Score;
        _scoreText.text = $"Puntuació: {score}";

        PlayerData player = PlayerData.Current;
        if (player == null)
        {
            _statusText.text = "Error: no hi ha cap jugador identificat (comença des de MainMenu).";
            return;
        }

        _statusText.text = "Enviant puntuació...";

        // 1) POST /api/scores  ->  2) GET /api/leaderboard
        APIService.Instance.SendScore(player.Email, score, (ok, response) =>
        {
            _statusText.text = ok
                ? "Descarregant classificació..."
                : $"No s'ha pogut enviar la puntuació: {response}";

            APIService.Instance.GetLeaderboard(OnLeaderboardReceived);
        });
    }

    private void OnLeaderboardReceived(bool ok, List<LeaderboardEntryDTO> entries, string error)
    {
        if (!ok)
        {
            _statusText.text = $"Error en descarregar la classificació: {error}";
            return;
        }

        _statusText.text = string.Empty;
        string myEmail = PlayerData.Current?.Email;

        entries.Sort((a, b) => b.score.CompareTo(a.score));

        for (int i = 0; i < entries.Count; i++)
        {
            LeaderboardRowUI row = Instantiate(_rowPrefab, _content);
            bool isMe = !string.IsNullOrEmpty(myEmail) && entries[i].email == myEmail;
            row.Setup(i + 1, entries[i].username, entries[i].score, isMe);
        }
    }
    
    private void OnMenuClicked()
    {
        PlayerData.ResetScore();
        SceneManager.LoadSceneAsync("MainMenu");
    }

    private void ClearRows()
    {
        for (int i = _content.childCount - 1; i >= 0; i--)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
