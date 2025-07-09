using Game.Script.CharacterComponent;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.WallComponent
{
    [CreateAssetMenu(fileName = "Wall Data", menuName = "Data/WallBase")]
    public class WallData : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private string nameKey;
        [SerializeField] private WallBaseStats stats;

        public int Id => id;
        public string Key => nameKey;
        public WallBaseStats Stats => stats;
    }

    [Serializable]
    public class WallBaseStats
    {
        [SerializeField] private float maxHp;
        [SerializeField] private float armor;
        
        public float MaxHp => maxHp;
        public float Armor => armor;
    }
}

