using Game.Script.UI.HeathBar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.CharacterComponent
{
    public class CharacterCanvas : MonoBehaviour
    {
        [SerializeField] HealthBarController healthBar;

        public HealthBarController HealthBar => healthBar;
    }

}
