using Game.Script.SubScripts;
using Game.Script.UI.Popup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] GeneralHUD generalHUD;
        [SerializeField] PopUpController popUpController;

        public PopUpController PopUpController => popUpController;

        public void Init()
        {
            generalHUD.Init();
            popUpController.Init();
        }
    }

}
