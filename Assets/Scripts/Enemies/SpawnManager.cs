using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject door_;

    public List<GameObject> spawnPoints;
    public List<GameObject> enemies;
    public int enemiesAlive;
    bool dungeonActive;

    private void Update()
    {
        CheckDungeonEnd();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            door_.SetActive(true);
            SpawnEnemies();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dungeonActive = true;
        }
    }
    void SpawnEnemies()
    {
        foreach (GameObject point in spawnPoints)
        {
            var randomEnemy = Random.Range(0, enemies.Count);
            var instantiateEnemy = Instantiate(enemies[randomEnemy], point.transform.position, Quaternion.identity);
            instantiateEnemy.GetComponent<EntityStats>().spawnManager = this;
            enemiesAlive++;
        }
    }
    void CheckDungeonEnd()
    {
        if (dungeonActive == true)
        {
            if(enemiesAlive == 0)
            {
                door_.SetActive(false);
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        
    }
}