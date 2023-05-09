using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float firstSpawnDelay = 2f;
    [SerializeField] private float regularSpawnInterval = 10f;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Material[] ghostMaterials;
   
    private Transform target;
    
    private List<GameObject> spawnList;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Spawn ghosts repeatedly with a first spawn, and regular regular spawn interval
        InvokeRepeating("SpawnGhost", firstSpawnDelay, regularSpawnInterval);
    }

    private void SpawnGhost()
    {
        if (target == null) return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject ghost = Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity, transform);

        // Set the ghost material list for the ghost
        if (ghost.TryGetComponent(out Renderer ghostRenderer))
            ghostRenderer.materials = new[] { ghostMaterials[Random.Range(0, ghostMaterials.Length)] };

        // Set the target of the ghost to the player object
        if (ghost.TryGetComponent(out GhostMovement ghostMovement))
            ghostMovement.target = target;

    }
}