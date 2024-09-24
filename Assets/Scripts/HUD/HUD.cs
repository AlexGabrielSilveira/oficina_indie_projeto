using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }

    public Slider hp_bar;
    public Slider exp_bar;
    EntityStats player_stats;

    public TextMeshProUGUI[] stats_infos;

    public GameObject level_up_screen;
    public TextMeshProUGUI showLvl;

    public GameObject damagePopUp;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
    }
    private void Update()
    {
        PlayerHUD();
        showLvl.text = player_stats.level.ToString();
    }
    void PlayerHUD()
    {
        hp_bar.maxValue = player_stats.max_hp;
        hp_bar.value = player_stats.hp;

        exp_bar.maxValue = player_stats.level * 100;
        exp_bar.value = player_stats.exp;
    }
    public void SelectStats(string stat)
    {
        switch(stat)
        {
            case "hp":
                player_stats.max_hp += 5;
                player_stats.hp += 5;
                break;
            case "move":
                player_stats.base_speed += 150;
                break;
            case "atk":
                player_stats.bonusAtk += 5f;
                break;
            case "atkSpeed":
                player_stats.bonusAtkSpeed += 2.5f;
                break;
        }

        level_up_screen.SetActive(false);
    }
    public void SetUpLevelUp()
    {
        level_up_screen.SetActive(true);

        stats_infos[0].text = player_stats.max_hp.ToString();
        stats_infos[1].text = player_stats.bonusAtk.ToString() + 5;
        stats_infos[2].text = player_stats.bonusAtkSpeed.ToString() + 2.5f;
        stats_infos[3].text = Mathf.CeilToInt(player_stats.base_speed / 1000).ToString();
    }
}
