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
    /// 
    /// </summary>
    public void CreateBall()
    {
        Instantiate(arrayBall[0], transform.position, Quaternion.identity);
    }
}
