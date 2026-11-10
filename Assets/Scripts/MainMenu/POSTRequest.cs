using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class POSTRequest : MonoBehaviour
{
    private IEnumerator PostRequestCoroutine(string url, string jsonBody)
    {
        using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonBody);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Dades enviades correctament!");
            }
            else
            {
                Debug.LogError("Error en enviar dades POST: " + webRequest.error);
            }
        }
    }
}
