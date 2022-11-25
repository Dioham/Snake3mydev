using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Obstcale : MonoBehaviour
{
    public Text amountText;
    public int obstacleAmountMax = 6;
    public int obstacleAmountMin = 1;
    private int amount;
    public Material easyColor, mediumColor, hardColor;
    private Renderer Renderer;
    private SnakeMovement snakeMovement;
    private float nextTime;
    public float damageTime=0.1f;
    private Material initialMaterial;
    public Material finishMaterial;
    public SnakeMovement snakeMovement1;
    public int scoreValue;
    public Transform player;


    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        SetAmount();
        player = GameObject.FindWithTag("Player").transform;
        GameObject Player1Object = GameObject.FindWithTag("Player");
        if (Player1Object != null)
        {
            snakeMovement1 = Player1Object.GetComponent<SnakeMovement>();
        }

    }

  
    void Update()
    {
        SetColor();

        if (snakeMovement != null && nextTime < Time.time)
        {
            PlayerDamage();    
        }
    }


    public void SetAmount()
    {
        gameObject.SetActive(true);
        amount = Random.Range(obstacleAmountMin, obstacleAmountMax);
        SetAmountText();


    }
    public void SetAmountText()
    {
       amountText.text = amount.ToString();
    }

    public void SetColor()
    {
        int playerLives = FindObjectOfType<SnakeMovement>().transform.childCount;
        Material newColor;

        if(amount > playerLives)
        {
            newColor = hardColor;

        }
        else if(amount < playerLives)
        {
            newColor = easyColor;
            

        }
        
        else
        {
            newColor = mediumColor;
        }
        Renderer.material = newColor;
        initialMaterial = newColor;
    }
    void PlayerDamage()
    {
        nextTime = Time.time + damageTime;
        snakeMovement.TakeDamage();
        amount--;
        snakeMovement1.Removescore(scoreValue);
        SetAmountText();
        if(amount == 0)
        {
            gameObject.SetActive(false);
            snakeMovement = null;
        }
        //else
        //{
        //    StopAllCoroutines();
        //    StartCoroutine(DamageColor());
        //}
    }
    //IEnumerator DamageColor()
    //{
    //    float timer = 0;
    //    float t = 0;
    //    Renderer.material = initialMaterial;


    //    while (timer < damageTime)
    //    {
    //        Renderer.material.Lerp(initialMaterial, finishMaterial, t);
    //        timer += Time.deltaTime;
    //        t += Time.deltaTime / damageTime;
    //        yield return null;
    //    }
    //    Renderer.material = initialMaterial;
    //}




    private void OnCollisionEnter(Collision other)
    {
      SnakeMovement otherSnakeMovement = other.gameObject.GetComponent<SnakeMovement>();
         if(otherSnakeMovement != null)
        {
            snakeMovement = otherSnakeMovement;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        SnakeMovement otherSnakeMovement = other.gameObject.GetComponent<SnakeMovement>();
        if (otherSnakeMovement != null)
        {
            snakeMovement = null;
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
