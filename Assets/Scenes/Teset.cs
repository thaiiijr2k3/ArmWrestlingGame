using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teset : MonoBehaviour
{
    Touch _touch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void inside()
    {
        //for(int i = 0; i < Input.touchCount;i++)
        //{

        //    Ray ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.transform.tag.Equals("Right"))
        //        {
        //            Debug.Log("Right");
        //        }
        //        if (hit.transform.tag.Equals("Left"))
        //        {
        //            Debug.Log("Left");
        //        }
        //    }
        //}

        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
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

    // Update is called once per frame
    void Update()
    {
        inside();
    }
}
