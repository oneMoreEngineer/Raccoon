using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    private int foods = 0;
    private int itemsNum;

    [SerializeField] private TMP_Text foodTxt;
    [SerializeField] private AudioSource collectSound;

    private void Start()
    {
        itemsNum = GameObject.FindGameObjectsWithTag("food").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            foods++;
            foodTxt.text = "Yummies: " + foods + " / " + itemsNum;
        }
    }
}
