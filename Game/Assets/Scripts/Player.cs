using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerData playerData;

    private int currentGold;
    private int currentHealth;
    private bool IsAvailable = true;
    [SerializeField]
    private int increaser = 15;
    private float CooldownDuration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentGold = playerData.startGold;
        playerData.currentGold = playerData.startGold;
        currentHealth = playerData.startHealth;
        playerData.currentHealth = playerData.startHealth;
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
        playerData.AddGold(increaser);
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }

    // Update is called once per frame
    void Update()
    {
        AddGoldSystem();
        currentGold = playerData.currentGold;
        currentHealth = playerData.currentHealth;
    }

}
