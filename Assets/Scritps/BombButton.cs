using UnityEngine;
using UnityEngine.UI;

public class BombButton : MonoBehaviour
{
    public GameObject bombPrefab;

    private bool isTrackingMouse = false;
    private Vector3 bombPlacementPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isTrackingMouse)
            {
                
                isTrackingMouse = true;
            }
            else
            {
                
                isTrackingMouse = false;
                PlaceBomb();
            }
        }

        if (isTrackingMouse)
        {
            
            bombPlacementPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            bombPlacementPosition.z = 0f; 
        }
    }

    void PlaceBomb()
    {
        
        Instantiate(bombPrefab, bombPlacementPosition, Quaternion.identity);
    }
}
