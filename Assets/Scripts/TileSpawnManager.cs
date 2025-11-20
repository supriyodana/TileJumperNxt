using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public Transform player;
    public GameObject tilePrefab;

    // public GameObject[] tileprefabs;
    public int poolSize = 20;

    private Queue<GameObject> tilePool = new Queue<GameObject>();
    private float spawnZ = 70f;  
    private float jumpDis = 10f;
    private float laneOffset = 3f;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(tilePrefab);
            obj.SetActive(false);
            tilePool.Enqueue(obj);
        }

        // Spawn some initial tiles beyond the 100f if needed  //remove
        // for (int i = 0; i < 10; i++)
        //     SpawnTilePattern();
    }


    private void Update()
    {
        if (player.position.z + 60 > spawnZ)
        {
            SpawnTilePattern();
            // Debug.Log("tilePatternSpawne-----------");
            // Debug.Log(player.position.z.ToString());
        }
    }

    private void SpawnTilePattern()
    {

        int lane = Random.Range(0, 2);
        float x = (lane == 0) ? -laneOffset : laneOffset;

        SpawnSingleTile(new Vector3(x, 0, spawnZ));

        spawnZ += jumpDis;
    }

    private void Pattern2()
    {
        //

    }

    private void SpawnSingleTile(Vector3 pos)
    {
        GameObject tile = tilePool.Dequeue();
        tile.SetActive(true);
        tile.transform.position = pos;

        tilePool.Enqueue(tile);
    }
}
