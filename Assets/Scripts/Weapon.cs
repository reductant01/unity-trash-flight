using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f; // 다른 클래스에서도 사용하도록 하기위해 public으로 사용

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
