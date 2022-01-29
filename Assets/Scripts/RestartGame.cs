using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    
    public void RestartButton()
    {
        
        SceneManager.LoadScene("Main");
    }
}
