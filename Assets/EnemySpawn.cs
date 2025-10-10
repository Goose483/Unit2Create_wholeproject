using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple Wave Row Spawner
// Spawns rows of enemies for each wave, then waits before the next wave
public class EnemySpawn : MonoBehaviour
{
    [Header("Enemies")]
    public GameObject[] enemies; // default enemy prefabs (used if wave doesn't have its own)

    [Header("Row Settings")]
    public Vector2 rowDirection = Vector2.right; // local direction for the row
    public float spacing = 1f; // gap between enemies in row
    public bool centerRow = true; // center the row on this spawner

    [System.Serializable]
    public class Wave
    {
        public string waveName = "Wave";
        public int count = 5; // how many in the row
        public GameObject[] waveEnemies; // optional specific prefabs
        public float perEnemyDelay = 0f; // delay between spawning each enemy in the row
    }
    
    [Header("Waves")]
    public Wave[] waves;
    public float timeBetweenWaves = 3f;
    public bool loopWaves = false;
    // optional: max seconds to wait for a wave's enemies to be cleared (0 = wait forever)
    public float waveTimeout = 0f;

    private Coroutine running;

    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (running == null)
            running = StartCoroutine(RunWaves());
    }

    public void StopSpawning()
    {
        if (running != null)
        {
            StopCoroutine(running);
            running = null;
        }
    }

    IEnumerator RunWaves()
    {
        if (waves == null || waves.Length == 0)
        {
            Debug.LogWarning("EnemySpawn: no waves set");
            yield break;
        }

        do
        {
            for (int w = 0; w < waves.Length; w++)
            {
                Wave wave = waves[w];
                if (wave == null) continue;

                GameObject[] prefabs = (wave.waveEnemies != null && wave.waveEnemies.Length > 0) ? wave.waveEnemies : enemies;
                if (prefabs == null || prefabs.Length == 0)
                {
                    Debug.LogWarning($"EnemySpawn: wave '{wave.waveName}' has no prefabs, skipping");
                    continue;
                }

                // compute start offset for centering
                Vector2 dir = rowDirection.normalized;
                float totalLen = (wave.count - 1) * spacing;
                Vector2 startOffset = centerRow ? -(dir * (totalLen / 2f)) : Vector2.zero;

                List<GameObject> spawnedThisWave = new List<GameObject>();
                for (int i = 0; i < wave.count; i++)
                {
                    int idx = Random.Range(0, prefabs.Length);
                    GameObject prefab = prefabs[idx];
                    if (prefab == null) continue;

                    Vector2 localPos = startOffset + dir * (i * spacing);
                    Vector3 worldPos = transform.TransformPoint(new Vector3(localPos.x, localPos.y, 0f));
                    GameObject spawned = Instantiate(prefab, worldPos, transform.rotation);
                    spawnedThisWave.Add(spawned);

                    if (wave.perEnemyDelay > 0f)
                        yield return new WaitForSeconds(wave.perEnemyDelay);
                }

                // wait until all spawned objects from this wave are destroyed (or timeout)
                if (spawnedThisWave.Count > 0)
                {
                    float elapsed = 0f;
                    while (true)
                    {
                        bool anyAlive = false;
                        for (int s = 0; s < spawnedThisWave.Count; s++)
                        {
                            if (spawnedThisWave[s] != null)
                            {
                                anyAlive = true;
                                break;
                            }
                        }

                        if (!anyAlive)
                            break; // all cleared

                        if (waveTimeout > 0f)
                        {
                            elapsed += Time.deltaTime;
                            if (elapsed >= waveTimeout)
                            {
                                Debug.LogWarning($"EnemySpawn: wave '{wave.waveName}' timeout after {waveTimeout}s - moving to next wave.");
                                break;
                            }
                        }

                        yield return null; // wait a frame
                    }
                }

                if (timeBetweenWaves > 0f)
                    yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (loopWaves);

        running = null;
    }
}
 
