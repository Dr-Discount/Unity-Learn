using UnityEngine;

public interface IItem
{
    void OnPickup(Actor owner);
    void OnDrop(Actor owner);
}
