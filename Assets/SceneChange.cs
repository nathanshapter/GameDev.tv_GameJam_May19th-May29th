using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] private string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            print(SceneManager.GetActiveScene().ToString());

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
