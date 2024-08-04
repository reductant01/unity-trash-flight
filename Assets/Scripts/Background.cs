using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        // 배경이 moveSpeed에 맞게 움직이도록 함
        // y가 -10이 되면 이미지 교체 필요
        // Vector3.down은 (0, -1, 0)과 같다
        transform.position += Vector3.down * moveSpeed * Time.deltaTime; // 컴퓨터의 성능에 따라 Update되는 빈도가 다르기 때문에 Time.deltaTime를 곱하여 일정한 속도유지
        if (transform.position.y < -10) {
            transform.position += new Vector3(0, 20f, 0); // 10*2만큼 위로 올라가야함 
        }
    }
}
