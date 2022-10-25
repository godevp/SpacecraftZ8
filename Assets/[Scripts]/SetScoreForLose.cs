using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetScoreForLose : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
       scoreText.text =  "Score: " + ScoreManager.instance._score;
       timeText.text = "Time: " + ScoreManager.instance._minutes + ":" + ScoreManager.instance._seconds.ConvertTo<int>();
    }
}
