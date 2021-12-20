using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject[] chunkPrefabs;
    private static int spawnCooldownSeconds;
    public Vector3 spawnPosition;
    void Start()
    {
        spawnCooldownSeconds = 2;
        spawnPosition = new Vector3(10, -4, 100);
        Invoke("Spawn", 4);
    }

    void Spawn()
    {
        int index = UnityEngine.Random.Range(0, chunkPrefabs.Length);
        Instantiate(chunkPrefabs[index], spawnPosition, Quaternion.identity);
        Invoke("Spawn", spawnCooldownSeconds);
    }

    public static void SetSpawnColldownSeconds(int seconds)
    {
        spawnCooldownSeconds = seconds;
    }
}
