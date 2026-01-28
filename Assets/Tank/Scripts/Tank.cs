using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Tank : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotationSpeed = 90.0f;
    
    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;

    [SerializeField] Slider healthBar;

    InputAction moveAction;
    InputAction attackAction;

    Health health;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        health = GetComponent<Health>();
    }
    void Update()
    {
        float direction = 0.0f;
        if (Keyboard.current.wKey.isPressed) direction = +1.0f;
        if (Keyboard.current.sKey.isPressed) direction = -1.0f;
        
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);
        
        float rotation = 0.0f;
        if (Keyboard.current.aKey.isPressed) rotation = -1.0f;
        if (Keyboard.current.dKey.isPressed) rotation = +1.0f;
        
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        healthBar.value = health.HP / health.maxHealth;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
        }
    }
}
