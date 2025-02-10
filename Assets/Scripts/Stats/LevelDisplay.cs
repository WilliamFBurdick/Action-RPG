using TMPro;
using UnityEngine;
using System;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour 
    {
        BaseStats baseStats;

        void Awake()
        {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }

        void Update()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("Level: {0:0}", baseStats.GetLevel());
        }
    }
}