using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Melee : MonoBehaviour
{
    public Animator animator;

    public AudioSource Sound;
    //make this an array and then use random function to pick a chord
    public AudioClip[] track;

    //use this track when in pausemenu
    public AudioClip pausetrack;

    public AudioClip miss;

    public Transform Contact;
    public float range = 1.7f;
    public LayerMask EnemyLayers;

    int playtrack = 0;
    TextMeshProUGUI Label_score;

    public UltimateLoad shredbar;
   
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !PauseMenu.GameIsPaused)
        {
            //move sound aspect to for loop in attack method
            Attack();
        } 
        //change track here to powerchords in key
        else if(Input.GetKeyDown(KeyCode.Mouse0) && PauseMenu.GameIsPaused)
        {
            Sound.clip = pausetrack;
            Sound.Play();
        }
        
    }

     void Awake()
    {
        
        Label_score = GameObject.Find("counter").GetComponent<TextMeshProUGUI>();
        Label_score.text = EnemyCount.enemycount.ToString();
    }

    void Attack()
    {
        playtrack = EnemyCount.enemycount;
        animator.SetTrigger("Attack");

       Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(Contact.position,range,EnemyLayers);
        
       foreach(Collider2D enemy in hitEnemies)
       {
           enemy.GetComponent<Enemy>().TakeDamage(50);
           EnemyCount.enemycount++;
           Label_score.text = EnemyCount.enemycount.ToString();
           
           if(BarCount.barcount < 50){
            BarCount.barcount++;
           shredbar.SetProgress(BarCount.barcount);
           }
           if(Player.health < 4) Hurtz.count++;
           

       }

       //Put good sounds here
        if(playtrack == EnemyCount.enemycount)
        {
            Sound.clip = miss;
            Sound.Play();
        }
        else
        {
            Sound.clip = track[Random.Range(0,track.Length)];
            Sound.Play();
        }
        

    }

    void OnDrawGizmosSelected()
    {
        if(Contact == null) return;
        Gizmos.DrawWireSphere(Contact.position,range);
    }
    
}
