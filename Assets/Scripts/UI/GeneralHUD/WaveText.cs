using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.Script.UI
{
    public class WaveText : MonoBehaviour
    {
        [SerializeField] private RectTransform stageTextRect;
        [SerializeField] private CanvasGroup stageTextGroup;
        [SerializeField] private TMP_Text stageText;

        private Sequence stageSequence;

        public void ShowStageText(string stageName)
        {
            stageSequence.Kill();

            stageTextRect.anchoredPosition = new Vector2(-Screen.width, 0);
            stageTextGroup.alpha = 0;
            stageText.text = stageName;

            stageSequence = DOTween.Sequence();

            stageSequence.Append(stageTextGroup.DOFade(1, 0.3f));
            stageSequence.Join(stageTextRect.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack));

            stageSequence.AppendInterval(1.2f);

            stageSequence.Append(stageTextRect.DOAnchorPos(new Vector2(Screen.width, 0), 0.5f).SetEase(Ease.InBack));
            stageSequence.Join(stageTextGroup.DOFade(0, 0.3f));
        }
    }
}

