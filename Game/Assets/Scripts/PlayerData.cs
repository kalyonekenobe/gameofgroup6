using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int startGold;
    public int currentGold;
    public int startHealth;
    public int currentHealth;

    public void AddGold(int gold)
    {
        currentGold += gold;
    }

    public void RemoveGold(int gold)
    {
        currentGold -= gold;
    }

    public void RemoveHealth(int health)
    {
        currentHealth -= health;
    }

    public int GetGold()
    {
        return currentGold;
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
