using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float heightOfSet = 5f;
   

    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipes(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            spawnPipes();
            timer = 0f;
        }

    }

    void spawnPipes()
    {
        float lowestPoint = transform.position.y - heightOfSet;
        float highestPoint = transform.position.y + heightOfSet;
        float randomY = Random.Range(lowestPoint, highestPoint);

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, 0);

        Instantiate(pipePrefab, spawnPosition, transform.rotation);
    }
}
