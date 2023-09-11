using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float radius;
    //private CircleCollider2D col;
    public List<GameObject> enemies = new List<GameObject>();
    public Collider2D[] result;

    private void Awake()
    {
        //col = GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetupRange(50);
    }
    List<Collider2D> cols;
    // Update is called once per frame
    void Update()
    {
        result = Physics2D.OverlapCircleAll(transform.position, radius, LayerMask.GetMask("Enemy"));
    }

    //public void SetupRange(float range)
    //{
    //    radius = range;
    //    col.radius = radius;
    //}
    public Transform GetClosestTarget()
    {
        float dis = Mathf.Infinity;
        Transform _result = null;
        if (result.Length > 0)
        {
            foreach (var item in result)
            {
                Vector3 diff = item.transform.position - transform.position;
                if (diff.magnitude < dis)
                {
                    dis = diff.magnitude;
                    _result = item.transform;
                }
            }
        }
        return _result;
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag(GAME_TAG.Enemy))
    //    {
    //        enemies.Add(other.gameObject);            //enemies la List<GameObject>
    //        Debug.LogError(other.name);
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag(GAME_TAG.Enemy))
    //    {
    //        enemies.Remove(other.gameObject);
    //    }
    //}
}
