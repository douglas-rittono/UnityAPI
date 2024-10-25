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
        Debug.Log("Passou aqui");
        string jsondata = JsonUtility.ToJson(login);
        using (UnityWebRequest request = UnityWebRequest.Post("localhost:3001/users/users/login", "POST"))
        {
            request.method = UnityWebRequest.kHttpVerbPOST;
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Accept", "application/json");
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsondata));

            Debug.Log("FAzendo request");

            yield return request.SendWebRequest();
            Debug.Log(request.result);

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

