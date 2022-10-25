using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 
 Source file Name - ScoreManager.cs
 Name - Vitaliy Karabanov
 ID - 101312885
 Date last Modified - 24/10/2022 
 Program description: An object which has a singlton which doesn't destroyed on any level awake().

 */
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float _score = 0;
    public float _seconds = 0;
    public float _minutes = 0;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        _seconds += Time.deltaTime;
        if (_seconds > 59)
        {
            _seconds = 0;
            _minutes++;
        }
    }
}
