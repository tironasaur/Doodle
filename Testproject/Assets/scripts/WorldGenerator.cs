using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] int numberofplatforms = 1;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] GameObject coinPrefab;

    [Space(20)]
    
    [SerializeField] float levelWidth = 3f; //laynutyuny platformi haytnvelu
    [SerializeField] float minY = 0f; //cacrutyunn
    [SerializeField] float maxY = 0f; //u bardzrutyuny platformi max
   
    [SerializeField] float enemyMinY = 0.8f;
    [SerializeField] float enemyMaxY = 0.8f;
   
    [SerializeField] float shieldMinY = 0.8f;
    [SerializeField] float shieldMaxY = 0.8f;
   
    [SerializeField] float coinsMinY = 2f;
    [SerializeField] float coinsMaxY = 2f;

    private int distanceunit = 0;

    private float spawnRate = 2f; //enemy-ner stexcelu hamara
    private float nextSpawn = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("distance", 0);
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberofplatforms; i++)
        {
            if (distanceunit <= 4000)

            {

                maxY += 1.5f;
                minY += 1.5f;

                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            }

            else if (distanceunit <= 10000)

            {

                maxY += 1.7f;
                minY += 1.7f;

                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            }

            else

            {

                maxY += 2f;
                minY += 2f;

                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-levelWidth, levelWidth);

                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            }
        }
    }
    private void Update()
    {
        Vector3 enemyspawnPosition = new Vector3();
        Vector3 shieldspawnPosition = new Vector3();
        Vector3 coinspawnPosition = new Vector3();
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            if (GameObject.FindGameObjectsWithTag("enemy").Length <= 1)

            {
                enemyMaxY += 40f;
                enemyMinY += 41f;
                enemyspawnPosition.y += Random.Range(enemyMinY + 30f, enemyMaxY + 55f);
                enemyspawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(enemyPrefab, enemyspawnPosition, Quaternion.identity);

            }

            if (GameObject.FindGameObjectsWithTag("shield").Length <= 1)

            {
                shieldMinY += 60f;
                shieldMaxY += 70f;
                shieldspawnPosition.y += Random.Range(shieldMinY + 50f, shieldMaxY + 60f);
                shieldspawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(shieldPrefab, shieldspawnPosition, Quaternion.identity);

            }

            if (GameObject.FindGameObjectsWithTag("coins").Length <= 10)

            {
                coinsMinY += 35f;
                coinsMaxY += 35f;
                coinspawnPosition.y += Random.Range(coinsMinY + 2f, coinsMaxY + 2f);
                coinspawnPosition.x = Random.Range(-levelWidth, levelWidth);
                Instantiate(coinPrefab, coinspawnPosition, Quaternion.identity);

            }

        }
    }

    private void distance()
    {
        distanceunit += 100;
    }
}
