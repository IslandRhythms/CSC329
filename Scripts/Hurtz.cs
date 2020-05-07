using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtz : MonoBehaviour
{
    SpriteRenderer hurtz;
    public HealthBar healthBar;
    public HurtzBar hurtzBar;

    //for hurtzbar
    public static volatile int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        hurtz = GameObject.FindGameObjectWithTag("Hurtz").GetComponent<SpriteRenderer>();
        hurtzBar.SetStart(25);
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.health < 4 && count < 25){
            hurtz.enabled = false;
            hurtzBar.SetProgress(count);
        }
        else if(count == 25){
            Player.health = 4;
            healthBar.SetHealth(Player.health);
            hurtzBar.SetProgress(0);
            count = 0;
            hurtz.enabled = true;
        }
    }
}
