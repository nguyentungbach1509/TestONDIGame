using DG;
using DG.Tweening;
using TMPro;
using UnityEditor.Build;
using UnityEngine;
namespace Game.Script.UI
{
    public class DamagePopup : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] TMP_Text dmgTxt;

        [SerializeField] float popupDuration = 1f;
        [SerializeField] float moveUpDistance = 50f;

        Vector3 initialPosition;
        Vector3 initialScale;

        public void Init()
        {
            initialPosition = transform.localPosition;
            initialScale = transform.localScale;
            ResetState();
        }

        public void UpdateDmgText(float damage, bool add = false)
        {
            dmgTxt.color = add ? Color.green : Color.red;
            dmgTxt.text = add ? $"+{damage:F1}" : $"-{damage:F1}";

            PlayPopupAnimation();
        }

        private void PlayPopupAnimation()
        {
            ResetState();

            Sequence seq = DOTween.Sequence();

            seq.Append(canvasGroup.DOFade(1f, 0.1f));
            seq.Join(transform.DOScale(initialScale, 0.3f).From(Vector3.zero).SetEase(Ease.OutBack));
            seq.Join(transform.DOLocalMoveY(initialPosition.y + moveUpDistance, popupDuration).SetEase(Ease.OutCubic));

            seq.AppendInterval(0.2f);

            seq.Append(canvasGroup.DOFade(0f, 0.3f));

            seq.OnComplete(() =>
            {
                //ResetState();
            });
        }

        private void ResetState()
        {
            canvasGroup.alpha = 0f;
            transform.localPosition = initialPosition;
            transform.localScale = Vector3.zero;
        }
    }
}

