using System.Collections.Generic;
using UnityEngine;

public class TurretBulletPool : MonoBehaviour
{
    public static TurretBulletPool instance;

    //Represents a bullet which is put in the pool
    [SerializeField]
    private GameObject pooledBullet;

    //Used to help to add more bullets to the pool when needed
    private bool bulletsInPoolLow = true;

    //The pool
    private List<GameObject> bullets;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (bulletsInPoolLow)
        {
            GameObject newBullet = Instantiate(pooledBullet);
            newBullet.SetActive(false);
            bullets.Add(newBullet);
            return newBullet;
        }
        return null;
    }
}