using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    GameObject playerObject;
    EntityStats entity_stats;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        entity_stats = GetComponent<EntityStats>();
    }
    private void FixedUpdate()
    {
        followPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EntityStats>().RemoveHP(entity_stats.attack_damage);
            entity_stats.hp -= entity_stats.max_hp;
        }
    }

    void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, entity_stats.base_speed * Time.deltaTime);
    }
}
