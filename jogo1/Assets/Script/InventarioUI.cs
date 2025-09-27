using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventarioUI : MonoBehaviour
{
    public static InventarioUI instance;
    public Transform slotsParent;
    private Image[] slotsImages;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Inventario.OnInventoryChanged += UpdateUI;

        if (slotsParent == null)
        {
            Debug.LogError("SlotsParent não atribuído no Inspector!");
            return;
        }

        // Inicializa o array com o número exato de filhos
        slotsImages = new Image[slotsParent.childCount];

        // Passa por cada filho, pega seu componente Image e o adiciona ao array
        for (int i = 0; i < slotsParent.childCount; i++)
        {
            slotsImages[i] = slotsParent.GetChild(i).GetComponent<Image>();
        }
        

        if (slotsImages.Length == 0)
        {
            Debug.LogError("Nenhum slot Image encontrado como filho de slotsParent!");
        }

        UpdateUI();
    }
    // Update is called once per frame
    /*void Update()
    {
        if (slotsImages != null && slotsImages.Length > 0)
            UpdateUI();
    }*/

    void OnDestroy() 
    {
        Inventario.OnInventoryChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        Debug.Log("--- INICIANDO REDESENHO DA UI ---");
        Debug.Log("Itens na lista de dados: " + Inventario.instance.itens.Count);
        Debug.Log("Slots na UI: " + slotsImages.Length);

        for (int i = 0; i < slotsImages.Length; i++)
        {
            if (i < Inventario.instance.itens.Count)
            {
                // Se existe um item para este slot
                Item currentItem = Inventario.instance.itens[i];
                Debug.Log("Slot " + i + ": Desenhando item '" + currentItem.nameItem + "'");

                if (currentItem != null && currentItem.icone != null)
                {
                    slotsImages[i].sprite = currentItem.icone;
                    slotsImages[i].color = Color.white;
                }
                else
                {
                    Debug.LogWarning("Slot " + i + ": O item ou seu ícone é nulo!");
                }
            }
            else
            {
                // Se não existe um item para este slot, limpa ele
                Debug.Log("Slot " + i + ": Limpando (sem item correspondente).");
                slotsImages[i].sprite = null;
                slotsImages[i].color = new Color(1, 1, 1, 0);
            }
        }
        Debug.Log("--- FIM DO REDESENHO DA UI ---");
    }
}

