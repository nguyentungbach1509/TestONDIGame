using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Game.Script.UI.Popup
{
    public class PopUpController : MonoBehaviour
    {
        [SerializeField] List<PopupBase> popupBases;
        private Dictionary<string, PopupBase> popupBaseDict;

        public void Init()
        {
            popupBaseDict = new();
            foreach(var popupBase in popupBases)
            {
                popupBase.Init();
                popupBaseDict.Add(popupBase.Key, popupBase);
            }
        }

        public PopupBase GetPopup(string key)
        {
            if(popupBaseDict.TryGetValue(key, out PopupBase popupBase))
            {
                return popupBase;
            }

            return null;
        }
    }
}

