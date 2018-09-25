using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int count=0;

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
            Instantiate(arrayBall[0], point.transform.position, Quaternion.identity);
            count++;
        }
    }

    public void SetCountBall()
    {
        count--;
    }

    /// <summary>
    /// задает положение шара и контролирует количество шаров
    /// </summary>
    public void ManagerBalls()
    {

    }
    
    IEnumerator GenerateBall()
    {
        if(count < maxBall)
        {
            Instantiate(arrayBall[0], point.transform.position, Quaternion.identity);
            count++;

            //Debug.Log(count);

            yield return new WaitForSeconds(.5f);


            StartCoroutine(GenerateBall());
        }
    }
}
