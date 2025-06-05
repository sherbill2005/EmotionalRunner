using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform player;
    public List<GameObject> grounds;
    public float spawnTriggerDistance = 100f;
    public float chunkDestroybuffer = 20f;

    private Vector3 nextSpawedPos;
    private List<GameObject> activeGrounds = new List<GameObject>();
    private float fixedY = -5.82f;

    void Start()
    {
        GameObject firstGround = Instantiate(grounds[0], new Vector3(0, fixedY, 0), Quaternion.identity);
        activeGrounds.Add(firstGround);

        float firstWidth = GetGroundWidth(firstGround);
        nextSpawedPos = new Vector3(firstGround.transform.position.x + firstWidth, fixedY, 0f);
    }

    void Update()
    {
        if (Vector2.Distance(player.position, nextSpawedPos) < spawnTriggerDistance)
        {
            SpawnNextGround();
        }
        ChuckDestroy();
    }

    void SpawnNextGround()
    {
        int index = Random.Range(0, grounds.Count);
        GameObject nextGround = Instantiate(grounds[index], nextSpawedPos, Quaternion.identity);

        float width = GetGroundWidth(nextGround);
        nextSpawedPos = new Vector3(nextGround.transform.position.x + width, fixedY, 0f);

        activeGrounds.Add(nextGround);
        Debug.DrawLine(nextGround.transform.position, nextGround.transform.position + Vector3.up * 5f, Color.red, 5f);

    }

    float GetGroundWidth(GameObject ground)
    {
        Renderer col = ground.GetComponentInChildren<Renderer>();
        return col != null ? col.bounds.size.x : 20f;
    }
    void ChuckDestroy()
    {
        if (activeGrounds.Count <= 2) return;
        GameObject oldestChunk = activeGrounds[0];
        float chuckRightEdge = oldestChunk.GetComponentInChildren<Renderer>().bounds.size.x;

        Destroy(oldestChunk);
        activeGrounds.RemoveAt(0);


    }
}
