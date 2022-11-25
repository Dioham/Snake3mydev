using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SnakeMovement : MonoBehaviour
{
  
    
        public float ForwardSpeed = 5;
        public float Sensitivity = 10;

        public Text livesText;

        public Text Score;
        public Text moneyText;
        public int score = 0;
        public int earnedscore;
        private int count = 1;
        public Text sceneName;

        private Camera mainCamera;
        private Rigidbody componentRigidbody;
        private Vector3 touchLastPos;
        private float sidewaysSpeed;
        public SnakeMovement snakeMovement;
        public GameObject SnakeDiePanel;

    private void Start()
        {
        sceneName.text = SceneManager.GetActiveScene().name.ToString();
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
        count = 1;
        UpdateScore();

        score = PlayerPrefs.GetInt("score");
        earnedscore = PlayerPrefs.GetInt("Score ");
        score += earnedscore;
        PlayerPrefs.SetInt("score", score);
        moneyText.text = "Total score " + score.ToString();
        earnedscore = 0;
        PlayerPrefs.SetInt("Score ", earnedscore);

    }


    public void ScoreReachFinish()
    {
        PlayerPrefs.SetInt("Score ", count);
    }
    void RemoveUpdateScore()
    {
        Score.text = "Score " + count--.ToString();
    }
    void UpdateScore()
    {
        Score.text = "Score " + count++.ToString();
    }
    public void Addscore(int newScoreValue)
    {
        count += newScoreValue;
        UpdateScore();
    }
    public void Removescore(int newScoreValue)
    {
        count -= newScoreValue;
        RemoveUpdateScore();
    }

    private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                sidewaysSpeed = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 delta = (Vector3)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
                sidewaysSpeed += delta.x * Sensitivity;
                touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
            }
                      
        }

        private void FixedUpdate()
        {
            if (Mathf.Abs(sidewaysSpeed) > 4) sidewaysSpeed = 4 * Mathf.Sign(sidewaysSpeed);
            componentRigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0, ForwardSpeed);

            sidewaysSpeed = 0;
        }
    public void SetText(int count)
    {
     livesText.text = count.ToString();
       
        if (count == 0)
        {
            snakeMovement.enabled = false;
            Debug.Log("Game Over");
            gameObject.SetActive(false);
            snakeMovement = null; ;
            SnakeDiePanel.SetActive(true);

        }
        
    }

    public void TakeDamage()
    {
        int children = transform.childCount;
        if (children <= 1)
        {

        }

        else
        {
            Destroy(transform.GetChild(children - 1).gameObject);
        }
        SetText(children - 1);
    }

    //public int LevelIndex
    //{
    //    get => PlayerPrefs.GetInt(LevelIndexKey, 0);
    //    private set
    //    {
    //        PlayerPrefs.SetInt(LevelIndexKey, value);
    //        PlayerPrefs.Save();

    //    }
    //}

    //public const string LevelIndexKey = "LevelIndex";

    

}
