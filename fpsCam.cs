using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCam : MonoBehaviour
{

    public float rotSpeed = 0;
    float mx; //마우스의 X축 값
    float my; //마우스의 y축 값
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X"); //마우스 X축 움직임을 감지
        float v = Input.GetAxis("Mouse Y"); //마우스 Y축 움직임을 감지

        mx += h + rotSpeed ; //마우스 X각도를 누적해줌
        my += v + rotSpeed ;//마우스 Y각도를 누적해줌

        if (my >= 90) // my가 90도 이상이면
        {
            my = 90; //  my를 90도로 지정
        }
        else if (my <= -90) //my가 -90도 이하이면
        {
            my = -90; // my를 -90도로 지정
        }
        transform.eulerAngles = new Vector3(-my, mx, 0);
        my = Mathf.Clamp(my, -90, 90); //my의 범위가 최소값 -90부터 최대값 90까지로 지정
    }
}
