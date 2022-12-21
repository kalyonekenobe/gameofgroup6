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
    [SerializeField]
    private GameObject towerManager;

    private void OnMouseDown()
    {
        buildCost = towerManager.GetComponent<TowerManager>().currentTower.GetComponent<Tower>().GetCost();
        if (player.GetGold()>= buildCost && currentTower == null)
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
        currentTower = Instantiate(towerManager.GetComponent<TowerManager>().currentTower);
        currentTower.transform.position = transform.position;
        currentTower.transform.parent = transform;
        currentTower.transform.position += new Vector3(-0.05f, 0.5f, 0);//збільшив розміри і розташування башт,можна змінити
        currentTower.transform.localScale += new Vector3(0.7f, 0.6f, 0);
        currentTower.GetComponent<Tower>().Initialize();
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
