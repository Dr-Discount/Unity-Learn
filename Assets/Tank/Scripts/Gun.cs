using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Ammo ammo;
    [SerializeField] Transform muzzle;
    [SerializeField] float fireRate = 1.0f;
    [SerializeField] int maxAmmoCount = 20;

    private int ammoCount;
    public int AmmoCount
    {
        get { return ammoCount; } 
        set { AmmoCount = Mathf.Clamp(value, 0, maxAmmoCount); }
    }

    public bool isReadyToFire { get; set; } = true;

    void Start()
    {
        AmmoCount = maxAmmoCount;
    }

    public void onFire()
    {
        if (isReadyToFire && AmmoCount > 0)
        {
            AmmoCount--;
            Instantiate(ammo, muzzle.position, muzzle.rotation);
            isReadyToFire = false;
            StartCoroutine(ResetFireCR());
        }
    }

    IEnumerator ResetFireCR()
    {
        yield return new WaitForSeconds(fireRate);
        isReadyToFire = true;
    }
}
