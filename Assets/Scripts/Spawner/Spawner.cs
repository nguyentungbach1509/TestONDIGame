using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.SpawnMechanic
{
    public class Spawner
    {
        protected GamePrefabs gamePrefabs;


        public Spawner(GamePrefabs gamePrefabs)
        {
            this.gamePrefabs = gamePrefabs;
        }
    }
}

