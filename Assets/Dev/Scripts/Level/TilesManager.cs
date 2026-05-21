using UnityEngine;

public class TilesManager : MonoBehaviour
{
    [SerializeField] private GameObject tile;

    public void CreateTile(Vector3 pos)
    {
        Instantiate(tile, pos, Quaternion.identity);
    }
}
