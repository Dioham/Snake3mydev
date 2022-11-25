using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpDie : MonoBehaviour
{
    public SnakeMovement SnakeMovement;
    public GameObject SnakeDiePanel;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SnakeMovement.enabled = false;
            Debug.Log("Game Over");
          SnakeDiePanel.SetActive(true);

        }
    
    
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
