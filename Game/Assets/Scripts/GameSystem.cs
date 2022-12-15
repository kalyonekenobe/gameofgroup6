using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private World world;
    private PlayerData player;
    private bool isResultDisplayed = false;

    public bool IsResultDisplayed()
    {
        return isResultDisplayed;
    }

    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.Find("World").GetComponent<World>();
        player = GameObject.Find("Player").GetComponent<Player>().playerData;
    }

    // Update is called once per frame
    void Update()
    {
        if((player.currentHealth <= 0 || world.IsInvasionOver())&&!isResultDisplayed)
        {
            isResultDisplayed = true;
            Debug.Log("It's over");
        }
    }
}
