using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogInAction : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] private TMP_InputField _inputUsername;
    [SerializeField] private TMP_InputField _inputCorreu;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private TMP_Text _confirmacio;

    private void Awake()
    {
        _confirmButton.onClick.AddListener(OnSubmitClicked);
    }

    private void OnSubmitClicked()
    {
        string user = _inputUsername.text;
        string pass = _inputCorreu.text;
        bool arroba = _inputCorreu.text.Contains("@");

        if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(user))
        {
            _confirmacio.text = "Error: Usuari o correu no introduit";
            return;
        } else if (arroba == false)
        {
            _confirmacio.text = "Error: Correu no valid";
        }

        _confirmacio.text = "Log In Correcte!";
        
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
