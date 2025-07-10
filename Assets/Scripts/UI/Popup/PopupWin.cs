
using Game.Script.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Script.UI.Popup
{
    public class PopupWin : PopupBase
    {
        public override void Close()
        {
            base.Close();
            GameManager.Instance.Replay();
        }
    }
}

