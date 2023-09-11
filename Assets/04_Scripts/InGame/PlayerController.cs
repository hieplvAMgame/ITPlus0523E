using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>, IGameSubcriber
{
    public Animator anim;
    public Rigidbody2D rb;
    public float moveSpeed;
    public SpriteRenderer spriteRenderer;

    private Vector3 dir, vel;
    private float x, y;
    private const string Hor = "Horizontal";
    private const string Ver = "Vertical";
    private const string Move = "isMove";

    public bool isStart = false;
    public WeaponHolder holder;
    public PlayerData playerData;
    public Button btnStart;

    private void Start()
    {
        GameManager.Instance.AddSubcriber(this);
        btnStart.onClick.AddListener(() =>
        {
            isStart = true;
            btnStart.gameObject.SetActive(false);
        });
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        x = Input.GetAxis(Hor);
        y = Input.GetAxis(Ver);

        dir = new Vector3(x, y);
        vel = dir.normalized * moveSpeed;
        Shoot();
    }
    private void FixedUpdate()
    {
        if (!isStart) return;
        if (dir.magnitude > .1f)
        {
            //Cho player di chuyen
            rb.velocity = vel * Time.fixedDeltaTime;
        }
        else
            rb.velocity = Vector2.zero;
        Animate(dir.magnitude > .1f);
        if (x > 0)
            //transform.eulerAngles = Vector3.zero;
            spriteRenderer.flipX = false;
        else if (x < 0)
            //transform.eulerAngles = Vector3.up * 180;
            spriteRenderer.flipX = true;
    }
    private void Animate(bool isMove)
    {
        anim.SetBool(Move, isMove);
    }
    private GameObject bulletTemp;
    public void Shoot()
    {
        if (!isStart) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SHOOT");
            bulletTemp = ObjectPooling.instance.GetObjectFromPool(TYPE_BULLET.NormalBullet);
            bulletTemp.GetComponent<NormalBullet>().Setup(playerData.Damage,
                holder.target, holder.listSpawnBullet[0], gameObject.tag);
            bulletTemp.SetActive(true);
        }
    }

    public void GamePrepare()
    {
        Debug.Log("Prepare Player");
        transform.position = GameManager.Instance.genLevel.listLevel[0].posPlayer;
        playerData.Setup();
        isStart = false;
    }

    public void GameStart()
    {
        isStart = true;
        Debug.Log("Start Player");
    }

    public void GamePause()
    {
        isStart = false;
    }

    public void GameResume()
    {
        isStart = true;
    }

    public void GameWin()
    {
        isStart = false;
    }

    public void GameLose()
    {
        isStart = false;
    }
}
