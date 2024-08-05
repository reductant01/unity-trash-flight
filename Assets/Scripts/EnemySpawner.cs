using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies; 

    private float[] arrPosX = {-2.2f, -1.1f, 0f, 1.1f, 2.2f};

    [SerializeField]
    private float spawnInterval = 1.5f; 
    
    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoution(); // 왜 적들을 생성하는 코드를 Void Update안이 아니라 Start 안에 넣는걸까 성능때문일까?
    }

    void StartEnemyRoution() {
        StartCoroutine("EnemyRoution"); // Start에서 무한 반복문을 사용하면 다른 행동을 할 수 없게 되기에 StartCoroutine을 사용하여 자동으로 반복문이 실행되도록 한다
    }

    IEnumerator EnemyRoution() {
        yield return new WaitForSeconds(3f); // 처음 생성주기를 조절하기 위한 코드
        
        float moveSpeed = 5f;
        int spwanCount = 0;
        int enemyIndex = 0;
        while(true) {
            foreach (float posX in arrPosX) { // 배열안의 고정된 값을 반복할 때 사용하는 반복문
                // int index = UnityEngine.Random.Range(0, enemies.Length); // 0부터 enemies의 길이미만의 수 중 랜덤으로 숫자를 생성하는 코드
                SpawnEnemy(posX, enemyIndex, moveSpeed);
            }

            spwanCount += 1; // spwanCount++;
            if(spwanCount % 10 == 0) { // 10번째 반복마다 if문을 발생시키도록 하는 코드
                enemyIndex += 1;
                moveSpeed += 2f;
            }

            yield return new WaitForSeconds(spawnInterval); 
        }
    }

    void SpawnEnemy(float posX, int index, float moveSpeed) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z); 

        if (UnityEngine.Random.Range(0, 5) == 0) { // 0부터 4사이의 수 중 생성된 수가 0일때 (20%확률)
            index += 1;
        }

        if (index >= enemies.Length) {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity); // 객체 생성 코드(Player에서도 사용), (생성객체, 생성위치, 효과)
        Enemy enemy = enemyObject.GetComponent<Enemy>(); // Enemy.cs 호출
        enemy.SetMoveSpeed(moveSpeed); // public으로 쓰여진 SetMoveSpeed함수를 호출하여 moveSpeed 설정
    }

}
