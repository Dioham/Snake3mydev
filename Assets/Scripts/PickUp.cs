using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PickUp : MonoBehaviour
{
    private Transform player;
    public Text amountText;
    public GameObject Addtail;
    private int amount;
    public int scoreValue;
    public SnakeMovement snakeMovement1;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        GameObject Player1Object = GameObject.FindWithTag("Player");
        if (Player1Object != null)
        {
            snakeMovement1 = Player1Object.GetComponent<SnakeMovement>();
        }
       


    }

    private void OnEnable()
    {
        amount = Random.Range(1, 7);
        amountText.text = amount.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            for (int i = 0; i < amount; i++)
            {
                int index = other.transform.childCount;
                GameObject newBody = Instantiate(Addtail, other.transform);
                newBody.transform.localPosition = new Vector3(0,0, -index);
                snakeMovement1.Addscore(scoreValue);

            }

            SnakeMovement snakeMovement = other.GetComponent<SnakeMovement>();
            if(snakeMovement != null)
            {
                snakeMovement.SetText(snakeMovement.transform.childCount);
            }

            gameObject.SetActive(false);
        }

    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
