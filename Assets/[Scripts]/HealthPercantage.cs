using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
 
 Source file Name - HealthPercantage.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 24/10/2022 
 Program description: set Proper health for UI.

 */
public class HealthPercantage : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] TMP_Text text;
   

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Health: " + player.health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + player.health;
    }
}
