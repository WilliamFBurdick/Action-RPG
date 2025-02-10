using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace RPG.Saving
{
    [ExecuteAlways]
    public class JsonSaveableEntity : MonoBehaviour
    {
        [SerializeField] string uniqueIdentifier = "";

        // CACHED STATE
        static Dictionary<string, JsonSaveableEntity> globalLookup = new Dictionary<string, JsonSaveableEntity>();

        public string GetUniqueIdentifier()
        {
            return uniqueIdentifier;
        }

        public JToken CaptureAsJtoken()
        {
            JObject state = new JObject();
            IDictionary<string, JToken> stateDict = state;
            foreach (IJsonSaveable jsonSaveable in GetComponents<IJsonSaveable>())
            {
                JToken token = jsonSaveable.CaptureAsJToken();
                string component = jsonSaveable.GetType().ToString();
                Debug.Log($"{name} Capture {component} = {token.ToString()}");
                stateDict[jsonSaveable.GetType().ToString()] = token;
            }
            return state;
        }

        public void RestoreFromJToken(JToken s)
        {
            JObject state = s.ToObject<JObject>();
            IDictionary<string, JToken> stateDict = state;
            foreach (IJsonSaveable jsonSaveable in GetComponents<IJsonSaveable>())
            {
                string component = jsonSaveable.GetType().ToString();
                if (stateDict.ContainsKey(component))
                {
                    Debug.Log($"{name} Restore {component} =>{stateDict[component].ToString()}");
                    jsonSaveable.RestoreFromJToken(stateDict[component]);
                }
            }
        }

        #if UNITY_EDITOR
        private void Update()
        {
            if (Application.IsPlaying(gameObject)) return;              // don't execute if we're playing
            if (string.IsNullOrEmpty(gameObject.scene.path)) return;    // don't execute if we're in a prefab scene

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty property = serializedObject.FindProperty("uniqueIdentifier");

            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }

            globalLookup[property.stringValue] = this;
        }
        #endif

        bool IsUnique(string candidate)
        {
            if (!globalLookup.ContainsKey(candidate)) return true;
            if (globalLookup[candidate] == this) return true;
            if (globalLookup[candidate] == null)
            {
                globalLookup.Remove(candidate);
                return true;
            }
            if (globalLookup[candidate].GetUniqueIdentifier() != candidate)
            {
                globalLookup.Remove(candidate);
                return true;
            }
            return false;
        }
    }
}