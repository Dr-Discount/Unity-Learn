using System.Net.Mail;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Actor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform view;

    Actor actor;

    i_attackable attackable;
    i_jumpable jumpable;
    i_movable movable;
    i_spritable sprintable;

    private void Awake()
    {
        actor = GetComponent<Actor>();
        view ??= Camera.main.transform;

        movable = actor as i_movable;
        attackable = actor as i_attackable;
        jumpable = actor as i_jumpable;
        sprintable = actor as i_spritable;
    }


    void OnJump()
    {
        jumpable?.Jump();
    }

    void OnAttack()
    {
        attackable?.Attack();
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Vector3 moveDirection = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * new Vector3(input.x, 0, input.y);
        movable?.Move(moveDirection);
    }

    void OnSprint(InputValue value)
    { 
        if (value.isPressed) sprintable?.StartSprint();
        else sprintable?.StopSprint();
    }
}
