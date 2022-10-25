using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    [SerializeField] private Boundary horizontalB;
    [SerializeField] private Boundary verticalB;
    public float speed;
    // Update is called once per frame

    private void Start()
    {
        transform.position = new Vector3(Random.Range(11.3f, horizontalB.max),
                                         Random.Range(verticalB.min, verticalB.max), transform.position.z);
    }
    void Update()
    {
        transform.Translate(new Vector2(-1 * speed * Time.deltaTime, 0));
        CheckBounds();
    }


    void CheckBounds()
    {
        if (transform.position.x < horizontalB.min)
        {
            Destroy(gameObject);
        }
    }
}
