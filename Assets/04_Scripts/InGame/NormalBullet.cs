using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : IBullet
{
    public float moveSpeed;


    public Vector3 offset;
    public float rotateSpeed;
    private void FixedUpdate()
    {
        if (canMove)
            Move();
    }
    public override void Move()
    {
        base.Move();
        Vector3 dir = (target.transform.position - transform.position).normalized;
        rb.velocity = dir * moveSpeed * Time.fixedDeltaTime;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion diff = Quaternion.Euler(new Vector3(0, 0, angle + offset.z));
        transform.localRotation = Quaternion.Slerp(transform.rotation, diff, rotateSpeed * Time.deltaTime);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
    //    {
    //        gameObject.SetActive(false);
    //        //collision.gameObject.TryGetComponent<EnemyData>(out EnemyData enemyData);
    //    }
    //}
}
