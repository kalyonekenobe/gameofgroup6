using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceholder : MonoBehaviour
{
    [SerializeField]
    private GameObject towerToBuild;

    private int buildCost;
    private GameObject currentTower;

    [SerializeField]
    private PlayerData player;

    private void OnMouseDown()
    {
        if(player.GetGold()>= buildCost && currentTower == null)
        {
            BuildTower();
        } 
        else if (currentTower != null)
        {
            //Debug.Log("This place already has some tower");
        }
        else
        {
            //Debug.Log("Not enough gold");
        }
    }

    private void BuildTower()
    {
        player.RemoveGold(buildCost);
        currentTower = Instantiate(towerToBuild);
        currentTower.transform.position = transform.position;
        currentTower.transform.parent = transform;
        currentTower.GetComponent<Tower>().Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        //player = ScriptableObject.CreateInstance<PlayerData>();
        buildCost = towerToBuild.GetComponent<Tower>().GetCost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
