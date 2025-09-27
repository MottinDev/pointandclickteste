using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemobj : MonoBehaviour
{
    public ItemData itemData;
    public string itemID;

    void Start()
    {
        if (Inventario.idsItensColetados.Contains(itemID))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D ativado pelo objeto: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Trigger entrou com: " + collision.name);
            Inventario.instance.Add(itemData.itemInfo);
            if (!Inventario.idsItensColetados.Contains(itemID))
            {
                Inventario.idsItensColetados.Add(itemID);
            }
            Destroy(gameObject);
        }
    }
}
