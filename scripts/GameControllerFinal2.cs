using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerFinal2 : MonoBehaviour
{
	public int killCount;
	public Text scoreText;
	public GameObject FinalWall;
    public int lives;
    public Image H1;
    public Image H2;
    public Image H3;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Dream Ghosts: " + killCount + "/6";
        //Debug.Log(killCount);
        if(killCount == 6)
        {
        	Destroy(FinalWall);
        }
        LoseHealth();
    }

    void LoseHealth()
    {
        if (lives == 2)
        {
            H1.enabled = false;
        }
        if (lives == 1)
        {
            H1.enabled = false;
            H2.enabled = false;
        }
        if (lives == 0)
        {
            H1.enabled = false;
            H2.enabled = false;
            H3.enabled = false;
            SceneManager.LoadScene("DeathScreen2");
        }
    }
}
