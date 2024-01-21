using UnityEngine;


public class Fruit : MonoBehaviour
{
    public int fruitLevel = 1;
    public GameObject fruitPrefab;
    public GameObject bubbleParticleSystemPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit != null && otherFruit.fruitLevel == fruitLevel)
        {
            if (bubbleParticleSystemPrefab != null)
            {
                Instantiate(bubbleParticleSystemPrefab, transform.position, Quaternion.identity);
            }
            MergeFruits(otherFruit);
        }
    }

    private void MergeFruits(Fruit otherFruit)
    {
        fruitLevel++;

       
        Vector3 newScale = Vector3.one * fruitLevel * 0.25f;
        GameObject newFruit = Instantiate(fruitPrefab, transform.position, Quaternion.identity);
        newFruit.transform.localScale = newScale;

        Destroy(gameObject);
        Destroy(otherFruit.gameObject);
    }
}
