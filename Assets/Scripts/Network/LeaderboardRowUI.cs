using TMPro;
using UnityEngine;

namespace CEVideojocs.Bloc2
{
    /// <summary>Script del prefab d'una fila de la taula de classificació.</summary>
    public class LeaderboardRowUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _positionText;
        [SerializeField] private TextMeshProUGUI _usernameText;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Color _highlightColor = Color.yellow;

        public void Setup(int position, string username, int score, bool highlight)
        {
            _positionText.text = $"#{position}";
            _usernameText.text = username;
            _scoreText.text = score.ToString();

            if (highlight)
            {
                _positionText.color = _highlightColor;
                _usernameText.color = _highlightColor;
                _scoreText.color = _highlightColor;
            }
        }
    }
}
