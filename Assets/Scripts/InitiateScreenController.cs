using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateScreenController : MonoBehaviour
{
    private byte transparencia;
    public SpriteRenderer image;

    void Start()
    {
        transparencia = 0;
    }

    void FixedUpdate()
    {
        if (transparencia < 250)
        {
            transparencia += 10;
            image.color = new Color32(255, 255, 255, transparencia);
        }
        else
        {
            SceneManager.LoadScene("LoginScreen");
        }
    }
}

