using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField]
    Generator generator;

    //рандомная скорость
    int randSpeed;

    void Start()
    {
        randSpeed = Random.Range(1, 10);
        generator = FindObjectOfType<Generator>();
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, transform.up, Time.deltaTime*5);

        transform.Translate(new Vector2(0, 1) * (Time.deltaTime * randSpeed));
    }

    private void OnBecameInvisible()
    {
        generator.CreateBall();
        Destroy(gameObject);
    }
}
