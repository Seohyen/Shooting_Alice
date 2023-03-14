using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongCha_Move : EnemyMove
{   [SerializeField]
    private float RPM;
    [SerializeField]
    private GameObject bullet;
    protected override void Start()

    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(RPM);
        }
    }
}
