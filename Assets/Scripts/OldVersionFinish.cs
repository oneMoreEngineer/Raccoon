using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OldVersionFinish : MonoBehaviour
{
    private bool CompletedLevel = false;
    [SerializeField] private TMP_Text foodTxt;
    [SerializeField] private AudioSource winSound;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !CompletedLevel && foodTxt.text == "Yummies: 3")
        {
            print("old finish");
            winSound.Play();
            CompletedLevel = true;
            Invoke("CompleteLevel", 1.5f);
            //CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
