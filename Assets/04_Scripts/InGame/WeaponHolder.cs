using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed;
    public Vector3 offset;
    public List<Transform> listSpawnBullet = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {

    }
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.Instance.isStart) return;
        SetTarget();
        time += Time.deltaTime;
        if (time > 1&&target!=null)
        {
            Shoot();
            time = 0;
        }
    }
    private void SetTarget()
    {
        target = PlayerController.Instance.playerData.fov.GetClosestTarget();
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion diff = Quaternion.Euler(new Vector3(0, 0, angle + offset.z));
            transform.localRotation = Quaternion.Slerp(transform.rotation, diff, rotateSpeed * Time.deltaTime);
        }
        //else
        //    Debug.LogError("You must have a target");
    }
    private void Shoot()
    {
        GameObject bullet = ObjectPooling.instance.GetObjectFromPool("NormalBullet");
        bullet.GetComponent<NormalBullet>().Setup(5, target, transform, "Player");
        bullet.SetActive(true);
    }

}
