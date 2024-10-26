using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAccountController : MonoBehaviour
{
    public TMP_Text txtError;
    public TMP_InputField txtUsuario;
    public TMP_InputField txtSenha;
    public TMP_InputField txtConfirmaSenha;
    private IEnumerator coroutine;

    public void BackToLogin()
    {
        SceneManager.LoadScene(Resource.Screen.Login);
    }

    public void ExibiSenha(TMP_InputField txt)
    {
        if (txt.contentType == TMP_InputField.ContentType.Password)
        {
            txt.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            txt.contentType = TMP_InputField.ContentType.Password;
        }
        txt.Select();
        txt.ActivateInputField();
    }

    // Start is called before the first frame update
    void Start()
    {
        txtSenha.contentType = TMP_InputField.ContentType.Password;
        txtConfirmaSenha.contentType = TMP_InputField.ContentType.Password;
    }

    public void CreateAccount()
    {
        UserCreateRequest userCreateRequest = new UserCreateRequest
        {
            username = txtUsuario.text,
            password = txtSenha.text,
            confirmPassword = txtConfirmaSenha.text
        };

        var validation = userCreateRequest.Validate();

        if (string.IsNullOrEmpty(validation))
        {
            coroutine = NetworkService.CreateUser(userCreateRequest, txtError);
            StartCoroutine(coroutine);
        }
        else
        {
            txtError.text = validation;
        }
    }
}
