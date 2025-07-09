using Game.Script.SubScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    public class SpawnerManager : Singleton<SpawnerManager>
    {
        [SerializeField] GamePrefabs gamePrefabs;
        [SerializeField] float xBorderRight;
        [SerializeField] float margin;

        private EnemySpawner enemySpawner;
        private ProjectileSpawner projectileSpawner;

        public EnemySpawner EnemySpawner => enemySpawner;
        public ProjectileSpawner ProjectileSpawner => projectileSpawner;    

        public void Init()
        {
            enemySpawner = new EnemySpawner(gamePrefabs);
            projectileSpawner = new ProjectileSpawner(gamePrefabs);
            SpawnRandomEnemy();
        }

        public void SpawnRandomEnemy()
        {
            StartCoroutine(Spawn());

            IEnumerator Spawn()
            {
                while(true)
                {
                    List<Vector2> points = GetRandomPoints(Random.Range(2, 3), 3);
                    foreach (Vector2 point in points)
                    {
                        enemySpawner.SpawnEnemy(PrefabConstants.Slime, point, Quaternion.identity);

                    }
                    yield return new WaitForSeconds(Random.Range(1f,3f));
                }
               
            }
            
        }

        private List<Vector2> GetRandomPoints(int count, float minDistance, int maxAttempts = 1000)
        {
            List<Vector2> points = new List<Vector2>();
            int attempts = 0;

            while (points.Count < count && attempts < maxAttempts)
            {
                Vector2 point = GetRandomPointInBounds();

                // Kiểm tra khoảng cách với các điểm đã có
                bool isTooClose = false;
                foreach (var existingPoint in points)
                {
                    if (Vector2.Distance(existingPoint, point) < minDistance)
                    {
                        isTooClose = true;
                        break;
                    }
                }

                if (!isTooClose)
                {
                    points.Add(point);
                }

                attempts++;
            }

            return points;
        }

        private Vector2 GetRandomPointInBounds()
        {
            Camera cam = Camera.main;

            Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, -cam.transform.position.z));
            Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, -cam.transform.position.z));

            float cameraLeftX = bottomLeft.x;
            float cameraBottomY = bottomLeft.y;
            float cameraTopY = topRight.y;


            float minX = Mathf.Min(cameraLeftX, xBorderRight);
            float maxX = Mathf.Max(cameraLeftX, xBorderRight);
            float randomX = Random.Range(minX, maxX);

            float randomY = Random.Range(cameraBottomY + margin, cameraTopY - margin);

            Vector2 position = new Vector2(randomX, randomY);
            return position;
        }

    }

}

