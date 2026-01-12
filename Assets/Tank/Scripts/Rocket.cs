using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed = 100.0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
