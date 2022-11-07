using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int startGold;
    [SerializeField]
    private int increaser = 5;

    private int currentGold;
    private bool IsAvailable = true;
    private float CooldownDuration = 1.0f;

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


    void AddGoldSystem()
    {
        if (IsAvailable == false)
        {
            return;
        }
        StartCoroutine(StartCooldown());
    }

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        AddGold(increaser);
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        AddGoldSystem();
    }

}
