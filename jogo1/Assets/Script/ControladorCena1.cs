using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCena1 : MonoBehaviour
{
    public void direita()
    {
       SceneManager.LoadScene("cena2");
    }
}
