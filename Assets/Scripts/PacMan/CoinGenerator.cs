using System;
using Unity.Mathematics;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int gridSizeX = 14;
    [SerializeField] private int gridSizeZ = 14;

    private void Awake()
    {
        ScoreManager.GetScoreManager().Reset();
    }

    void Start()
    {
        for (int x = -14; x < gridSizeX; x++)
        {
            for (int z = -14; z < gridSizeZ; z++)
            {
                Vector3 position = new Vector3(x+0.5f, 0.5f, z+0.5f);
                Instantiate(prefab, position, quaternion.identity, transform);
                ScoreManager.GetScoreManager().AddCoin();
            }
        }
        
    }
}