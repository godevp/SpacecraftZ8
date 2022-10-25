using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    ENEMY,
    PLAYER
}
/*
 
 Source file Name - BulletCreation.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 24/10/2022 
 Program description: basically it has function where we instantiate it and set it properties for both enemy and player.

 */
public class BulletCreation : MonoBehaviour
{

    // Bullet Prefab
   [SerializeField] private GameObject bulletPrefab;

    // Sprite Textures
   [SerializeField] private Sprite playerBulletSprite;
   [SerializeField] private Sprite playerBombSprite;
   [SerializeField] private Sprite enemyBulletSprite;

    [SerializeField] private float playerBulletSpeed;
    [SerializeField] private float enemyBulletSpeed;



    public GameObject CreateBullet(BulletType type)
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.GetComponent<BulletBehaviour>().bulletType = type;

        switch (type)
        {
            case BulletType.PLAYER:
                bullet.GetComponent<SpriteRenderer>().sprite = playerBulletSprite;
                bullet.name = "PlayerBullet";
                bullet.GetComponent<BulletBehaviour>()._speed = playerBulletSpeed;
                break;
            case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = enemyBulletSprite;
                bullet.GetComponent<BulletBehaviour>()._speed = enemyBulletSpeed;
                bullet.name = "EnemyBullet";
                break;
        }
        bullet.transform.SetParent(FindObjectOfType<BulletParent>().transform);
        bullet.SetActive(false);
        return bullet;
    }
}
