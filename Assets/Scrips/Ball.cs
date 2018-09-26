using UnityEngine;

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
    /// рандомная скорость
    /// </summary>
    int randSpeed;

    //
    bool isDeath;

    [Header("Количество очков")]
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
        //устанавливаем новое значение очков (разные по цветам шары дают разные очки)
        generator.SetScore(score);

        //"смерть" шара
        Death();
    }

    private void OnBecameInvisible()
    {
        Death();
    }

    /// <summary>
    /// удаляем шар с проверкой он "уже мертвый или нет"
    /// для того чтобы метод не вызвался 2 раз из мнтода OnBecameInvisible
    /// </summary>
    public void Death()
    {
        if(isDeath)
        {
            return;
        }

        isDeath = true;

        //устанавливаем что текущих шаров столо на 1 меньше
        generator.SetCountBall();

        //генерим новый шар
        generator.CreateBall();

        //удаляем этот шар
        Destroy(gameObject);
    }
}
