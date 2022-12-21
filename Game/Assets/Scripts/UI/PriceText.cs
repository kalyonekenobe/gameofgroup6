using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceText : MonoBehaviour
{
    [SerializeField]
    private GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = tower.GetComponent<Tower>().towerType.cost.ToString();
    }
}
