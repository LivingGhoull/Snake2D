using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] GameObject apple;

    Vector3Int spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        SpawnApple();
    }

    public void SpawnApple()
    {
        spawnPosition.y = Random.Range(-9, 10);
        spawnPosition.x = Random.Range(-9, 10);
        Instantiate(apple, spawnPosition, Quaternion.identity);
    }
}