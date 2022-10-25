using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Boundary verticalBounds;
    [SerializeField] private Boundary horizontalBounds;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] public float health;
    private float maxHealth;
    [SerializeField] private GameObject[] healthObjects;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text TimeText;
    private Animator animator;
    private float _timer;

    private BulletParent bulletParent;

    private void Start()
    {
        bulletParent = FindObjectOfType<BulletParent>();
        animator = GetComponent<Animator>();
        maxHealth = health;
    }
    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.F) && _timer == 0)
        {
            FireBullets();
        }
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
                _timer = 0;
        }
        CheckHealth();
        ShowProperScore();
    }

    public void Movement()
    {
        var moveX = _joystick.Horizontal * Time.deltaTime * _speed;
        var moveY = _joystick.Vertical * Time.deltaTime * _speed;

        if (moveX != 0 || moveY != 0)
        {
            animator.SetBool("Moving", true);
        }
        else animator.SetBool("Moving", false);

        transform.Translate(-moveY, moveX, 0);
        CheckBounds();
    }
    void CheckHealth()
    {
        var hpPercantage = (health * 100) / maxHealth;
       if(hpPercantage < 75)
        {
            healthObjects[3].SetActive(false);
        }
       if(hpPercantage < 50)
        {
            healthObjects[2].SetActive(false);
        }
        if (hpPercantage < 25)
        {
            healthObjects[1].SetActive(false);
        }
        if (hpPercantage <= 0)
        {
            healthObjects[0].SetActive(false);
        }

        if (health <= 0)
        {
            health = 0;
            GameOver();
        }
    }

    public void CheckBounds()
    {
        Vector3 _pos = transform.position;
        _pos.x = Mathf.Clamp(_pos.x, horizontalBounds.min, horizontalBounds.max);
        _pos.y = Mathf.Clamp(_pos.y, verticalBounds.min, verticalBounds.max);
        transform.position = _pos;
    }


    public void FireBullets()
    {
        var bullet = bulletParent.GetBullet(bulletSpawn.position, BulletType.PLAYER);
        _timer = fireRate;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == gameObject) return;

        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            health -= 5.0f;
        }
        if(collision.gameObject.tag == "coin")
        {
            ScoreManager.instance._score += 100;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "obstacle")
        {
            health -= 30.0f;
            Destroy(collision.gameObject);
        }
    }


    void ShowProperScore()
    {
        ScoreText.text = "Score: " + ScoreManager.instance._score;
        TimeText.text = "Time: " + ScoreManager.instance._minutes + ":" + ScoreManager.instance._seconds.ConvertTo<int>();
    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}
