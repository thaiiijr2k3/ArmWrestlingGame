using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
   
    Touch _touch;
    int _counter;
    Transform _leftArm;
    Transform _rightArm;
    GameObject _gameController;

    void Start()
    {
        _counter = 0;
        _leftArm = GameObject.Find("LeftArm").transform;
        _rightArm = GameObject.Find("RightArm").transform;
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
                        //Debug.Log(_counter);

                    }
                    if (hit.transform.tag.Equals("Left"))
                    {
                        _counter -= 1;
                        //Debug.Log(_counter);
                    }
                }
            }

        }

    }

    void RotateArms()
    {
        _leftArm.Rotate(0f, 0f, _counter * 0.01f, Space.World);
        _rightArm.Rotate(0f, 0f, _counter * 0.01f, Space.World);
        //Debug.Log(_leftArm.localRotation.eulerAngles.z);
        //Använd debug.log för att ta reda på start-värde och fick 345.

        if (_leftArm.localRotation.eulerAngles.z <= 5f)  // när z-rotation är 0
        {   
            //Debug.Log("Left arm won"); 
            _gameController.GetComponent<GameController>().VicToryPlayer(true);
            _gameController.GetComponent<GameController>().EndGame();
            
        } // 360 - 345 = 15
        else if(_leftArm.localRotation.eulerAngles.z <= 330 && _leftArm.localRotation.eulerAngles.z > 300)  // 345-15 = 330
        {
            //Debug.Log("Right arm won");
            _gameController.GetComponent<GameController>().VicToryPlayer(false);
            _gameController.GetComponent<GameController>().EndGame();
        }
    }




    void Update()
    {
        TouchInputControll();
        RotateArms();
    }
}
