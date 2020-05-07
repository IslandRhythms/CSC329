using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimateShred : MonoBehaviour
{

    public AudioSource Sound;

    public AudioClip track;

    public Animator animator;

    public UltimateLoad load;

     public Transform Contact;
    public float urange = 0.5f;
    public LayerMask EnemyLayers;
    TextMeshProUGUI Label_score;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U) && BarCount.barcount == 50)
        {
            Shred();
        }

    }

    void Awake()
    {
        
        Label_score = GameObject.Find("counter").GetComponent<TextMeshProUGUI>();
        Label_score.text = EnemyCount.enemycount.ToString();
        Debug.Log(EnemyCount.enemycount);
    }

    void Shred()
    {
        animator.SetTrigger("Shred");
        Sound.clip = track;
            Sound.Play();
            load.SetProgress(0);
            BarCount.barcount = 0;

         Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(Contact.position,urange,EnemyLayers);

         foreach(Collider2D enemy in hitEnemies)
       {
           if(enemy == null) return;
           enemy.GetComponent<Enemy>().TakeDamage(50);
           EnemyCount.enemycount++;
           Label_score.text = EnemyCount.enemycount.ToString();
           

       }

    }

    void OnDrawGizmosSelected()
    {
        if(Contact == null) return;
        Gizmos.DrawWireSphere(Contact.position,urange);
    }
}
