using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectileDamage;
    public bool isPlayer;
    public float projectile_lifespan = 1;

    private void Start()
    {
        Destroy(this.gameObject, projectile_lifespan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Enemy" && isPlayer == true) || (collision.gameObject.tag == "Player" && isPlayer == false))
        {
            collision.gameObject.GetComponent<EntityStats>().RemoveHP(projectileDamage);
            Destroy(this.gameObject);
        }else if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

}
