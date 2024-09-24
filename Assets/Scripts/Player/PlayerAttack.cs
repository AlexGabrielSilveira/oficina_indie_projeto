using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject _projectile;
    EntityStats entity_stats;
    float interval;
    bool canAttack = true;
    private void Start()
    {
        entity_stats = FindObjectOfType<EntityStats>();
    }
    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0) && canAttack == true)
        {
            GameObject projectileInstance = Instantiate(_projectile, transform.position, Quaternion.identity);

            projectileInstance.GetComponent<ProjectileDamage>().projectileDamage = entity_stats.attack_damage * (( entity_stats.bonusAtk + 100)/ 100);
            projectileInstance.GetComponent<ProjectileDamage>().projectile_lifespan = entity_stats.attack_life;

            Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            direction.Normalize();

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(direction * entity_stats.attack_range, ForceMode2D.Impulse);

            canAttack = false;
            interval = 0;
        }
        Cooldown();

    }

    void Cooldown()
    {
        if (interval > (entity_stats.attack_speed * ((100 - entity_stats.bonusAtkSpeed)/100)) && canAttack == false) 
        {
            canAttack = true;
        }
        else {
            interval += Time.deltaTime;
        }
    }
}
