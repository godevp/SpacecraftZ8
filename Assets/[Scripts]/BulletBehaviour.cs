using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
/*
 
 Source file Name - BulletBehaviour.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 24/10/2022 
 Program description: Bullets behaviour.

 */
public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private Boundary verticalBounds;
    [SerializeField] private Boundary horizontalBounds;
    public float _speed;
    private GameObject player;

    private BulletParent bulletParent;
    public BulletType bulletType;
    public AudioSource audioSource;
 
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>().gameObject;
        bulletParent = FindObjectOfType<BulletParent>();
        audioSource =  GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        Movement();
        CheckBounds();

    }

    public void BulletDirectionToPlayer()// use this when we pull the bullet
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - player.transform.position);
    }
    void Movement()
    {
        transform.Translate(0, -1 * _speed * Time.deltaTime, 0);
    }

    void CheckBounds()
    {
        if ((transform.position.x > horizontalBounds.max) ||
            (transform.position.x < horizontalBounds.min) ||
            (transform.position.y > verticalBounds.max) ||
            (transform.position.y < verticalBounds.min))
        {
            bulletParent.ReturnBullet(this.gameObject, bulletType);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == this.gameObject) return;
        if(bulletType == BulletType.PLAYER && collision.gameObject.tag == "Enemy")
        {
           Destroy(collision.gameObject);
           Destroy(gameObject);
           ScoreManager.instance._score += 5;
        }
        if (bulletType == BulletType.PLAYER && collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance._score += 25;
            //add 1 bullet of aoe bomb to player here
        }
    }


}
