using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
	private Transform player;

	[SerializeField] private GameObject[] tilePrefabs;

    [SerializeField] private float tileLength = 12;
    [SerializeField] private int nbrOfTiles = 3;
	[SerializeField] private int totalNumOfTiles = 6;

    private List<GameObject> activeTiles;
    private int previousIndex;
	private float zSpawn = 0;

    void Start()
	{
		player = FindObjectOfType<PlayerController>().transform;

		activeTiles = new List<GameObject>();
		for (int i = 0; i < nbrOfTiles; i++)
		{
			if (i == 0)
				SpawnTile();
			else
				SpawnTile(Random.Range(1, totalNumOfTiles));
		}

	}

	void LateUpdate()
    {
        if(player.position.z - 17 >= zSpawn - (nbrOfTiles * tileLength))
        {
            int index = Random.Range(1, totalNumOfTiles);
            int n = 0;
            while(index == previousIndex && n < 10){
            	index = Random.Range(1, totalNumOfTiles);
            	n++;
            }
            SpawnTile(index);
        }
    }

    public void SpawnTile(int index = 0)
    {
        GameObject tile = Instantiate(tilePrefabs[index], Vector3.forward * zSpawn, Quaternion.identity,transform);
        activeTiles.Add(tile);
        zSpawn += tileLength;
        previousIndex = index;
    }
}
