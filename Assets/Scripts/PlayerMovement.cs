using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float movementSpeed;
    public float rotationSpeed;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Movement();
        }
    }
    private void Movement()
    {
        float horizontal = dynamicJoystick.Horizontal;
        float vertical = dynamicJoystick.Vertical;
        Vector3 pos = new Vector3(horizontal, 0, vertical) * Time.deltaTime * movementSpeed;
        transform.position += pos;

        Vector3 direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-direction), rotationSpeed * Time.deltaTime);
        //Quaternion.LookRotation(-direction) burada -direction dememin sebebi modelin localrotasyonunun bozuk olmasý
    }
}
