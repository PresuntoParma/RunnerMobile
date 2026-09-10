using System.Collections.Generic;
using System;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    [SerializeField] private List<GameObject> spawnedTiles;
    [SerializeField] private int startingTilesCount;
    private GameObject lastTile;
    private Vector3 spawnPos;

    private void Start()
    {
        for (int i = 0; i < startingTilesCount; i++)
        {
            if (i == 0)
            {
                lastTile =  Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)], transform.position, Quaternion.identity);
                spawnedTiles.Add(lastTile);
            }
            else
            {
                spawnPos = spawnedTiles[spawnedTiles.Count - 1].GetComponent<BaseTile>().endTile.position;
                lastTile = Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)], spawnPos, Quaternion.identity);
                spawnedTiles.Add(lastTile);
            }
        }
    }

    public void CreateTile()
    {
        spawnPos = spawnedTiles[spawnedTiles.Count - 1].GetComponent<BaseTile>().endTile.position;
        lastTile = Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)], spawnPos, Quaternion.identity);
        spawnedTiles.Add(lastTile);
        Destroy(spawnedTiles[0]);
        spawnedTiles.Remove(spawnedTiles[0]);
    }
}
