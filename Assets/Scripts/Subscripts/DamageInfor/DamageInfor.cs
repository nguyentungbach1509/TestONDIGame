using Game.Script.CharacterComponent;
using System;


namespace Game.Script.SubScripts
{
    public class DamageInfor
    {
        private string id;
        private float damage;
        private CharacterBase source;

        public string Id => id;
        public float Damage => damage;  
        public CharacterBase Source => source;

        public DamageInfor(float damage, CharacterBase source)
        {
            id = Guid.NewGuid().ToString();
            this.damage = damage;
            this.source = source;
        }
    }
}


