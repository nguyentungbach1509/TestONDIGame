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

        public int Id => id;
        public string Key => key;
        public float Damage => damage;
        public float Speed => speed;

        public Projectile(ProjectileData data)
        {
            id = data.Id;
            key = data.Key;
            damage = data.Damage;
            speed = data.Speed;
        }
    }
}

