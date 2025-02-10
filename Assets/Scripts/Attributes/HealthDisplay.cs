using TMPro;
using UnityEngine;
using System;

namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour 
    {
        Health health;

        void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        void Update()
        {
            GetComponent<TextMeshProUGUI>().text = String.Format("Health: {0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());
        }
    }
}