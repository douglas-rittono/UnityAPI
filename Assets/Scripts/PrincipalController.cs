using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincipalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Logoff()
    {
        PlayerPrefs.DeleteKey(Resource.APIKey);
        SceneManager.LoadScene(Resource.Screen.Login);
    }
}
