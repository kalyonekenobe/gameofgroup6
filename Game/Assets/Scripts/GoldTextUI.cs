using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldTextUI : MonoBehaviour
{
    private Player player;
    private TextMeshProUGUI textMeshPro;
    private int gold;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        gold = player.GetGold();
        textMeshPro.text = $"Gold: {gold}";
    }

    // Update is called once per frame
    void Update()
    {

       
        if (gold!=player.GetGold())
        {
            gold = player.GetGold();
            textMeshPro.text = $"Gold: {gold}";
        }  
    }
}
