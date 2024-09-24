using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float max_hp;
    public float hp;
    public float base_speed;
    public float attack_damage;
    public float attack_speed;
    public float attack_life;
    public float attack_range;
    public int gold_carry;

    //only players

    public int level = 1;
    public int exp = 0;
    public float bonusAtk;
    public float bonusAtkSpeed;

    

    public SpawnManager spawnManager;
    private void Start()
    {
        hp = max_hp;
    }
    void Death()
    {
        if(hp <= 0)
        {
            if(this.gameObject.tag != "Player")
            {
                InventoryManager.Instance.AddGoldCoins(gold_carry);
                GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>().AddExp(exp);
            }
            Destroy(this.gameObject);

            if(this.gameObject.tag == "Enemy" )
            {
                spawnManager.enemiesAlive--;
            }
        }
    }
    public void RemoveHP(float hp_)
    {
        var new_popup = Instantiate(HUD.Instance.damagePopUp, this.gameObject.transform.position, Quaternion.identity);
        new_popup.GetComponentInChildren<TextMeshProUGUI>().text = hp_.ToString();
        new_popup.GetComponent<Rigidbody2D>().AddForce(new Vector2( Random.Range(-2f,2f),5f),ForceMode2D.Impulse);
        Destroy(new_popup,0.5f);
        hp -= hp_;
        Death();

    }

    void AddExp(int exp_)
    {
        exp += exp_;

        if (exp >= level * 100)
        {
            exp = 0;
            level++;
            HUD.Instance.SetUpLevelUp();
        }
    }
}

