using Newtonsoft.Json.Linq;
using RPG.Saving;
using UnityEngine;
using System;

namespace RPG.Stats
{
    
    public class Experience : MonoBehaviour, IJsonSaveable 
    {
        [SerializeField] float experiencePoints = 0f;

        public event Action onExperienceGained;

        public JToken CaptureAsJToken()
        {
            return experiencePoints;
        }

        public float GetPoints()
        {
            return experiencePoints;
        }

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
            onExperienceGained();
        }

        public void RestoreFromJToken(JToken state)
        {
            experiencePoints = state.ToObject<float>();
        }
    }
}