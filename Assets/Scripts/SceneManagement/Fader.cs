using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour 
    {
        CanvasGroup canvasGroup;

        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public IEnumerator FadeOut(float time)
        {
            while(canvasGroup.alpha < 1f)
            {
                canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha + Time.deltaTime / time);
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            while(canvasGroup.alpha > 0f)
            {
                canvasGroup.alpha = Mathf.Clamp01(canvasGroup.alpha - Time.deltaTime / time);
                yield return null;
            }
        } 
    }
}