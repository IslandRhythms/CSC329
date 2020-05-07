using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using System;

public class EnemySpawn : MonoBehaviour
{
    

//Range is 125-140 and 155-169 for x
//Range is 76-69 for y
    public GameObject EnemyPs;
   public static int [] xexclude = Enumerable.Range(141,15).ToArray();
    public static int[] yexclude = Enumerable.Range(72,3).ToArray();
    int [] xpos = Enumerable.Range(125,45).Where(i => !xexclude.Contains(i)).ToArray();
    int[] ypos = Enumerable.Range(69,8).Where(i => !yexclude.Contains(i)).ToArray();
    volatile int count;
    //rate is 3.5f
    float rate = 3.5f;
    
    public AudioClip[] EnemySounds;
    public AudioSource audioSource;
    
    //need to make it so that they instantiate randomly
    
    void Start()
    {

       audioSource = gameObject.GetComponent<AudioSource>();
       StartCoroutine(EnemyCreate());
     
       
    }

    void Update()
    {
        count = EnemyCount.enemycount;
    }

IEnumerator EnemyCreate()
{
    //use modulo for spawn increases
    //duplicate New Spawn object for more enemies at a given time
    //rate is being accessed and lowered multiple times, volatile keyword is the solution
    while(true)
    {
       if(count % 25 == 0 && count < 1000 && count != 0)
       {
           rate = rate * .9f;
       }
        audioSource.clip = EnemySounds[Random.Range(0,EnemySounds.Length)];
        audioSource.Play();
        Instantiate(EnemyPs, new Vector3(xpos[Random.Range(0,xpos.Length)],ypos[Random.Range(0,ypos.Length)],0),Quaternion.identity);
        yield return new WaitForSeconds(rate);
        
    }
}

}
