using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.CharacterComponent
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "Data/CharacterBase")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private string nameKey;
        [SerializeField] private BaseStats stats;

        public int Id => id;
        public string Key => nameKey;
        public BaseStats Stats => stats;
    }

    [Serializable]
    public class BaseStats
    {
        [SerializeField] private float maxHp;
        [SerializeField] private float armor;
        [SerializeField] private float damage;
        [SerializeField] private float speed;

        public float MaxHp => maxHp;
        public float Armor => armor;
        public float Damage => damage;
        public float Speed => speed;
    }
}


