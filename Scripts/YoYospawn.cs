using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYospawn : MonoBehaviour
{
    public GameObject YoYo;
    public Transform yoyofire;
   
    void Update(){
         bool shoot = Input.GetKeyDown(KeyCode.Mouse1);
         bool exist = GameObject.FindGameObjectWithTag("YoYo");

        if(shoot && !exist && !PauseMenu.GameIsPaused){
            Instantiate(YoYo,yoyofire.position,yoyofire.rotation);
        }
        
        
    }
}
