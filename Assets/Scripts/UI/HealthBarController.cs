using Game.Script.SpawnMechanic;
using Game.Script.SubScripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Script.UI.HeathBar
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] Image fillImage;
        [SerializeField] float duration;

        private Coroutine fillCoroutine;

        public void SetInitHP()
        {
            fillImage.fillAmount = 1;
        }

        public void UpdateHealth(float percent)
        {
            if(fillCoroutine != null) StopCoroutine(fillCoroutine); fillCoroutine = null;
            fillCoroutine = StartCoroutine(SmoothChange());

            IEnumerator SmoothChange()
            {
                float elapsed = 0f;
                float start = fillImage.fillAmount;

                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    fillImage.fillAmount = Mathf.Lerp(start, percent, elapsed / duration);
                    yield return null;
                }

                fillImage.fillAmount = percent;
            }
            
        }
    }
}

