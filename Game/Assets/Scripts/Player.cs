using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int startGold;
    [SerializeField]
    private TextMeshProUGUI goldUIText;

    private int currentGold;

    // Start is called before the first frame update
    void Start()
    {
        currentGold = startGold;
        goldUIText.text = $"Gold: {currentGold}";
    }

    void AddGold(int gold)
    {
        currentGold += gold;
    }

    void RemoveGold(int gold)
    {
        currentGold -= gold;
    }

    int GetGold()
    {
        return currentGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
