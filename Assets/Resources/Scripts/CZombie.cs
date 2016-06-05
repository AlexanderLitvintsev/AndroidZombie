using UnityEngine;
using System.Collections;
using System;

// Monster class
public class CZombie : MonoBehaviour {

    // Monster State
    public enum STATE { IDLE, WALK, ATTACK, DIE }
    public STATE zombieState = STATE.WALK;

    // Hit sound audio clip
    public AudioClip hitAudioClip;


    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    // Player reference
    protected Transform player;

    // Monster hit count
    protected int hitCount = 0;
    // Monster hit effect position
    public Transform hitPoint;
    // Monster attack effect position
    public Transform attackHitPoint;
    // Monster hit effect prefab
    protected UnityEngine.Object hitPrefab;
    // Monster attack hit effect prefab
    protected UnityEngine.Object attackHitPrefab;

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(10, 10);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    // Use this for initialization

    /// <summary>
    /// Total hitpoints
    /// </summary>
    public float hp = 1;

    /// <summary>
    /// Enemy or player?
    /// </summary>
    public bool isEnemy = true;

    /// <summary>
    /// Inflicts damage and check if the object should be destroyed
    /// </summary>
    /// <param name="damageCount"></param>
    /// 
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        hitPrefab = (UnityEngine.Object)Resources.Load("Prefabs/Effects/Hit");
        attackHitPrefab = (UnityEngine.Object)Resources.Load("Prefabs/Effects/AttackHit");
    }

    void Start()
    {
    InitMonster();
    }


    // Monster initialize
    public virtual void InitMonster()
    {
        player = GameObject.Find("Player").transform;

       // StartMove();
    }


    // Update is called once per frame
    void Update()
    {
        
        if (zombieState == STATE.WALK)
        {
            movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
        }

    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    public void Hit()
    {
        GameObject hit_effect = (GameObject)Instantiate(hitPrefab, hitPoint.position, Quaternion.identity);
        Destroy(hit_effect, 0.3f);
        /*
        if (hitCount > 2)
        {
            DoDestroy(1f);
            return;
        }
        */
        hitCount++;

        CGameSound.PlayGameSound(hitAudioClip, transform.position);

        //GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //animator.SetTrigger("Hit");
    }
    // Health Script

    public void Damage(float damageCount)
    {
        hp -= damageCount;

        if (hp <= 0)
        {
            // Dead!
            GetComponent<Animation>().Play("zb_dead1");
            speed.x = 0;
            speed.y = 0;
            DoDestroy(1f);
            //Destroy(gameObject, .7f);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        CBullet Bullet = otherCollider.gameObject.GetComponent<CBullet>();
        if (Bullet != null)
        {
            // Avoid friendly fire
            if (Bullet.isEnemyShot != isEnemy)
            {
                Damage(Bullet.damage);
                Hit();
                // Destroy the shot
                Destroy(Bullet.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
    // Monster Death
    public void DoDestroy(float delay_time = 7f)
    {
        GetComponent<BoxCollider2D>().enabled = false;

        CGameInfo.GAME_SCORE += 1;

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        animator.SetTrigger("Die");

        Destroy(gameObject, delay_time);
    }

}
