using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Script.WallComponent
{
    public class WallBase : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] WallData data;
        [SerializeField] WallCanvas canvas;
        [SerializeField] SpriteRenderer sprite;

        private WallStats stats;
        public WallStats Stats => stats;
        public void Init()
        {
            stats = new WallStats(data);
            stats.OnHealthChange += canvas.HealthBar.UpdateHealth;
            stats.OnDestroy += OnWallDestroy;
            //stats.UpdateHp(0);
        }

        public Vector2 GetRandomPointOnWall()
        {
            Bounds bounds = sprite.bounds;
            Vector2 top = bounds.min;
            Vector2 bottom = bounds.max;

            Vector2 direction = (bottom - top).normalized;
            float length = Vector2.Distance(top, bottom);

            float randomOffset = Random.Range(0, length);
            Vector2 point = top + direction * randomOffset;

            return point;
        }

        private void OnWallDestroy()
        {
            stats.OnDestroy -= OnWallDestroy;
            stats.OnHealthChange -= canvas.HealthBar.UpdateHealth;
        }
    }
}

