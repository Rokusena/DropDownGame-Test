using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject targetObject;

    
    public void ToggleObject()
    {
        if (targetObject != null)
        {
            
            targetObject.SetActive(!targetObject.activeSelf);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!");
        }
    }
}
