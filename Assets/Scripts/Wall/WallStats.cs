using Game.Script.SubScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.WallComponent
{
    public class WallStats
    {
        private int id;
        private string keyName;
        private float maxHp;
        private float currentHp;
        private float armor;

        public int Id => id;
        public string Key => keyName;
        public float MaxHp => maxHp;
        public float CurrentHp => currentHp;
        public float Armor => armor;

        public Action<float> OnHealthChange;
        public Action OnDestroy;

        public WallStats(WallData data)
        {
            id = data.Id;
            keyName = data.Key;
            maxHp = data.Stats.MaxHp;
            currentHp = maxHp;
            armor = data.Stats.Armor;
        }

        public void UpdateHp(DamageInfor damageInfor, bool add = false)
        {
            currentHp -= damageInfor.Damage;
            if (currentHp <= 0)
            {
                currentHp = 0;
                OnDestroy?.Invoke();
            }
            OnHealthChange?.Invoke(currentHp / maxHp);
        }

        public void UpdateHp(float damage, bool add = false)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                currentHp = 0;
                OnDestroy?.Invoke();
            }
            OnHealthChange?.Invoke(currentHp / maxHp);
        }
    }
}

