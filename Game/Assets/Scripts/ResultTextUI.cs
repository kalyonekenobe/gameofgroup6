using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTextUI : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private GameSystem gameSystem;
    private PlayerData player;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        player = GameObject.Find("Player").GetComponent<Player>().playerData;
        SetVisibility(false);
    }

    private bool IsTextVisible()
    {
        return textMeshPro.color.a != 0.0f;
    }

    private void SetVisibility(bool visibility)
    {
        Color color = textMeshPro.color;
        if (visibility)
        {
            color.a = 1f;
        } 
        else
        {
            color.a = 0f;
        }
        textMeshPro.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameSystem.IsResultDisplayed() && !IsTextVisible())
        {
            Debug.Log("Show Result");
            SetVisibility(true);
            if(player.currentHealth <=0 )
            {
                textMeshPro.text = "You lose";
                textMeshPro.color = Color.red;
            }
        }
    }
}
