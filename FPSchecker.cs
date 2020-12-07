using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//프레임체크
public class FPSchecker : MonoBehaviour
{
    [Range(1, 100)]
    public int fFont_Size;
    [Range(0, 1)]
    public float Red, Green, Blue;

    float deltaTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        fFont_Size = fFont_Size == 0 ? 50 : fFont_Size;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / fFont_Size;
        style.normal.textColor = new Color(Red, Green, Blue, 10.0f);
        float msec = deltaTime * 1000.0f; // 명령을 입력하고 실행까지 소요되는 시간 (ms)
        float fps = 1.0f / deltaTime; //1초에 그리는 프레임 장수 (fps , frames per second)
        string text = string.Format("{0:0.0} ms ({1:144.}fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
