using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthTextUI : MonoBehaviour
{
    [SerializeField]
    private PlayerData player;  // REPLACE WITH SCRIPTAVBLE OBJ
    private TextMeshProUGUI textMeshPro;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        health = player.GetHealth();
        textMeshPro.text = $"Health: {health}";
    }

    // Update is called once per frame
    void Update()
    {
        if (health != player.GetHealth())
        {
            health = player.GetHealth();
            textMeshPro.text = $"Health: {health}";
        }
    }
}
