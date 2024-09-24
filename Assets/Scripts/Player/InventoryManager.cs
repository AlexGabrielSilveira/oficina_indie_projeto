using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public GameObject inv_background;
    public GameObject inv_slot;

    public List<Weapon> inventory_;
    EntityStats playerStats;
    int selected_slot = 0;
    int active_slot = 0;

    //gold
    public float gold_coins;
    public Text gold_text;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        playerStats = FindFirstObjectByType<EntityStats>();
        gold_text.text = gold_coins.ToString();
        SelectWeapon(1);
    }
    private void Update()
    {
        InventorySelector();

        if (Input.GetKeyDown(KeyCode.G))
        {
            InventoryManager.Instance.DiscardWeapon();
        }
    }

    void RefreshInventory()
    {

        gold_text.text = gold_coins.ToString();
        GameObject[] destroySolts = GameObject.FindGameObjectsWithTag("Slot");

        foreach (GameObject gameObject in destroySolts) { Destroy(gameObject); }
        int hotkey_ = 1;
        foreach (Weapon weapon in inventory_) 
        {
            GameObject slotInstance = Instantiate(inv_slot, inv_background.transform);

            if(weapon == null)
            {
                slotInstance.GetComponentInChildren<Image>().enabled = false;
            }
            else
            {
                slotInstance.GetComponentInChildren<Image>().enabled = true;
                slotInstance.GetComponentInChildren<Image>().sprite = weapon.wepon_icon;

                slotInstance.GetComponentInChildren<Outline>().enabled = false;
                if (selected_slot == hotkey_)
                {
                    slotInstance.GetComponentInChildren<Outline>().enabled = true;
                }
            }
            slotInstance.GetComponentInChildren<Text>().text = hotkey_.ToString();
            hotkey_++;

        }
    }

    void SelectWeapon(int hotkey_)
    {
        active_slot = hotkey_ - 1;

        Weapon selected_weapon = inventory_[hotkey_ -1 ];
        playerStats.attack_damage = selected_weapon.weapon_damage;
        playerStats.attack_speed = selected_weapon.weapon_speed;
        playerStats.attack_range = selected_weapon.weapon_range;
        playerStats.attack_life = selected_weapon.weapon_life;
        selected_slot = hotkey_;

        RefreshInventory();
    }

    void InventorySelector()
    {
        for (int i = 0; i <= 5; i++)
        {
            if (Input.GetKeyDown((KeyCode)(KeyCode.Alpha0 + i)))
            {
   
                SelectWeapon(i);
            }
            
        }

    }
    public void AddGoldCoins(float gold)
    {
        gold_coins += gold;
        RefreshInventory();
    }
    public void DiscardWeapon()
    {
        if (active_slot != 0)
        {
            inventory_[active_slot] = null;
            SelectWeapon(1);
            RefreshInventory();
        }
    }
 }
