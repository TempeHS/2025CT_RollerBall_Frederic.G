using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false); // Make Object 2 disappear
        }
    }
}
