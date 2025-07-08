using Game.Script.SubScripts;
using System;


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
        public Action OnDie;

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
            currentHp -= damageInfor.Damage;
            if(currentHp <= 0)
            {
                currentHp = 0;
                OnDie?.Invoke();
            }
            OnHealthChange?.Invoke(currentHp / maxHp);
        }

        public void UpdateHp(float damage, bool add=false)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                currentHp = 0;
                OnDie?.Invoke();
            }
            OnHealthChange?.Invoke(currentHp / maxHp);
        }
    }
}

