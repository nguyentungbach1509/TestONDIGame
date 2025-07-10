using Game.Script.SubScripts;
using System;
using UnityEngine;


namespace Game.Script.CharacterComponent
{
    public class CharacterStats 
    {
   
        private int id;
        private string keyName;

        private float maxHp;
        private float currentHp;
        private float armor;
        private float damage;
        private float speed;

        public int Id => id;
        public string KeyName => keyName;
        public float MaxHp => maxHp;
        public float CurrentHp => currentHp;
        public float Armor => armor;
        public float Damage => damage;
        public float Speed => speed;

        public Action<float> OnHealthChange;
        public Action<CharacterBase> OnDie;

        public CharacterStats(CharacterData data)
        {
            id = data.Id;
            keyName = data.Key;
            maxHp = data.Stats.MaxHp;
            currentHp = maxHp;
            armor = data.Stats.Armor;
            damage = data.Stats.Damage;
            speed = data.Stats.Speed;
        }   

        public void UpdateHp(DamageInfor damageInfor, bool add=false)
        {
            if(add) currentHp = Mathf.Clamp(currentHp + damageInfor.Damage, 0, maxHp);
            else currentHp -= damageInfor.Damage;
            OnHealthChange?.Invoke(currentHp / maxHp);
            if (currentHp <= 0)
            {
                currentHp = 0;
                OnDie?.Invoke(damageInfor.Source);
            }
        }

        public void UpdateHp(float damage, bool add=false)
        {
            if(add) currentHp = Mathf.Clamp(currentHp + damage, 0, maxHp);
            else currentHp -= damage;
            OnHealthChange?.Invoke(currentHp / maxHp);
            if (currentHp <= 0)
            {
                currentHp = 0;
                OnDie?.Invoke(null);
            }
        }
    }
}

