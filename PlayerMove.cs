using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerMoveSpeed = 5; //플레이어 속도정의
    public float gravity = -9.8f; //기본 중력가속도 -9.8
    float yVelocity; //중력

    public float jumpPower = 5; //점프력을 5로 설정
    public int maxJumpCount = 1; //1회 점프횟수를 1회로 제한
    int jumpCount = 0; //현재 점프횟수이며 한번 점프할때마다 1씩 증가. 최대1 

    CharacterController cc; //캐릭터 컨트롤러를 cc로 정의한다.
    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>(); // 컴포넌트 중 캐릭터컨트롤러를 가져온다. 캐릭터컨트롤러 컴포넌트 안에 콜라이더와 리지드바디가 들어있다.
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 사용자 입력처리
        float v = Input.GetAxis("Vertical"); // "

        Vector3 dir = new Vector3(h, 0, v); // 움직이는 것이 y축이아니라 x,z축만을 이동한다.
        dir.Normalize(); //정규화

        dir = Camera.main.transform.TransformDirection(dir); //내가 바라보는 카메라의 방향으로 이동한다.메인카메라의 태그를 MainCamera로 변경해주어야함.

       
        
        if (cc.collisionFlags == CollisionFlags.Below) //만약 Player가 바닥과 닿으면
        {
            jumpCount = 0; //점프카운트를 0으로 초기화
            yVelocity = 0; //중력을 0으로 초기화
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (jumpCount == 0 && cc.collisionFlags != CollisionFlags.Below) //만약 점프카운트가 0인동시에 플레이어가 바닥에 닿지 않다면
            {
                return;
            }
            else if (jumpCount < maxJumpCount) // 만약 점프카운트가 최대횟수보다 작다면
            {
                yVelocity = jumpPower; // 중력 = 점프파워
                jumpCount++; //점프카운트를 1 증가
            }
        }
        //transform.position += dir * playerMoveSpeed * Time.deltaTime;

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        cc.Move(dir * playerMoveSpeed * Time.deltaTime);
    }
}
