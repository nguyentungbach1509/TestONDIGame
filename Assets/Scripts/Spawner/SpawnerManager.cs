using Game.Script.GamePlay;
using Game.Script.SubScripts;
using Game.Script.VFXComponent;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
namespace Game.Script.SpawnMechanic
{
    public class SpawnerManager : Singleton<SpawnerManager>
    {
        
        [SerializeField] GamePrefabs gamePrefabs;

        [Header("Settings")]
        [SerializeField] float xBorderRight;
        [SerializeField] float margin;

        [Header("Enemy Spawn Config")]
        [Range(3, 5)]
        [SerializeField] float spawnMinInterval;
        [Range(3, 5)]
        [SerializeField] float spawnMaxInterval; // Thời gian giữa các lần spawn


        [Range(1, 3)]
        [SerializeField] int spawnMinCount;
        [Range(1, 3)]
        [SerializeField] int spawnMaxCount; // Thời gian giữa các lần spawn

        private Coroutine spawnCoroutine;
        private EnemySpawner enemySpawner;
        private ProjectileSpawner projectileSpawner;
        private VFXSpawner vfxSpawner;
        private AbilitySpawner abilitySpawner;
        private PlayerSpawner playerSpawner;
        private GameMode mode => GameManager.Instance.Mode;
        private bool onceTime;

        public EnemySpawner EnemySpawner => enemySpawner;
        public ProjectileSpawner ProjectileSpawner => projectileSpawner;  
        public VFXSpawner VFXSpawner => vfxSpawner;
        public AbilitySpawner AbilitySpawner => abilitySpawner;
        public PlayerSpawner PlayerSpawner => playerSpawner;
        public void Init()
        {
            enemySpawner = new EnemySpawner(gamePrefabs);
            projectileSpawner = new ProjectileSpawner(gamePrefabs);
            vfxSpawner = new VFXSpawner(gamePrefabs);
            abilitySpawner = new AbilitySpawner(gamePrefabs);
            playerSpawner = new PlayerSpawner(gamePrefabs);
            playerSpawner.SetPlayer(mode.Player);
            onceTime = false;
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

        public void SpawnRandomEnemy(int currentWave)
        {
            if (spawnCoroutine != null) StopCoroutine(spawnCoroutine);
            spawnCoroutine = StartCoroutine(Spawn(currentWave));

        }

        public void PauseSpawn(int currentWave)
        {
            if (spawnCoroutine != null) StopCoroutine(spawnCoroutine);
            else StopCoroutine(Spawn(currentWave));
            onceTime = false;
        }

        private IEnumerator Spawn(int currentWave)
        {
            while (!mode.EndWave(currentWave))
            {
                int numberEnemy = Random.Range(spawnMinCount, spawnMaxCount);
                mode.AddEnemy(numberEnemy);
                List<Vector2> points = GetRandomPoints(numberEnemy, 3);
                float randomInterval = Random.Range(spawnMinInterval, spawnMaxInterval);
                foreach (Vector2 point in points)
                {
                    VFX vfx = vfxSpawner.SpawnVFX(PrefabConstants.VFX_Smoke, 
                        point, Quaternion.identity, null);
                    yield return new WaitForSeconds(vfx.EndReduceTime);
                    vfxSpawner.DespawnVFX(PrefabConstants.VFX_Smoke, vfx);
                    enemySpawner.SpawnEnemy(PrefabConstants.Slime, point, Quaternion.identity);
                }
                yield return new WaitForSeconds(randomInterval);
                if (mode.IsBossShow(currentWave) && !onceTime)
                {
                    onceTime = true;
                    VFX vfx = vfxSpawner.SpawnVFX(PrefabConstants.VFX_Smoke_Boss,
                        points[0], Quaternion.identity, null);
                    yield return new WaitForSeconds(vfx.EndReduceTime);
                    vfxSpawner.DespawnVFX(PrefabConstants.VFX_Smoke, vfx);
                    enemySpawner.SpawnBoss(currentWave, points[0], Quaternion.identity);
                }
            }

        }

        public void DespawnAll()
        {
            enemySpawner.DespawnAll();
            projectileSpawner.DespawnAll();
            vfxSpawner.DespawnAll();
            abilitySpawner.DespawnAll();
        }

    }

}

