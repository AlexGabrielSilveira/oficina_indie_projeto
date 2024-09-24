using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    public GameObject _projectile;
    public GameObject player_obj;

    EntityStats entity_stats;
    bool canAttack = true;
    float _cooldown;
    float interval;

    private void Start()
    {
        entity_stats = gameObject.GetComponent<EntityStats>();
        player_obj = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (canAttack == true)
        {
            GameObject projectileInstance = Instantiate(_projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = entity_stats.attack_damage;
            projectileInstance.GetComponent<ProjectileDamage>().projectile_lifespan = entity_stats.attack_life;
            

            Vector3 direction =  player_obj.transform.position - transform.position;
            direction.Normalize();

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(direction * entity_stats.attack_range, ForceMode2D.Impulse);

            canAttack = false;
            interval = 0;
        }
        Cooldown();

    }

    void Cooldown()
    {
        if (interval > entity_stats.attack_speed && canAttack == false)
        {
            canAttack = true;
        }
        else
        {
            interval += Time.deltaTime;
        }
    }
}

