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

    /// <summary>
    /// счетчик шарав
    /// </summary>
    int count=0;

    /// <summary>
    /// создает новый шар
    /// </summary>
    public void CreateBall()
    {
        Instantiate(arrayBall[0], transform.position, Quaternion.identity);
    }

    /// <summary>
    /// задает положение шара и контролирует количество шаров
    /// </summary>
    public void ManagerBalls()
    {

    }
}
