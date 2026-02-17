using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] List<IItem> items;

    public IItem currentItem;

    void Start()
    {
        currentItem = items[0];    
    }

    void Update()
    {
        
    }
}
