using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpawnScript : MonoBehaviour
{
    public const float DEFAULT_OFFSET = 3.5f;
    public const float SPAWN_ANGLE_RANGE = 30f;

    public Transform[] spawnPoints;
    public GameObject[] cats;
    public GameObject gift;
    public GameObject metalPipe;

    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        Vector3 spawnPosition;
        float angle, sx, sz, sy;
        int sprite;

        while (true) {
            angle = Random.Range(-SPAWN_ANGLE_RANGE, SPAWN_ANGLE_RANGE);
            sx = DEFAULT_OFFSET * Mathf.Sin(angle / 180 * Mathf.PI);
            sy = Random.Range(-0.5f, 0.5f);
            sz = DEFAULT_OFFSET * Mathf.Cos(angle / 180 * Mathf.PI);
            spawnPosition = new Vector3(sx, sy, sz);
            
            if(Random.Range(0f, 1f) > 0.9f)
            {
                // Gift (metalpipe)
                Instantiate(gift, spawnPosition, Quaternion.identity);
            }
            else
            {
                // "enemy" (it's not)
                sprite = Random.Range(0, cats.Length);
                Instantiate(cats[sprite], spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(2);
        }
    }
}
