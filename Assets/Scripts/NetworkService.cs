using UnityEngine;
using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;
using System.Text;
using System.Collections;
using TMPro;
using Assets.Scripts.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using Assets.Scripts.Models;

public class NetworkService : MonoBehaviour
{
    void Start()
    {
    }

    public static IEnumerator Login(LoginRequest login, TMP_Text txtError)
    {
        string jsondata = JsonUtility.ToJson(login);
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm("localhost:3000/api/users/login", "POST"))
        {
            request.method = UnityWebRequest.kHttpVerbPOST;
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Accept", "application/json");
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsondata));

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            { 
                txtError.text = request.downloadHandler.text;
            }
            else
            {
                LoginResponse loginResponse = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);

                PlayerPrefs.SetString("APIKEY", JsonUtility.ToJson(loginResponse));

                SceneManager.LoadScene("PrincipalScreen");
            }
        }
    }
}

