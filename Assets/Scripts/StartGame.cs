using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject logoText;
    public AudioSource music;
    static public bool isStart;
    private float hideSpeed = 2.5f;

    private void Update()
    {
        if (isStart && logoText != null)
        {
            logoText.transform.Translate(Vector2.up * hideSpeed * Time.deltaTime);            
        }

        if (!isStart)
        {
            music.Stop();            
        }
    }
    public void startGame()
    {
        if (isStart)
            return;

        isStart = true;
        music.Play();

        logoText.GetComponent<Animator>().enabled = false;
        Destroy(logoText, 1.5f);

        GetComponent<Animation>().Play("HideStartButton");

    }       
}
