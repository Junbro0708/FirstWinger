using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private GameObject explosionFactory;

    private Vector3 dir;

    private void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if(randValue < 3)
        {
            if (GameObject.Find("Player"))
            {
                GameObject target = GameObject.Find("Player");
                dir = target.transform.position - transform.position;
                dir.Normalize();
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = collision.transform.position;

        sm.currentScore++;
        sm.currentTextUI.text = "현재 점수 : " + sm.currentScore;

        if(sm.currentScore > sm.bestScore)
        {
            sm.bestScore = sm.currentScore;
            sm.bestScoreUI.text = "최고 점수 : " + sm.bestScore;
            PlayerPrefs.SetInt("Best Score", sm.bestScore);
        }

        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
