using System.Collections.Generic;
using UnityEngine;

public class levelgenarator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> chunkPrefabs;
    public float spawnTriggerDistance = 50f;
    public float chunkDestroybuffer = 20f;

    private Vector3 nextSpawnPosition;
    private GameObject lastSpawnedChunk;
    private List<GameObject> activeChunks = new List<GameObject>();

    void Start()
    {
        // Start by spawning the first chunk
        GameObject firstChunk = Instantiate(chunkPrefabs[0], Vector3.zero, Quaternion.identity);
        lastSpawnedChunk = firstChunk;
        activeChunks.Add(firstChunk);
        // Set initial next spawn position
        nextSpawnPosition = lastSpawnedChunk.transform.position + new Vector3(GetChunkWidth(firstChunk), 0f, 0f);
    }

    void Update()
    {
        if (Vector2.Distance(player.position, nextSpawnPosition) < spawnTriggerDistance)
        {
            SpawnNextChunk();
        }

        cleanOldChuck();
    }

    void SpawnNextChunk()
    {
        // Pick a random chunk (or alternate)
        int index = Random.Range(0, chunkPrefabs.Count);
        GameObject newChunk = Instantiate(chunkPrefabs[index], nextSpawnPosition, Quaternion.identity);

        // Update the next spawn position
        nextSpawnPosition = newChunk.transform.position + new Vector3(GetChunkWidth(newChunk), 0f, 0f);

        lastSpawnedChunk = newChunk;
        activeChunks.Add(newChunk);
    }

    float GetChunkWidth(GameObject chunk)
    {
        // Make sure each chunk has a BoxCollider2D that covers the chunk
        BoxCollider2D col = chunk.GetComponent<BoxCollider2D>();
        if (col != null)
            return col.size.x;
        else
            return 20f; // fallback value
    }
    void cleanOldChuck()
    {
        if (activeChunks.Count <= 2) return;
        GameObject oldestChunk = activeChunks[0];
        float chuckRightEdge = oldestChunk.GetComponent<BoxCollider2D>().size.x;
        if (chuckRightEdge < player.position.x - chunkDestroybuffer)
        {
            Destroy(oldestChunk);
            activeChunks.RemoveAt(0);
        }
     }
}
