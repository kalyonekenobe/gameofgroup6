using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerType", menuName = "SO/TowerData")]
public class TowerTypeSO : ScriptableObject 
{
    public float coolDown;
    public float range;
    public int cost;
    public int hit;
    [SerializeField]
    public GameObject projectile;
}
