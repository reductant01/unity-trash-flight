using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    void Jump() {
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>(); // RigidBodt2D 객체를 가지고 옮

        float randomJumpForce = UnityEngine.Random.Range(4f, 8f); // Range()사이에 실수값을 입력하면 좀더 다양한 수를 얻을 수 있다.
        Vector2 jumpVelocity = Vector2.up * randomJumpForce; // Vector2는 x, y 값만 가지는 좌표, 코인이 위로 뜨는 효과를 가짐
        jumpVelocity.x = UnityEngine.Random.Range(-2f, 2f); // Vector2의 x좌표를 조정
        
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse); // AddForce(Vector2 기준으로 힘을 어느정도로 할지, 모드 설정)
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY) {
            Destroy(gameObject);
        }
    }
}
