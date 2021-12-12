using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float speedRotate;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    public GameObject player;

    public void FixedUpdate()
    {
        Direction();
    }

    void Direction()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        Quaternion lookR = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, lookR, Time.deltaTime * speedRotate);
    }
}