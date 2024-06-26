using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextDoor : MonoBehaviour
{
    public float delaySecond = 2;
    public string nameScene = "BedroomScene";


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);

            ModeSelect();
        }   
    }

    public void ModeSelect()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);

        SceneManager.LoadScene(nameScene);
    }
}
