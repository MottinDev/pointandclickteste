using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCena3 : MonoBehaviour
{
    public void esquerda()
    {
        SceneManager.LoadScene("cena2");
    }
    public void direita()
    {
        SceneManager.LoadScene("cena4");
    }
}
    
