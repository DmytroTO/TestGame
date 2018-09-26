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
    /// счетчик шарав для контроля макс. их числа
    /// </summary>
    int count = 0;

    //сюда выводит очки
    [SerializeField]
    Text text;

    //очки
    int score;

    //хранит левую границу экрана
    [SerializeField]
    GameObject leftPoint;

    //хранит правую границу экрана
    [SerializeField]
    GameObject rigthPoint;

    private void Start()
    {
        //старт генерации шаров
        StartCoroutine(GenerateBall());

        //узнаем правую и левую границе камеры что бы 
        //задействовать ширину экрана для генерации 
        //шаров с учетом разной ширины экрана
        GetTransformCamera();
    }

    /// <summary>
    /// создает новый шар . метод вызывается скриптом Ball (тот что на шаре) при дестрое шара
    /// кгода шар выходит за раки камеры и при клике на шар
    /// </summary>
    public void CreateBall()
    {
        if(count < maxBall)
        {
            Instantiate(arrayBall[Random.Range(0, 3)/*берем какойто объект из массива*/],
                new Vector2(Random.Range(
                    leftPoint.transform.position.x/*устанавливаем рандом по ширине при появлении с учетом ширины экрана*/, 
                    rigthPoint.transform.position.x)/*устанавливаем рандом по ширине при появлении с учетом ширины экрана*/,
                point.transform.position.y)/*точка на сцене устанавливающая появление шара по у*/,
                Quaternion.identity/*никакого поворота*/);

            //говорим что кол-во текущих  шаров выросло на 1
            count++;         
        }
    }

    //дикремент кол -шаров при их смерти (дестрое) из скрипта Ball (тот что на каждом шаре висит)
    public void SetCountBall()
    {
        count--;
    }

    /// <summary>
    /// корутина генератор шаров с проверкой на количество
    /// шаров вызывается в старте и вызывает сама себя
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// устанавливает очки в юзер интерфейсе
    /// </summary>
    /// <param name="addScore"></param>
    public void SetScore(int addScore)
    {
        score = score + addScore;

        text.text = "Score: " + score.ToString();
    }
   
    /// <summary>
    /// Метод - определятор крайних положений экрана(камеры)
    /// нужно для того чтобы генерить шары с учетом ширины экрана
    /// </summary>
    public void GetTransformCamera()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//bpttom  - left
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));//top   -  rigth  


        leftPoint.transform.position = min;
        rigthPoint.transform.position = max;

        //Debug.Log((min.x).ToString() + "___" + (max.x).ToString());
    }
}
