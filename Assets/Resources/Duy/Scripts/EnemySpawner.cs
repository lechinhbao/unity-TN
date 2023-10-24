using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmInterval, bigSwarmPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
     yield return new WaitForSeconds(interval);
    GameObject newEnemy = Instantiate (enemy, new Vector3(Random.Range(-1f, 1) , Random.Range(-1f, 1), 0), Quaternion.identity);
    //StartCoroutine(Spawn (interval, enemy));
    }
}
