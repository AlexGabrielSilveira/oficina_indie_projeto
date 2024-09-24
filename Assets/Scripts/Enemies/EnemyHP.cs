using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    Slider hp_slider;

    EntityStats enemy_stats;

    private void Start()
    {
        hp_slider = gameObject.GetComponentInChildren<Slider>();
        enemy_stats = gameObject.GetComponentInParent<EntityStats>();
    }
    private void Update()
    {
        hp_slider.maxValue = enemy_stats.max_hp;
        hp_slider.value = enemy_stats.hp;    
    }
}
