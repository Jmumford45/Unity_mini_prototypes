using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float spawnRange = 9.0f;
    public GameObject enemyPrefabs;
    public int enemyCount;

    public GameObject powerUp;
    public int numberOfEnemies { get; private set; }

    private void Start()
    {
        numberOfEnemies = 1;

        //SpawnPowerUp();
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            SpawnPowerUp();
            SpawnEnemyWave(numberOfEnemies++);
        }
    }

    private Vector3 GenerateRandPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randPos;
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUp, GenerateRandPos(), powerUp.transform.rotation);
    }

    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefabs, GenerateRandPos(), enemyPrefabs.transform.rotation);
        }
    }
}
