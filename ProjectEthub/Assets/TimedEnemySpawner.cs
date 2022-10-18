using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEnemySpawner : MonoBehaviour {
    [SerializeField]
    private GameObject swamerPrefab;

    private float interval = 10f;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(spawnEnemy(interval, swamerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy) {
        yield return new WaitForSeconds(Random.Range(interval - 8f, interval));
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
