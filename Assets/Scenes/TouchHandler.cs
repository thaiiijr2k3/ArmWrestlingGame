using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
   
    Touch _touch;

    void Start()
    {

    }

    void inside()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag.Equals("Right"))
                    {
                        Debug.Log("Right");
                    }
                    if (hit.transform.tag.Equals("Left"))
                    {
                        Debug.Log("Left");
                    }
                }
            }

        }

    }


    void Update()
    {
        //_touch = Input.GetTouch(0);        
        //Debug.Log(Camera.main.ScreenToWorldPoint(_touch.position));
        
    }
}
