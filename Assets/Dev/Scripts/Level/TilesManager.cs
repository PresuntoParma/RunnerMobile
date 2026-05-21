using System;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] tiles;
    private GameObject[] spawnedTiles;
    private Vector3 spawnPos;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == 0)
            {
                Array.Resize(ref spawnedTiles, tiles.Length + 1);
                tiles[tiles.Length - 1] =  Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)], transform.position, Quaternion.identity);
            }
            else
            {
                spawnPos = tiles[tiles.Length - 1].GetComponent<BaseTile>().endTile.position;
                Array.Resize(ref spawnedTiles, tiles.Length + 1);
                tiles[tiles.Length - 1] = Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)], spawnPos, Quaternion.identity);
            }
        }
    }

    public void CreateTile(Vector3 pos)
    {
        spawnPos = tiles[tiles.Length - 1].GetComponent<BaseTile>().endTile.position;
        Array.Resize(ref spawnedTiles, tiles.Length + 1);
        tiles[tiles.Length - 1] = Instantiate(tiles[UnityEngine.Random.Range(0, tiles.Length)], spawnPos, Quaternion.identity);
    }
}
