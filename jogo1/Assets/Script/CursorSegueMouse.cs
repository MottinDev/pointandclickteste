using UnityEngine;
using UnityEngine.InputSystem;

public class CursorSegueMouse : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Pega a posição do mouse na tela
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();

        // Converte a posição da tela para a posição no mundo do jogo
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));

        // Mantém o Z em 0 para garantir que está no plano 2D
        mouseWorldPosition.z = 0f;

        // Move este objeto (o CursorFisico) para a posição do mouse
        transform.position = mouseWorldPosition;
    }
}