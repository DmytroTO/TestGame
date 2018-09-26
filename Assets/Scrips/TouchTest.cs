using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTest : MonoBehaviour
{
    [SerializeField]
    Text text;

    int i=0; 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0|| Input.GetKeyDown(KeyCode.I))
        {
            i++;
            text.text = i.ToString();
        }
    }
}
