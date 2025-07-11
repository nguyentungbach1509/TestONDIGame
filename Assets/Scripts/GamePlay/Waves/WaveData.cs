using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.GamePlay
{
    [CreateAssetMenu(fileName = "Wave Data", menuName = "Data/Waves")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] List<Wave> waves;
        public List<Wave> Data => waves;
    }

    [Serializable]
    public class Wave
    {
        [SerializeField] private int id;
        [SerializeField] private int numberEnemy;
        [SerializeField] private bool hasBoss;

        public int Id => id;    
        public int NumberEnemy => numberEnemy;
        public bool HasBoss => hasBoss;
    }
}

