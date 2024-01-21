using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruitPrefabs;
    public float minYpos;
    public float minXpos;
    public float maxXpos;
    public float maxYpos;
    public float spawnDelay = 2.0f;

    private Camera mainCamera;
    private float lastSpawnTime;
    private AudioSource audioSource;  // Reference to the existing AudioSource component

    void Start()
    {
        mainCamera = Camera.main;
        lastSpawnTime = Time.time;

        // Get the existing AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Check if an AudioSource component exists
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }
    }

    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -mainCamera.transform.position.z));
        float space = Mathf.Clamp(mousePosition.x, minXpos, maxXpos);
        transform.position = new Vector3(space, Mathf.Clamp(transform.position.y, minYpos, maxYpos), transform.position.z);

        if (Time.time - lastSpawnTime >= spawnDelay && Input.GetMouseButtonDown(0))
        {
            SpawnFruit();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnFruit()
    {
        int randomLevel = Random.Range(1, 4);
        int index = Mathf.Clamp(randomLevel - 1, 0, fruitPrefabs.Count - 1);

        GameObject newFruit = Instantiate(fruitPrefabs[index], transform.position, Quaternion.identity);
        newFruit.GetComponent<Fruit>().fruitLevel = randomLevel;

        // Play the spawn sound using the existing AudioSource
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
