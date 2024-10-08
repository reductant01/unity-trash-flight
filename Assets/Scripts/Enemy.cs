using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float moveSpeed) { // public으로 만들어진것 확인, private로 쓰고 싶다면?
        this.moveSpeed = moveSpeed; // this.moveSpeed는 클래스내에 정의된 변수이고, moveSpeed는 함수 호출시 전달받은 변수 이다
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y < minY) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other) { // isTrigger가 체크 되있을때(충돌감지만 될때) 사용, 만약 물리적인 충돌을 사용하고 싶다면 OnCollisionEnter2D사용
        if (other.gameObject.tag == "Weapon") { // 이 코드를 위해 tag 사용
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0) {
                if (gameObject.tag == "Boss") {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject); // 적이 사라지게 하는 코드
                Instantiate(coin, transform.position, Quaternion.identity); // 객체 생성 코드, coin을 등장시키고 Coin.cs 코드에 의해 코인은 움직인다
            }
            Destroy(other.gameObject); // weapon이 사라지게 하는 코드
        }
    }

}
