using UnityEngine;
using System.Collections;

// Bullet class
public class CBullet : MonoBehaviour {

    // Bullet damage
    public float damage;

    // Bullet speed
    public float speed;

    // Pojectile damage player or enemies? 
    public bool isEnemyShot = false;

    // Bullet initialize
    public void InitBullet(Vector2 shoot_relative_position)
    {
        RotateBullet(shoot_relative_position);

        GetComponent<Rigidbody2D>().AddForce(shoot_relative_position.normalized * speed);
    }

    // Rotate bullet
    public void RotateBullet(Vector3 shoot_relative_position)
    {
        float angle = Mathf.Atan2(shoot_relative_position.y, shoot_relative_position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Destroy bullet
    public void DoDestroy(float delay_time = 0f)
    {
        Destroy(gameObject, delay_time);
    }
}
