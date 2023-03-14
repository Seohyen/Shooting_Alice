using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;
    [SerializeField]
    private float bulletDelay = 0.2f;
    [SerializeField]
    private float speed = 5f;

    public PoolManager poolManager { get; private set; }
    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    private SpriteRenderer spriteRenderer = null;
    private bool isHit = false;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        poolManager = FindObjectOfType<PoolManager>();
        StartCoroutine(Fire());
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.x = Mathf.Clamp(targetPosition.x, gameManager.MinPosition.x, gameManager.MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, 4.337f, gameManager.MaxPosition.y);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
    private IEnumerator Fire()
    {
        while (true)
        {
            Instanbullet();
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isHit == false)
        {
            isHit = true;
            StartCoroutine(Damaged());
            
        }
        gameManager.UpdateUI();
    }
    IEnumerator Damaged()
    {
        gameManager.life--;
        gameManager.UpdateUI();
        if (gameManager.life <= 0)
        {
            SceneManager.LoadScene("GameOver");
            PlayerPrefs.SetInt("SCORE: ", gameManager.score);
            PlayerPrefs.SetInt("HIGHSCORE: ", gameManager.highScore);

        }
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("a");
        }
      
     
       
        isHit = false;
    }
    private void Instanbullet()
    {
        GameObject bullet = null;
        if (poolManager.transform.childCount > 0)
        {
            bullet = poolManager.transform.GetChild(0).gameObject;
            bullet.transform.SetParent(null);
            bullet.SetActive(true);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, bulletPosition);

        }

        bullet.transform.SetParent(null);
        bullet.transform.position = bulletPosition.position;
    }

}