using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject Settings;
   public void PlayGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Retry()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       EnemyCount.enemycount = 0;
   }

   public void QuitGame()
   {
       Debug.Log("Quit");
       Application.Quit();
   }

   public void Options()
   {
       MainMenu.SetActive(false);
       Settings.SetActive(true);

   }

   public void Main(string name)
   {
       SceneManager.LoadScene(name);
       EnemyCount.enemycount = 0;
   }

   public void ExitOptions()
   {
       MainMenu.SetActive(true);
       Settings.SetActive(false);
   }
}
