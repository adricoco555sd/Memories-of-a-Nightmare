using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace CEVideojocs.Bloc2
{
<<<<<<< HEAD
=======
    /// <summary>
    /// Servei de xarxa modular. Tota la URL surt de NetworkConfig.BaseUrl.
    /// Es crea sol la primera vegada que s'usa i sobreviu als canvis d'escena,
    /// així no cal posar-lo a cap escena (MainMenu i GameOver el poden fer servir igual).
    /// </summary>
>>>>>>> b089e2be8eefde8088cba292cbec003b3ffa5022
    public class APIService : MonoBehaviour
    {
        private static APIService _instance;

        public static APIService Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("APIService");
                    _instance = go.AddComponent<APIService>();
                    DontDestroyOnLoad(go);
<<<<<<< HEAD
                    
=======

                    // Força la càrrega de l'asset perquè NetworkConfig.BaseUrl quedi assignada (també en build).
>>>>>>> b089e2be8eefde8088cba292cbec003b3ffa5022
                    if (string.IsNullOrEmpty(NetworkConfig.BaseUrl))
                    {
                        Resources.Load<NetworkConfig>("NetworkConfig");
                    }
                }
                return _instance;
            }
        }

        private static string BuildUrl(string path)
        {
            string baseUrl = (NetworkConfig.BaseUrl ?? string.Empty).TrimEnd('/');
            return $"{baseUrl}{path}";
        }

        /// <summary>POST /api/register amb username + email.</summary>
        public void Register(string username, string email, Action<bool, string> onDone)
        {
            string json = JsonConvert.SerializeObject(new RegisterRequestDTO
            {
                username = username,
                email = email
            });
            StartCoroutine(PostCoroutine(BuildUrl("/api/register"), json, onDone));
        }

        /// <summary>POST /api/scores amb email + score.</summary>
        public void SendScore(string email, int score, Action<bool, string> onDone)
        {
            string json = JsonConvert.SerializeObject(new ScoreRequestDTO
            {
                email = email,
                score = score
            });
            StartCoroutine(PostCoroutine(BuildUrl("/api/scores"), json, onDone));
        }

        /// <summary>GET /api/leaderboard i deserialitza la llista arrel.</summary>
        public void GetLeaderboard(Action<bool, List<LeaderboardEntryDTO>, string> onDone)
        {
            StartCoroutine(GetLeaderboardCoroutine(BuildUrl("/api/leaderboard"), onDone));
        }

        private IEnumerator PostCoroutine(string url, string jsonBody, Action<bool, string> onDone)
        {
            Debug.Log($"POST {url}\n{jsonBody}");

            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    onDone?.Invoke(true, request.downloadHandler.text);
                }
                else
                {
                    string error = $"[{request.responseCode}] {request.error}";
                    Debug.LogError($"Error POST {url}: {error}");
                    onDone?.Invoke(false, error);
                }
            }
        }

        private IEnumerator GetLeaderboardCoroutine(string url, Action<bool, List<LeaderboardEntryDTO>, string> onDone)
        {
            Debug.Log($"GET {url}");

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    string error = $"[{request.responseCode}] {request.error}";
                    Debug.LogError($"Error GET {url}: {error}");
                    onDone?.Invoke(false, null, error);
                    yield break;
                }

                try
                {
                    List<LeaderboardEntryDTO> list =
                        JsonConvert.DeserializeObject<List<LeaderboardEntryDTO>>(request.downloadHandler.text);
                    onDone?.Invoke(true, list ?? new List<LeaderboardEntryDTO>(), null);
                }
                catch (JsonException ex)
                {
                    Debug.LogError($"JSON invàlid: {ex.Message}");
                    onDone?.Invoke(false, null, "Resposta del servidor no vàlida.");
                }
            }
        }
    }
}
