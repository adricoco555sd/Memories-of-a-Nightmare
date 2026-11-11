using CEVideojocs.Bloc2;
using UnityEngine;

// Versió adaptada: si el jugador ja s'ha identificat (per exemple en tornar des de GameOver),
// salta el login i va directament al menú principal.
public class OnStart : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject logIn;

    private void Awake()
    {
        Apply();
    }

    private void Start()
    {
        Apply();
    }

    private void Apply()
    {
        bool loggedIn = PlayerData.Current != null;
        mainMenu.SetActive(loggedIn);
        logIn.SetActive(!loggedIn);
    }
}
