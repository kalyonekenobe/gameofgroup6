using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "SO/WaveData")]
public class WaveSO : ScriptableObject
{
    public int quantityOfEnemies;
    public float frequency;
    public float waitAfterWave;
    public GameObject enemyEasy;
}
