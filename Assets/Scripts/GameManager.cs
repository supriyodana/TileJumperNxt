using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{


    public void onClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //for playbtn in strtScene
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);

    }

    public void onClickExit()
    {
        Application.Quit();
    }
}



