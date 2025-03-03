using UnityEngine;

public class InteractZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IHitable clone = other.GetComponent<IHitable>();

        clone?.Activate();
    }
}