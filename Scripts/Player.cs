using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    static public int health = 4;

     public HealthBar healthbar;
     
     public UltimateLoad shredbar;

     public int maxload = 50;


    void Start(){
     healthbar.SetMaxHealth(health);
     shredbar.SetStart(maxload);
    }

   public void TakeDamage(int damage){
       health -= damage;
       Debug.Log(health);
        healthbar.SetHealth(health);
   if(health <= 0){
       Die();
   }
   }

   void Die(){
       Destroy(gameObject);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       health = 4;
       BarCount.barcount = 0;
       Hurtz.count = 0;
   }
    void OnTriggerEnter2D(Collider2D check){
        Enemy enemy = check.GetComponent<Enemy>();

        if(enemy != null){
            //Player is being damaged really fast, need to make enemy sprite destroy on contact.
            TakeDamage(2);
        }
    }

}
