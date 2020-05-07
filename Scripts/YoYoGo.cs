using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YoYoGo : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    public Rigidbody2D rigidbody;

     public AudioSource Sound;

    TextMeshProUGUI Label_score;

    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player");
        Sound.Play();
    }

    void Awake()
    {
        
        Label_score = GameObject.Find("counter").GetComponent<TextMeshProUGUI>();
        Label_score.text = EnemyCount.enemycount.ToString();
    }

   void Update(){
        Destroy(gameObject,2);
    }
   
   void OnTriggerEnter2D(Collider2D hitInfo)
   {
       
       Enemy enemy = hitInfo.GetComponent<Enemy>();
       if(enemy != null){
           enemy.TakeDamage(damage); 
           EnemyCount.enemycount++;
           Label_score.text = EnemyCount.enemycount.ToString();
           if(BarCount.barcount < 50){
            BarCount.barcount++;
           player.GetComponent<UltimateLoad>().SetProgress(BarCount.barcount);
           }
           if(Player.health < 4) Hurtz.count++;

       }
      Sound.Stop();
       Destroy(gameObject);
       
       
    
   }
   

}
