using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; PlayerInput playerinput;

    Vector2 input;
    
    [SerializeField] float force;

    void Awake() { rb = GetComponent<Rigidbody2D>(); playerinput = GetComponent<PlayerInput>(); }

    private void Update() { input = playerinput.actions["Move"].ReadValue<Vector2>(); }

    private void FixedUpdate() { rb.AddForce(new Vector2(input.x, input.y) * force, ForceMode2D.Impulse); }
}