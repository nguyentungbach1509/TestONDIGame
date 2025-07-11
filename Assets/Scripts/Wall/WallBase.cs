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

        [Header("Settings")]
        [SerializeField] float marginTop = 1f;
        [SerializeField] float marginBottom = .5f;

        private WallStats stats;
        public WallStats Stats => stats;
        
        public void Init()
        {
            stats = new WallStats(data);
            canvas.DamagePopup.Init();
            stats.OnDamageTaken += canvas.DamagePopup.UpdateDmgText;
            stats.OnHealthChange += canvas.HealthBar.UpdateHealth;
            stats.OnDestroy += OnWallDestroy;
            canvas.HealthBar.SetInitHP();
        }

        public Vector2 GetRandomPointOnWall()
        {
            Bounds bounds = sprite.bounds;
            Debug.Log(bounds.center);
            Vector2 bottom = bounds.min;
            Vector2 top = bounds.max;

            bottom.y += marginBottom;
            top.y -= marginTop;

            Vector2 direction = (bottom - top).normalized;
            float length = Vector2.Distance(top, bottom);

            float randomOffset = Random.Range(0, length);
            Vector2 point = top + direction * randomOffset;

            if(point.y <= bounds.center.y)
            {
                point.x = Random.Range(bounds.center.x, bounds.max.x);
            }
            else
            {
                point.x = Random.Range(bounds.min.x, bounds.center.x);
            }
            return point;
        }

        private void OnWallDestroy()
        {
            stats.OnDestroy -= OnWallDestroy;
            stats.OnDamageTaken -= canvas.DamagePopup.UpdateDmgText;
            stats.OnHealthChange -= canvas.HealthBar.UpdateHealth;
        }
    }
}

