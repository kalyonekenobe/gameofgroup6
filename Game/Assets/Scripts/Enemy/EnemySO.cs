using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyType", menuName = "SO/EnemyData")]
public class EnemySO : ScriptableObject
{
    public float moveSpeed;
    public float rotationSpeed;
    public int lives;
    public int coinsForEnemy;
    public int damage;

    public int GetHealth()
    {
        return lives;
    }
}
