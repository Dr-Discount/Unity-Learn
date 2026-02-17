using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : Ammo
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed = 100.0f;
    [SerializeField] float lifetime = 5f;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Projectile requires a Rigidbody. Add one to the projectile prefab.", this);
        }
    }

    void OnEnable()
    {
        // Defensive re-check in case component was added/changed at runtime
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (rb == null) return;

        // Ensure the rigidbody will respond to physics
        rb.isKinematic = false;
        rb.useGravity = false;

        // Safer collision detection for fast-moving objects
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Make sure projectile is not parented (parented objects won't be simulated independently)
        if (transform.parent != null)
            transform.SetParent(null, true);

        // Set velocity using the projectile's forward direction at the moment of spawn
        rb.linearVelocity = transform.forward * speed;
        rb.WakeUp();

        // Safety: destroy after a short time to avoid leaked projectiles
        Destroy(gameObject, lifetime);

        Debug.Log($"Projectile fired (OnEnable): name={gameObject.name} pos={transform.position} forward={transform.forward} velocity={rb.linearVelocity}", this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.OnDamage(damage);
        }

        if (effect != null)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
