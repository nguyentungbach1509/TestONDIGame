using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.ProjectileComponent
{
    [CreateAssetMenu(fileName = "Projectile Data", menuName = "Data/Projectiles")]
    public class ProjectileData : ScriptableObject
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] float damage;
        [SerializeField] float speed;

        public int Id => id;
        public string Key => key;
        public float Damage => damage;
        public float Speed => speed;
    }
}

