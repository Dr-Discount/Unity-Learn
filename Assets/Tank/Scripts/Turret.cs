using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;
    [SerializeField] float fireRate = 1.0f;
    float fireTimer = 1.0f;

    private void Start()
    {
        fireTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer <= 0)
        {
            Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
            fireTimer = fireRate;
        } else { 
            fireTimer -= Time.deltaTime;
        }
    }
}
