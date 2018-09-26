﻿using UnityEngine;

/// <summary>
/// этот скрипт висит на кождом шаре
/// </summary>
public class Ball : MonoBehaviour
{
    /// <summary>
    /// ссылка на генератор шаров
    /// </summary>
    Generator generator;

    /// <summary>
    ///    рандомная скорость
    /// </summary>
    int randSpeed;
    bool isDeath;
    [SerializeField]
    int score;
    void Start()
    {
        //задаем скорость шара
        randSpeed = Random.Range(1, 10);

        //получаем ссылку на генератор шаров чтобы можно было вызвать
        //метеод генерации нового шара при уничтожении этого шара при срабатывании
        //метода OnBecameInvisible()
        generator = FindObjectOfType<Generator>();
    }

    void Update()
    {
        //перемешения шара вверх
        transform.Translate(new Vector2(0, 1) * (Time.deltaTime * randSpeed));
    }

    private void OnMouseDown()
    {
        generator.SetScore(score);
        Death();
    }

    private void OnBecameInvisible()
    {
        Death();
    }

    public void Death()
    {
        if(isDeath)
        {
            return;
        }
        isDeath = true;
        
        generator.SetCountBall();

        //генерим новый шар
        generator.CreateBall();

        //удаляем этот шар
        Destroy(gameObject);
    }
}
