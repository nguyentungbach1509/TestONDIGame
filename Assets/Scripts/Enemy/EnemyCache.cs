using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.Foes
{
    public static class EnemyCache
    {
        private static Dictionary<Collider2D, Enemy> enemyDict;

        public static void Init()
        {
            if (enemyDict == null) enemyDict = new();
            else enemyDict.Clear();
        }

        public static void AddEnemy(Enemy enemy) => enemyDict.Add(enemy.Collider, enemy);
        public static Enemy GetEnemy(Collider2D collider)
        {
            if(enemyDict.TryGetValue(collider, out Enemy enemy)) return enemy;
            return null;
        }
        public static int GetCount() => enemyDict.Count;
        public static void RemoveEnemy(Enemy enemy) => enemyDict.Remove(enemy.Collider);
        public static void RemoveAll() => enemyDict.Clear();
    }
}

