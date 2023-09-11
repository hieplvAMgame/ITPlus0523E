using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleBullet : IBullet
{
    public float moveSpeed;
    public float steerValue;

    private void FixedUpdate()
    {
        Move();
    }
    public override void Move()
    {
        base.Move();
        rb.velocity = transform.up * moveSpeed * Time.fixedDeltaTime;
        Vector2 dir = (target.position - transform.position).normalized;
        float rotSteer = Vector3.Cross(transform.up, dir).z;
        rb.angularVelocity = rotSteer * steerValue;
    }

}
