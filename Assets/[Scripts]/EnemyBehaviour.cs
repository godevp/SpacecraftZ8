using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //private
    [SerializeField] private Boundary verticalBounds;
    [SerializeField] private Boundary horizontalBounds;
    [SerializeField] private Boundary horizontalSpawnBounds;
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private float _shootingRange;
    [SerializeField] private float _fireRate;
    [SerializeField] private Transform bulletSpawn;
    private bool keepMoving = true;

    private GameObject player;
    private Vector3 direction;
    private BulletParent bulletParent;
    private float _timer;
    private Animator animator;


    //public 
    public bool targetFound = false;

    private void Start()
    {

        player = FindObjectOfType<PlayerBehaviour>().gameObject;
        bulletParent = FindObjectOfType<BulletParent>();
        ResetEnemy();
        animator = GetComponent<Animator>();

        transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
    }
    void Update()
    {
        if(keepMoving)
        {
            IDEMovement();
            animator.SetBool("Moving", true);
        }
        else animator.SetBool("Moving", false);


        direction = transform.position - player.transform.position;
        if (direction.sqrMagnitude < _range) { targetFound = true; }

        if (targetFound)
        {
            LookAtPlayer();
            BeReadyToShoot();
        }
         

       
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
                _timer = 0;
        }
        CheckBounds();
      
    }


    public void IDEMovement()
    {
        float moveValue = -1;

       transform.Translate(0, moveValue * _speed * Time.deltaTime, 0);


    }

    public void CheckBounds()
    {
        Vector3 _pos = transform.position;
        _pos.x = Mathf.Clamp(_pos.x, horizontalBounds.min, horizontalBounds.max);
        _pos.y = Mathf.Clamp(_pos.y, verticalBounds.min, verticalBounds.max);
        transform.position = _pos;
    }
    public void LookAtPlayer()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public void BeReadyToShoot()
    {
        
        keepMoving = direction.sqrMagnitude > _shootingRange;
        
        //start shooting
        if(_timer == 0 && !keepMoving)
        {
            Shooting();
            _timer = _fireRate;
        }
    }
       
    void Shooting()
    {
        var bullet = bulletParent.GetBullet(bulletSpawn.position, BulletType.ENEMY);
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }


    public void ResetEnemy()
    {
        var RandomXPosition = Random.Range(horizontalSpawnBounds.min, horizontalSpawnBounds.max);
        var RandomYPosition = Random.Range(verticalBounds.min, verticalBounds.max); ;

        transform.position = new Vector3(RandomXPosition, RandomYPosition, 0.0f); 
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameObject) return;

        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("AVOIDDD!@!!!!");
        }
    }


    private void OnDestroy()
    {
        if(FindObjectOfType<EnemyParent>() != null)
        {
            var enemyParent = FindObjectOfType<EnemyParent>();
            enemyParent.DeleteEnemy(gameObject);
        }
    }
}
