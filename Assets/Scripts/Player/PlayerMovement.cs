using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    EntityStats entity_stats;
    private float boostSpeed;
    Animator animator_;

    private void Start()
    {
        entity_stats = GetComponent<EntityStats>();
        boostSpeed = entity_stats.base_speed;
        animator_ = gameObject.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        WASDmove();
    }

    void WASDmove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().AddForce(new Vector2(horizontal * entity_stats.base_speed * Time.fixedDeltaTime, vertical * entity_stats.base_speed * Time.deltaTime));

        if((horizontal > 0 || horizontal < 0) && ( vertical > 0 || vertical < 0))
        {
            boostSpeed *= 0.66f;
        }else
        {
            boostSpeed = entity_stats.base_speed;
        }
        
        
        if(horizontal > 0 || horizontal < 0 ||  vertical > 0 || vertical < 0)
        {
            if(horizontal < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

            }
            animator_.Play("Move");
        }else
        {
            animator_.Play("player_idle");
        }
    }
}
