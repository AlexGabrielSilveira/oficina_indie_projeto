using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    public GameObject storeObject;
    public GameObject storeWarning;
    GameObject player;

    public List<Weapon> weapons_sold;
    public GameObject shop_bg;
    public GameObject shop_item;

    private void Start()
    {
        RandomItems();
        storeObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);
        if(dist < 2)
        {
            storeWarning.SetActive(true);
            if (Input.GetKey(KeyCode.E)) 
            {
                storeObject.SetActive(true);
            }
        }else
        { 
            storeWarning.SetActive(false); 
            storeObject.SetActive(false);
        }
    }
    void RandomItems()
    {
        for (int i = 0; i <= 3; i++) 
        {
            int randomNumber = Random.Range(0, weapons_sold.Count);
            GameObject new_shop_item = Instantiate(shop_item, shop_bg.transform);
            new_shop_item.GetComponent<ShopItem>().weapon_ = weapons_sold[randomNumber];
            new_shop_item.GetComponent<ShopItem>().SetUp(weapons_sold[randomNumber]);

        }

    }
}
