using System.Collections.Generic;
using UnityEngine;

public class PatternFactory : MonoBehaviour
{
    public List<GameObject> patternPrefabs;
    public float minInterval = 1f;          // 최소 생성 간격
    public float maxInterval = 3f;          // 최대 생성 간격

    private float timer = 0f;
    private float nextSpawnTime = 1f;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnPattern();
            timer = 0f;
        }
    }

    void SpawnPattern()
    {
        int index = Random.Range(0, patternPrefabs.Count);
        GameObject pattern = Instantiate(patternPrefabs[index]);
        pattern.transform.position = transform.position;

        PatternInfo info = pattern.GetComponent<PatternInfo>();
        nextSpawnTime = info != null ? Random.Range(info.spawnInterval, info.spawnInterval * 1.2f) : 2f;
    }
}
