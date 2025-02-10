using TMPro;
using UnityEngine;
using System;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour 
    {
        Fighter fighter = null;

        void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        void Update()
        {
            if (fighter.GetTarget() == null)
            {
                GetComponent<TextMeshProUGUI>().text = "";
            }
            else
            {
                GetComponent<TextMeshProUGUI>().text = String.Format("Target Health: {0:0}/{1:0}", fighter.GetTarget().GetHealthPoints(), fighter.GetTarget().GetMaxHealthPoints());
            }
        }
    }
}