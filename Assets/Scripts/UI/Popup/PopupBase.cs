using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Script.UI.Popup
{
    public class PopupBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvas;
        [SerializeField] protected Button closeBtn;
        [SerializeField] protected string key;

        public string Key => key;

        public virtual void Init()
        {
            closeBtn.onClick.AddListener(Close);
        }

        public virtual void Open()
        {
            canvas.alpha = 1;
            canvas.blocksRaycasts = true;
        }

        public virtual void Close()
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
        }

    }
}

