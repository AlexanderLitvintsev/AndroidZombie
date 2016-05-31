using UnityEngine;
using System.Collections;

// Player gun class
public class CGun : MonoBehaviour {

    // Bullet prefab
    protected Object bulletPrefab;

    // Fire sound audioclip
    public AudioClip audioClip;

    // Fog prefab
    public Object fogPrefab;

	// Bullet prefab load
	void Start () {

        LoadBulletPrefab();
	}

    // Fire
    public void Fire(Vector2 shoot_relative_position)
    {
        GameObject fog = (GameObject)Instantiate(fogPrefab, new Vector3(-3.8f, 1.5f, 0f), Quaternion.identity);
        Destroy(fog, 0.5f);

        CGameSound.PlayGameSound(audioClip, transform.position);

        Shoot(shoot_relative_position);
    }

    // Bullet shoot
    public void Shoot(Vector2 shoot_relative_position)
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.SendMessage("InitBullet", shoot_relative_position);
    }

    // Bullet prefab load
    public void LoadBulletPrefab()
    {
        bulletPrefab = (Object)Resources.Load("Prefabs/Bullets/Bullet");
    }
}
