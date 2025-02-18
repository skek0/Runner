using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour, IHitable
{
    [SerializeField] UnityEvent callback;

    public void Activate()
    {
        callback?.Invoke();
    }
}
