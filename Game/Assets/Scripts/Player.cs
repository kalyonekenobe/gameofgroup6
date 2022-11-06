using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int startGold;

    private int currentGold;

    // Start is called before the first frame update
    void Start()
    {
        currentGold = startGold;
    }

    public void AddGold(int gold)
    {
        currentGold += gold;
    }

    public void RemoveGold(int gold)
    {
        currentGold -= gold;
    }

    public int GetGold()
    {
        return currentGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
