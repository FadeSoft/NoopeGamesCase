using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public DynamicJoystick dynamicJoystick;
    public float movementSpeed;
    public float rotationSpeed;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
            Movement();

        else if (Input.GetButtonUp("Fire1"))
            SetAnimator(false, true);
    }
    private void Movement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;

        Vector3 pos = new Vector3(horizontal, 0, vertical) * Time.deltaTime * movementSpeed;
        transform.position += pos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-direction), rotationSpeed * Time.deltaTime);
        //Quaternion.LookRotation(-direction) burada -direction dememin sebebi modelin local rotasyonunun bozuk olmasý

        if (dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
            SetAnimator(true, false);

        else if (dynamicJoystick.Horizontal == 0 || dynamicJoystick.Vertical == 0)
            SetAnimator(false, true);

    }

    private void SetAnimator(bool runState, bool idleState)
    {
        animator.SetBool("Run", runState);
        animator.SetBool("Idle", idleState);
    }
}
