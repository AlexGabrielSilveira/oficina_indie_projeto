using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject TriggerPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            if (Camera.main.GetComponent<PlayerCamera>().target_object == collision.gameObject)
            {
                Camera.main.GetComponent<PlayerCamera>().target_object = TriggerPosition;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Camera.main.GetComponent<PlayerCamera>().target_object = collision.gameObject;
        }
    }
}
