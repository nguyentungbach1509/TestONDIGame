using Game.Script.CharacterComponent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.ProjectileComponent
{
    public class Projectile
    {
        private int id;
        private string key;
        private float damage;
        private float speed;
        private CharacterBase source;

        public int Id => id;
        public string Key => key;
        public float Damage => damage;
        public float Speed => speed;
        public CharacterBase Source => source;

        public Projectile(ProjectileData data)
        {
            id = data.Id;
            key = data.Key;
            speed = data.Speed;
        }

        public void SetDamage(float damage) => this.damage = damage;
        public void SetSource(CharacterBase source) => this.source = source;
    }
}

