using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCena2 : MonoBehaviour
{
    public void esquerda ()
    {
        SceneManager.LoadScene("cena1");
    }        
    public void direita ()
    {
        SceneManager.LoadScene("cena3");
    }
}
