
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //adding bool variable to check if game has enden
    bool gameHasEnded = false;

    //variable for delay between scenes
    public float gameRestartDelay = 0.5f;
    //varaible for completing level text
    public GameObject CompleteLevelUi;
    //variable for resetting score at the end level
    public GameObject CompleteLevepScoreReset;

    //Method for Ending Game
    public void EndGame()
    {
        //checking is has ended or not
        //bool value is set to false so the next statement will be always true
        if (gameHasEnded == false)
        {
            //changing bool value
            gameHasEnded = true;
            //Calling RestartGame method with Invoke to give it delay
            Invoke("RestartGame", gameRestartDelay);
           
        }
    }

    void RestartGame()
    {
        //changing the static int 'theScore' to 0 from PointSysteem script
        PointSysteem.theScore = 0;
        //restaring scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        //disable the score at the end of the level
        CompleteLevepScoreReset.SetActive(false);
        //enable level complete ui at the end of the level
        CompleteLevelUi.SetActive(true);
    }

    
}
