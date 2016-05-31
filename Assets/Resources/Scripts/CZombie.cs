using UnityEngine;
using System.Collections;
using System;

// Monster class
public class CZombie : MonoBehaviour {

    // Monster State
    public enum STATE { IDLE, WALK, ATTACK, DIE }
    public STATE zombieState = STATE.WALK;

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
            Destroy(gameObject, .7f);
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

                // Destroy the shot
                Destroy(Bullet.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }

    
}
