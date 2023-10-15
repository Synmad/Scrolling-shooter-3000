using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShield : MonoBehaviour
{
    bool ready;
    public bool activated { get; private set; }

    [SerializeField] float duration;
    [SerializeField] float cooldown;

    public void ShieldInput(InputAction.CallbackContext callbackcontext)
    {
        if (callbackcontext.performed) { Shield(); }
    }

    void Shield()
    {
        if (ready) { Activate(); }
        else { return; }
    }

    void Activate()
    {
        activated = true; ready = false;
        StartCoroutine(Deactivate());
        StartCoroutine(ResetCooldown());
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(duration);
        activated = false;
    }

    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        ready = true;
    }
}
