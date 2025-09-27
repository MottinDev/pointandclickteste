using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour
{
    public static Inventario instance;
    public static Action OnInventoryChanged;
    public List<Item> itens = new List<Item>();

    public static List<string> idsItensColetados = new List<string>();

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
            itens.Clear();
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void Add(Item item)
    {
        itens.Add(item);
        Debug.Log(item.nameItem + " adicionado à lista de dados!");
        OnInventoryChanged?.Invoke();
    }

    public void Remove(Item item)
    {
        if (itens.Contains(item)) 
        {
            itens.Remove(item);
            Debug.Log(item.nameItem + " removido!");
            OnInventoryChanged?.Invoke();
        }
        
    }

}

