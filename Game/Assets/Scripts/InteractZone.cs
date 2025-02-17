using UnityEngine;

public class InteractZone : MonoBehaviour, IHitable
{
    private void OnTriggerEnter(Collider other)
    {
        IHitable clone = other.GetComponent<IHitable>();

        if(clone != null)
        {
            clone.Activate();
        }
    }
    public void Activate()
    {
        Debug.Log("activated");
    }
}
