using CEVideojocs.Bloc2;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Versió adaptada: manté els camps que ja tens assignats a l'escena MainMenu
// (mainMenu, _inputCorreu, _confirmButton, _confirmacio) i afegeix _inputUsername.
public class LogInAction : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] private TMP_InputField _inputUsername; // NOU: assigna'l a l'Inspector
    [SerializeField] private TMP_InputField _inputCorreu;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private TMP_Text _confirmacio;

    private void Awake()
    {
        _confirmButton.onClick.AddListener(OnSubmitClicked);
    }

    private void OnSubmitClicked()
    {
        string username = _inputUsername.text.Trim();
        string email = _inputCorreu.text.Trim();

        // Validació local: camps obligatoris i correu amb '@'
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
        {
            _confirmacio.text = "Error: Omple tots els camps!";
            return;
        } else if (arroba == false)
        {
            _confirmacio.text = "Error: Correu no valid";
        }

        if (!email.Contains("@"))
        {
            _confirmacio.text = "Error: Correu introduït no vàlid";
            return;
        }

        _confirmButton.interactable = false;
        _confirmacio.text = $"Registrant {username}...";

        // POST /api/register
        APIService.Instance.Register(username, email, (ok, response) =>
        {
            _confirmButton.interactable = true;

            if (!ok)
            {
                _confirmacio.text = $"Error de xarxa: {response}";
                return;
            }

            // Model en memòria (estàtic: sobreviu als canvis d'escena)
            PlayerData.Current = new PlayerData { Username = username, Email = email };
            PlayerData.ResetScore();

            _confirmacio.text = "Log In Correcte!";
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
        });
    }
}
