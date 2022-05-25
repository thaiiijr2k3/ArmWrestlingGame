using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
  
    int _counter;
    GameObject[] _arms;
    GameObject _gameController;

    void Start()
    {
        _counter = 0;
        _arms = GameObject.FindGameObjectsWithTag("Arm");
        _gameController = GameObject.Find("GameController");
    }

    void TouchInputControll()
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
                        _counter += 1;
                        Debug.Log(_counter);

                    }
                    if (hit.transform.tag.Equals("Left"))
                    {
                        _counter -= 1;
                        Debug.Log(_counter);
                    }
                }
            }

        }

    }

    void RotateArms()
    {
        foreach(GameObject arm in _arms)
        {
            arm.transform.Rotate(0f, 0f, _counter * 0.1f, Space.World);
        }

        //Debug.Log(_leftArm.localRotation.eulerAngles.z);
        //Använd debug.log för att ta reda på start-värde och fick 345.

        if (_arms[0].transform.localRotation.eulerAngles.z <= 5f)  // när z-rotation är 0
        {   
            //Debug.Log("Left arm won");            
            _gameController.GetComponent<GameController>().EndGame(true);

        } // 360 - 345 = 15
        else if(_arms[0].transform.localRotation.eulerAngles.z <= 330 && _arms[0].transform.localRotation.eulerAngles.z > 300)  // 345-15 = 330
        {
            //Debug.Log("Right arm won");            
            _gameController.GetComponent<GameController>().EndGame(false);
        }
    }




    void Update()
    {
        TouchInputControll();
        RotateArms();
    }
}
