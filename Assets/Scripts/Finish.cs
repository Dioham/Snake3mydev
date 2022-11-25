using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public SnakeMovement SnakeMovement;
    public GameObject SnakeWinPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SnakeMovement.enabled = false;
            SnakeMovement.ScoreReachFinish();
            SnakeWinPanel.SetActive(true);
            
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

}
