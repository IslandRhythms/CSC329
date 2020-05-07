using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
   
    public TextMeshProUGUI score;
   void Start()
   {
       score = GameObject.Find("FinalScore").GetComponent<TextMeshProUGUI>();
       score.text = EnemyCount.enemycount.ToString();
   }
}
