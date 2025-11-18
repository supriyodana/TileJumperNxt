using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    public void onClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
