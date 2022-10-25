using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
