using TMPro;
using UnityEngine;
using System;

namespace RPG.Stats
{
    public class ExperienceDisplay : MonoBehaviour 
    {
        Experience experience;

        void Awake()
        {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        void Update()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("XP: {0:0}", experience.GetPoints());
        }
    }
}