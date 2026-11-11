using UnityEngine;

namespace CEVideojocs.Bloc2
{
    /// <summary>
    /// Contenidor de configuració global de xarxa mitjançant ScriptableObject.
    /// Registra la seva URL en una variable estàtica automàticament.
    /// IMPORTANT: l'asset ha d'estar dins d'una carpeta "Resources" (Assets/Resources/NetworkConfig.asset)
    /// perquè també es carregui en una build (vegeu APIService.Awake).
    /// </summary>
    [CreateAssetMenu(fileName = "NetworkConfig", menuName = "CyberAuth/Network Config")]
    public class NetworkConfig : ScriptableObject
    {
        [Header("Servidor API REST")]
        [Tooltip("URL base per a les peticions HTTP (Beeceptor, MockAPI o servidor real).")]
        [SerializeField] private string _baseUrl = "https://cyberauth-demo.free.beeceptor.com";

        /// <summary>
        /// Propietat estàtica accessible globalment des de qualsevol script C#.
        /// </summary>
        public static string BaseUrl { get; private set; }

        private void OnEnable()
        {
            BaseUrl = _baseUrl;
        }

        private void OnValidate()
        {
            BaseUrl = _baseUrl;
        }
    }
}
