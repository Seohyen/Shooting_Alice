using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerMove Player { get; private set; }
    public PoolManager poolManager { get; private set; }
    [SerializeField]
    private Text textScore = null;
    [SerializeField]
    private Text textHighScore = null;
    [SerializeField]
    private Text textLife = null;
    [SerializeField]
    private GameObject enemy_BookPrefab = null;
    [SerializeField]
    private GameObject enemy_HongchaPrefab=null;
   
  
    [SerializeField]
    public int life = 3;

    public int score = 0;
    public int highScore = 0;
    public float difficult = 1;
    public GameObject Text;


    public Vector2 MinPosition { get; private set; }
    public Vector2 MaxPosition { get; private set; }
    
    void Start()
    {
        MinPosition = new Vector2(-1.9f, -4.337f);
        MaxPosition = new Vector2(1.9f, 4.337f);
        poolManager = FindObjectOfType<PoolManager>();
        Player = FindObjectOfType<PlayerMove>();
        StartCoroutine(SpawnEnemy_Book());
        StartCoroutine(SpawnEnemy_Hongcha());
        highScore = PlayerPrefs.GetInt("HIGHSCORE: ", 0);
        UpdateUI();
        StartCoroutine(Difficult());
    }
    public void AddScore()
    {
        score += 100;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HIGHSCORE: ",highScore);
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (score < 0)
        {
            score = 0;
        }
        textLife.text = string.Format("LIFE: {0}", life);
        textScore.text = string.Format("SCORE: {0}", score);
        textHighScore.text = string.Format("HIGHSCORE: {0}", highScore);


    }
    IEnumerator Difficult()
    {
        yield return new WaitForSeconds(20f);
        difficult = 2f;
        for(int i = 0;i < 4; i++)
        {
            Text.SetActive(true);
            yield return new WaitForSeconds(.3f);
            Text.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 3f;
        for (int i = 0; i < 4; i++)
        {
            Text.SetActive(true);
            yield return new WaitForSeconds(.3f);
            Text.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 4f;
        for (int i = 0; i < 4; i++)
        {
            Text.SetActive(true);
            yield return new WaitForSeconds(.3f);
            Text.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 5f;
        for (int i = 0; i < 4; i++)
        {
            Text.SetActive(true);
            yield return new WaitForSeconds(.3f);
            Text.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(20f);
        difficult = 6f;
        for (int i = 0; i < 4; i++)
        {
            Text.SetActive(true);
            yield return new WaitForSeconds(.3f);
            Text.SetActive(false);
            yield return new WaitForSeconds(.3f);
        }
    }
    private IEnumerator SpawnEnemy_Book()
    {
      
        while (true)
        {
                Instantiate(enemy_BookPrefab, new Vector2(-1.9f,-4.6f), Quaternion.identity);
                Instantiate(enemy_BookPrefab, new Vector2(-1f, -4.6f), Quaternion.identity);
                Instantiate(enemy_BookPrefab, new Vector2(0f, -4.6f), Quaternion.identity);
                Instantiate(enemy_BookPrefab, new Vector2(1f, -4.6f), Quaternion.identity);
                Instantiate(enemy_BookPrefab, new Vector2(1.9f, -4.6f), Quaternion.identity);

            yield return new WaitForSeconds(2f);
        }
        
    }


    private IEnumerator SpawnEnemy_Hongcha()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            float randomx;
            for (int i = 0; i < 3; i++)
            {
                randomx = Random.Range(-2.1f, 2.1f);
                Instantiate(enemy_HongchaPrefab, new Vector2(randomx, -4.6f), Quaternion.identity);
           

                yield return new WaitForSeconds(1f);
            }
            
            yield return new WaitForSeconds(5f);
        }
    }

   
    
}
