using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject target_object;
    public List<Transform> boundaries;
    Vector3 target_transform;

    GameObject player_object;


    private void Start()
    {
        player_object = GameObject.FindGameObjectWithTag("Player");
        target_object = player_object;
    }
    private void FixedUpdate()
    {
        if ((player_object.transform.position.x < boundaries[0].position.x || player_object.transform.position.x > boundaries[1].position.x) && (player_object.transform.position.y < boundaries[2].position.y || player_object.transform.position.y > boundaries[3].position.y))
        {
            target_transform = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        }
        else if (player_object.transform.position.x < boundaries[0].position.x || player_object.transform.position.x > boundaries[1].position.x)
        {
            target_transform = new Vector3(gameObject.transform.position.x, target_object.transform.position.y, -10);
        }
        else if(player_object.transform.position.y < boundaries[2].position.y || player_object.transform.position.y > boundaries[3].position.y)
        {
            target_transform = new Vector3(target_object.transform.position.x, gameObject.transform.position.y, -10);
        }
        else
        {
            target_transform = new Vector3(target_object.transform.position.x, target_object.transform.position.y, -10);
        }

        transform.position = Vector3.Lerp(this.transform.position, new Vector3(target_transform.x, target_transform.y, -10), 5f * Time.fixedDeltaTime);

    }
}
