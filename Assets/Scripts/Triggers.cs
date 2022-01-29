using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject character, gameOverPanel;    
    public AudioSource gameOverSound, charFallSound, charWinSound, charCheersSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.CompareTag("Fall"))
        {            
            StartGame.isStart = false;
            gameOverSound.Play();
            charFallSound.Play();
            Destroy(character, 0.5f);
            gameOverPanel.SetActive(true);            
        }

        if (collision.gameObject.CompareTag("Win"))
        {            
            StartGame.isStart = false;
            charWinSound.Play();
            charCheersSound.Play();
            Destroy(character, 0.1f);
            gameOverPanel.SetActive(true);
        }
    }
}
