using UnityEngine;

public interface IEquipable
{
    void OnEquip(Actor owner);
    void OnUnEquip(Actor owner);
}
