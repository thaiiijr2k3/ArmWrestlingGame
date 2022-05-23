using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    GameObject _table;
    Touch _touch;
    Vector3 touchPosition;

    void Start()
    {
        _table = GameObject.Find("Table");
        Debug.Log(_table.transform.position);
        Debug.Log(_table.GetComponent<Renderer>().bounds.min);
        Debug.Log(_table.GetComponent<Renderer>().bounds.center);

    }

    
    void Update()
    {
        //_touch = Input.GetTouch(0);        
        //Debug.Log(Camera.main.ScreenToWorldPoint(_touch.position));
        
    }
}
