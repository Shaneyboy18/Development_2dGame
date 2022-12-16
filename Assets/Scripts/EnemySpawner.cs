using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private float EnemyInterval = 3f;

    void Start()
    {
        StartCoroutine(spawnEnemy(EnemyInterval, Enemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(21, 23), Random.Range(51, 53), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
