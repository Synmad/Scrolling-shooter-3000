using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; PlayerInput playerinput;

    Vector2 input;
    
    [SerializeField] float defaultForce;
    [SerializeField] float boostedForce;
    float force;
    bool boosted;

    [SerializeField] float boostDuration;
    float remainingTime;

    void Awake() { rb = GetComponent<Rigidbody2D>(); playerinput = GetComponent<PlayerInput>(); }

    private void Update() 
    { 
        input = playerinput.actions["Move"].ReadValue<Vector2>();

        if (boosted)
        {
            force = boostedForce;
            remainingTime -= Time.deltaTime;
        }
        if(remainingTime <= 0)
        {
            boosted = false;
            force = defaultForce;
        }
    }

    private void FixedUpdate() => rb.AddForce(new Vector2(input.x, input.y) * force, ForceMode2D.Impulse); 

    public void SpeedUp()
    {
        force = boostedForce;
        remainingTime = boostDuration;
        boosted = true;   
    }
}