using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
 Source file Name - EnemyParent.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 24/10/2022 
 Program description: Basically it's manager for enemies, obstacles and coins.

 */
public class EnemyParent : MonoBehaviour
{
    [Range(1, 6)]
    [SerializeField] private int enemyNumber = 4;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject obstaclePrefab;
    public List<GameObject> enemies;



    void Start()
    {
        enemies = new List<GameObject>();
        StartCoroutine(CreateEnemies());
        StartCoroutine(CreateCoins());
        StartCoroutine(CreateObstacles());
    }

    private IEnumerator CreateEnemies()
    {
        while (true)
        {
           
                for (int i = 0; i < enemyNumber; i++)
                {
                    if(enemies.Count < enemyNumber)
                    {
                        enemies.Add(Instantiate(enemyPrefab));
                        enemies[i].transform.SetParent(transform);

                    }
                }

            yield return new WaitForSeconds(0.7f);
        }
       
    }

    private IEnumerator CreateCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            Instantiate(coinPrefab);

        }
    }
    private IEnumerator CreateObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            Instantiate(obstaclePrefab);

        }
    }

    public void DeleteEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
