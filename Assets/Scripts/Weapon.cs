using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    // 객체가 활성화 되는 순간 실행 
    void Start() 
    {
        Destroy(gameObject, 1f); // gameObject가 1초 뒤에 사라지도록 예약
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime; // Vector3.up은 (0, 1, 0)과 같다
    }
}
