using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cHide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //마우스커서가 화면밖으로 빠져나가지못하게 잠근다.
        Cursor.visible = false; //커서를 안보이게 한다.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
