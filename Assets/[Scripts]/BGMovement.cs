using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
 Source file Name - BGMovement.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 23/10/2022 
 Program description: Move the background in certain direction and reset it when it gets to the bounds.

 */
public class BGMovement : MonoBehaviour
{
    public float horizontalSpeed;
    public Boundary bounds;
    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position -= new Vector3(horizontalSpeed * Time.deltaTime, 0.0f);
        CheckBounds();
    }

    public void CheckBounds()
    {
        if (transform.position.x < bounds.min)
        {
            ResetStars();
        }
    }

    public void ResetStars()
    {
        transform.position = new Vector2(bounds.max, 0.0f);
    }
}
