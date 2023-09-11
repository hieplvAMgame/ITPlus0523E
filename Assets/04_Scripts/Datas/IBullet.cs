using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBullet : MonoBehaviour
{
    public int damage;
    public string tagOrigin = string.Empty;     // where bullet shoot
    public Rigidbody2D rb;
    public Transform target;
    //public Transform parentTrans;
    public bool canMove = false;
    /// <summary>
    /// Set up every bullet
    /// </summary>
    /// <param name="_damage"> damage of bullet</param>
    /// <param name="_target">Transform of target for make bullet move toward it</param>
    /// <param name="_parentTrans">Transform parent of bullet</param>
    /// <param name="_tagOrigin">Tag's Object shoot this bullet</param>
    public virtual void Setup(int _damage, Transform _target, Transform _parentTrans, string _tagOrigin)
    {
        damage = _damage;
        target = _target;
        //parentTrans = _parentTrans;
        transform.position = _parentTrans.position;
        tagOrigin = _tagOrigin;
        canMove = true;
    }
    public virtual void Move()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(GAME_TAG.Player) && tagOrigin.Equals(GAME_TAG.Enemy))
        {
            PlayerController.Instance.playerData.OnTakenDamage(damage);
            Debug.Log("SHOOT PLAYER");
            gameObject.SetActive(false);
        }
        if (col.gameObject.CompareTag(GAME_TAG.Enemy) && tagOrigin.Equals(GAME_TAG.Player))
        {
            //col.gameObject.SetActive(false);
            Debug.Log("Shoot enemy");
            col.gameObject.GetComponent<EnemyData>().OnTakenDamage(damage);
            gameObject.SetActive(false);
        }
        if(col.gameObject.CompareTag(GAME_TAG.Wall))
        {
            gameObject.SetActive(false);
        }
    }
}
