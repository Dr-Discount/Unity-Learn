using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent triggerEvent;
    [SerializeField, Tooltip("Tag od object to trigger.")] string tagName; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
            triggerEvent.Invoke();
    }
}
