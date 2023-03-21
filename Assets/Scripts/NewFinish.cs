using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class NewFinish : MonoBehaviour
{
    private bool CompletedLevel = false;
    [SerializeField] private TMP_Text foodTxt;
    // Start is called before the first frame update
    [SerializeField] private AudioSource winSound;

    private void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && GameObject.FindGameObjectsWithTag("food").Length == 0)
        {
            winSound.Play();
            //CompletedLevel = true;
            Invoke("CompleteLevel", 1.8f);
            //CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("StartScreen");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
