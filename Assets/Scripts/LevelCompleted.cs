using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
  
    //Load next level methodes
    public void LoadNextLevel()
    {
        //setting the 'theScore' value at 0 start new level
        PointSysteem.theScore = 0;
        //loading next scene with unity build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
