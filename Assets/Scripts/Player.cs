using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    // moveSpeed를 입력받을 수 있게 함
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

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

        if (GameManager.instance.isGameOver == false) {
            Shoot(); // GameOver가 된다면 Shoot을 그만하게 하고싶음
        }
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
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity); // 게임오브젝트를 만드는 코드
            // Instantiate(발사물체, 발사위치, 발사효과(Quaternion.identity는 아무런 효과 없음)), Instantiate로 객체를 등장시키고 앞으로 날아가는 것은 weapon의 코드이다
            lastShotTime = Time.time;
        }
    }

    /// <summary>
        /// Sent when another object enters a trigger collider attached to this
        /// object (2D physics only).
        /// </summary>
        /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") {
            // Debug.Log("Game Over");
            GameManager.instance.SetGameOver(); // GameManager.instance로 호출하는거 기억!!
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Coin") {
            // Debug.Log("Coin + 1");
            GameManager.instance.IncreaseCoin(); // 그냥 GameManager.IncreaseCoin();를 호출하는 것이 아니라 GameManager.instance.IncreaseCoin();의 코드를 사용함으로써 유일한 GameManager를 호출할 수 있도록 한다 
            Destroy(other.gameObject);
        }
    }

    public void Upgrade() {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length) {
            weaponIndex = weapons.Length - 1; // weapons배열이 3개 밖에 없기에 weaponIndex가 3보다 크지 않도록 한다
        }
    }
} 
