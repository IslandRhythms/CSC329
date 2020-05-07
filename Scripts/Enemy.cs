using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health = 50;
    public float speed = 9.0f;
    private Transform target;
    

    void Start(){
       target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
       
    }

    void Update(){
        if(target != null)
        transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
      
    }
   public void TakeDamage(int damage){
       health -= damage;
   if(health <= 0){
       Die();
   }
   }

   void Die(){
       Destroy(gameObject);
   }

  void OnTriggerEnter2D(Collider2D final){
      Player player = final.GetComponent<Player>();
      if(player != null){
          Die();
      }
   }


}
