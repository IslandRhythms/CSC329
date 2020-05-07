using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeoulHurtz : MonoBehaviour
{
    public Image icon;

    // Update is called once per frame
    void Update()
    {
        if(Player.health < 4)
        {
            icon.enabled = false;
        }
        else{
            icon.enabled = true;
        }
    }
}
