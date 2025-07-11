using Game.Script.UI;
using Game.Script.UI.HeathBar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.WallComponent
{
    public class WallCanvas : MonoBehaviour
    {
        [SerializeField] HealthBarController healthBarController;
        [SerializeField] DamagePopup dmgPopup;

        public DamagePopup DamagePopup => dmgPopup;
        public HealthBarController HealthBar => healthBarController;

    }
}

