using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    


 
void OnTriggerEnter2D(Collider2D go){
Player player = go.GetComponent<Player>();
if(player != null){
    Application.LoadLevel(Application.loadedLevel);
}
}
}