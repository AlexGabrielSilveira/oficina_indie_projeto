using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Text itemNameHolder;
    public Text itemPriceHolder;
    public Text itemStatsHolder;
    public Image itemIconHolder;
    public Weapon weapon_;
    public Button shopButton;

    private void Update()
    {
        SetUp(weapon_);
    }
    public void SetUp(Weapon weapon) 
    {
        itemNameHolder.text = weapon.weapon_name;
        itemPriceHolder.text = weapon.weapon_value.ToString();
        itemIconHolder.sprite = weapon.wepon_icon;
        itemStatsHolder.text = "Attack Damage:" + weapon.weapon_damage.ToString() + "\r\nAttack Speed:" + weapon.weapon_speed.ToString() + " \r\nRange:" + weapon.weapon_life.ToString();

        var gold = InventoryManager.Instance.gold_coins;

        if (gold < weapon.weapon_value)
        {
            shopButton.interactable = false;
        }
        else
        {
            shopButton.interactable = true;
        }
    }

    public void BuyWeapon()
    {
        var invManager = InventoryManager.Instance;
        if (invManager.inventory_[4] != null)
        {
            
        }

        for (int i = 0; i < 5; i++)
        {
            if(invManager.inventory_[i] == null)
            {
                invManager.inventory_[i] = weapon_;
                break;
            }
        }

        invManager.AddGoldCoins(weapon_.weapon_value * -1);
        Destroy(this.gameObject);
    }

}
