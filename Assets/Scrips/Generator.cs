using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField]
    [Header("Максимальное кол-во шаров")]
    int maxBall;

    [SerializeField]
    [Header("Шары для генерации")]
    GameObject[] arrayBall;

    [SerializeField]
    [Header("Точка для генерации")]
    GameObject point;

    /// <summary>
    /// счетчик шарав
    /// </summary>
    int count = 0;

    [SerializeField]
    Text text;
    int score;
    private void Start()
    {
        StartCoroutine(GenerateBall());
    }

    /// <summary>
    /// создает новый шар
    /// </summary>
    public void CreateBall()
    {
        if(count < maxBall)
        {
            Instantiate(arrayBall[Random.Range(0, 3)], point.transform.position, Quaternion.identity);
            count++;
            //SetScore();

        }
    }

    public void SetCountBall()
    {
        count--;
        ////
    }

    


    IEnumerator GenerateBall()
    {
        if(count < maxBall)
        {
            Instantiate(arrayBall[Random.Range(0, 3)], point.transform.position, Quaternion.identity);
            count++;
            //SetScore();
            //Debug.Log(count);

            yield return new WaitForSeconds(.5f);


            StartCoroutine(GenerateBall());
        }
    }

    public void SetScore(int addScore)
    {
        score = score + addScore;

        text.text = "Score: " + score.ToString();
    }
    //private void Update()
    //{
    //    text.text = "count: " + count.ToString();
    //}
}
