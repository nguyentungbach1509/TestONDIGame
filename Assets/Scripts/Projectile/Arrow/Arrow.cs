using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Game.Script.ProjectileComponent
{
    public class Arrow : ProjectileBase
    {
        [SerializeField] float height;

        private Coroutine moveCoroutine;

        public override void MoveTo(Vector2 target)
        {
            if(moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = StartCoroutine(Move());

            IEnumerator Move()
            {
                float time = 0f;
                Vector2 start = transform.position;
                Vector2 savePos = transform.position;

                while (time < projectile.Speed)
                {
                    float t = time / projectile.Speed;

                    // Tính vị trí mới
                    float x = Mathf.Lerp(savePos.x, target.x, t);

                    // Tính Y theo parabol đỉnh ở giữa (không dùng Lerp y)
                    float y = Mathf.Lerp(savePos.y, target.y, t) + height * 4 * t * (1 - t);

                    Vector2 position = new Vector2(x, y);
                    transform.position = position;

                    // Quay theo hướng di chuyển
                    Vector3 direction = position - start;
                    if (direction.sqrMagnitude > 0.0001f)
                    {
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.Euler(0, 0, angle);
                    }

                    start = position;

                    time += Time.deltaTime;
                    yield return null;
                }

                // Kết thúc tại điểm cuối, xoay đúng hướng
                transform.position = target;
                DestroyProjectile();

            }
        }
            
    }
}

