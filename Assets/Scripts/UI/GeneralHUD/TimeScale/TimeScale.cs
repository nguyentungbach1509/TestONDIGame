using Game.Script.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Script.UI
{
    public class TimeScale : MonoBehaviour
    {
        [SerializeField] Image fillImage;
        [SerializeField] float duration;

        private Coroutine fillCoroutine;

        public void Init()
        {
            GameNormalMode.OnTimeChange -= UpdateTime;
            GameNormalMode.OnTimeChange += UpdateTime;
            fillImage.fillAmount = 0;
        }

        public void UpdateTime(float percent)
        {
            if(percent >= 1)
            {
                fillImage.fillAmount = 1;
                return;
            } 

            if (fillCoroutine != null) StopCoroutine(fillCoroutine); 
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

