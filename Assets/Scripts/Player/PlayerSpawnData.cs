using Game.Script.PlayerComponent;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.SpawnMechanic
{
    [CreateAssetMenu(fileName = "Player Spawn Data", menuName = "Spawner/Data/Player")]
    public class PlayerSpawnData : ScriptableObject
    {
        [SerializeField] List<PlayerPrefab> prefabs;
        public List<PlayerPrefab> Prefabs => prefabs;
    }

    [Serializable]
    public class PlayerPrefab
    {
        [SerializeField] int id;
        [SerializeField] string key;
        [SerializeField] Player player;

        public int Id => id;
        public string Key => key;
        public Player Prefab => player;

    }
}

