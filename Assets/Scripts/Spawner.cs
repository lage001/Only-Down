using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>();
    public float spawnInterval;
    

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector2 randomPosition = new Vector2(Random.Range(-3.5f, 3.5f), transform.position.y);
            float[] array = new float[5] {0, 0.5f, 0.7f, 0.9f, 1f };
            float n = Random.Range(0f, 1f);
            int index = 0;
            for (int i = 0; i < 4;i++)
            {
                if (array[i] <= n && n < array[i + 1])
                {
                    index = i;
                }
            }
            //print(index);
            //int index = Random.Range(0, platforms.Count);
            Instantiate(platforms[index], randomPosition, Quaternion.identity);
        }
        

    }
}
