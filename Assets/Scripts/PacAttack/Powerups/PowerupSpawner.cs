using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField]
    private int spawnInterval = 15;

    [SerializeField]
    private GameObject[] powerupPrefabs;

    //private string scene;

    private void Start()
    {
        //scene = SceneManager.GetActiveScene().name;
        StartCoroutine(SpawnPowerups());
    }

    private IEnumerator SpawnPowerups()
    {
        yield return new WaitForSeconds(RandomWaitTimer());
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 1f, Random.Range(-9f, 5.5f));
            int randomIndex = Random.Range(0, powerupPrefabs.Length);
            GameObject randomPowerup = powerupPrefabs[randomIndex];
            Instantiate(randomPowerup, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(RandomWaitTimer());
        }
    }

    private int RandomWaitTimer()
    {
        int firstSpawnTime = spawnInterval - spawnInterval / 3;
        int lastSpawnTime = spawnInterval * 2;
        return Random.Range(firstSpawnTime, lastSpawnTime);
    }
}