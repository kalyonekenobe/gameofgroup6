using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour 
{

    [SerializeField]
    private int quantityOfEnemies;

    [SerializeField]
    private float frequency;

    [SerializeField]
    private float waitAfterWave;

    [SerializeField]
    private List<GameObject> points;

    [SerializeField]
    private GameObject enemyEasy;


    public World world;
    public bool isLastWave = false;

    private bool isReadyToSpawn = true;
    private bool needToWait = true;


    private List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        enabled = false;
    }

    private void EnemySpawing()
    {
        if (isReadyToSpawn == false)
        {
            return;
        }
        StartCoroutine(StartSpawing());
    }

    public void SpawnEnemy()
    {
        quantityOfEnemies--;
        GameObject enemyEasyClone = Instantiate(enemyEasy);
        enemyEasyClone.transform.position = points[0].transform.position;
        enemyEasyClone.GetComponent<Enemy>().SetRoutePoints(points.ConvertAll<Vector2>(point => (Vector2)point.transform.position).ToArray());
        enemies.Add(enemyEasyClone);
    }

    private bool IsEnemiesDestroyed()
    {
        bool res = true;
        for (int i = 0; i < enemies.Count; i++)
        {
            res = res && (enemies[i] == null);
        }
        return res;
    }

    private IEnumerator StartSpawing()
    {
        isReadyToSpawn = false;
        SpawnEnemy();
        yield return new WaitForSeconds(frequency);
        isReadyToSpawn = true;
    }

    private IEnumerator WaitAfterWave()
    {
        yield return new WaitForSeconds(waitAfterWave);
        needToWait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (quantityOfEnemies != 0)
            EnemySpawing();
        else
        {
            if (IsEnemiesDestroyed())
            {
                if (!isLastWave)
                    StartCoroutine(WaitAfterWave());
                if (!needToWait)
                {
                    if (world != null)
                        world.OnDestroyWave();
                    Destroy(gameObject);
                }
               
            }

           
        }
           
    }

}
