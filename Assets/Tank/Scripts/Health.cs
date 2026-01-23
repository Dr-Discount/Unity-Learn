using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    public float HP {
        get {
            return health;
        }
        set { health = Mathf.Clamp(value, 0, maxHealth); }
    }
    bool destroyed = false;

    float health = 0;

    public float HPPercentage
    {
        get { return health / maxHealth; }
    }

    void Start()
    {
        HP = maxHealth;
    }

    public void OnDamage(float damage)
    {
        if (destroyed) return;
        HP -= damage;
        if (HP <= 0) destroyed = true;

        if (!destroyed  && hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (destroyed)
        {
            TankGameManager.Instance.Score += 100;
            if (destroyEffect != null) Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
