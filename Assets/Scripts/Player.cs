using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    // moveSpeed를 입력받을 수 있게 함
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform; // Player 코드 아래로 받아서 shootTransform와 Player의 위치가 함께 조정될 수 있도록 함

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // 키보드를 사용하여 Player 움직이기 1(위아래 이동 포함)
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // 키보드를 사용하여 Player 움직이기 2(위아래 이동 미포함)
        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     transform.position -= moveTo;
        // } else if (Input.GetKey(KeyCode.RightArrow)) {
        //     transform.position += moveTo;
        // }

        // 마우스를 사용하여 Player 움직이기
        // Debug.Log(Input.mousePosition); 화면 해상도 기준이 아닌 카메라 기준으로 위치를 잡아야함
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(mousePos); console에 마우스의 현재 위치를 표시할수 있음
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f); // mousePos.x의 최소값과 최대값을 지정하여 화면밖으로 벗어나지 못하도록 함
        transform.position = new Vector3(toX, transform.position.y, transform.position.z); // 마우스에 따라서 x값만 변하도록 해야함 

        Shoot();
    }

    void Shoot() {
        // 10 - 0 > 0.05 ? 
        // lastShotTime = 10

        // 10.01 - 10 > 0.05 ?
        // false
        // 10.02 - 10 > 0.05 ?
        // 10.03 - 10 > 0.05 ?
        // ..

        // 10.06 - 10 > 0.05 ?
        // lastShotTime = 10.06

        if(Time.time - lastShotTime > shootInterval) { // 발사 간격 조절
            Instantiate(weapon, shootTransform.position, Quaternion.identity); // 게임오브젝트를 만드는 코드
            // Instantiate(발사물체, 발사위치, 발사효과(Quaternion.identity는 아무런 회전없이 일직선으로 날아감))
            lastShotTime = Time.time;
        }
        
        
    }
}
