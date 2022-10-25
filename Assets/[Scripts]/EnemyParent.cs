using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [Range(1, 6)]
    [SerializeField] private int enemyNumber = 4;
    [SerializeField] private GameObject enemyPrefab;
    public List<GameObject> enemies;


    void Start()
    {
        enemies = new List<GameObject>();
        StartCoroutine(CreateEnemies());
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

    public void DeleteEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
