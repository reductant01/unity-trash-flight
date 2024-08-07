using System.Collections;
using System.Collections.Generic;
using TMPro; // TextMeshProUGUI 클래스를 사용하기 위한 코드 
using UnityEngine;

public class GameManager : MonoBehaviour // 이해는 잘 안가지만 ....여러개의 코인을 먹었을때 일관성을 해칠 가능성이 있기에 GameManager를 사용하여 coin의 값을 관리한다고 한다.
{
    public static GameManager instance = null; // static은 클래스 맴버를 클래스 자체에 속하게 하는 만든다 (클래스를 여러번 호출하더라도 여러 클래스에서 그 값을 공유한다)

    [SerializeField]
    private TextMeshProUGUI text;

    private int coin = 0;

    void Awake() { // void Start보다 먼저 실행된다.
        if (instance == null) {
            instance = this; // 잘 이해가 안된다...instance가 static으로 설정되어 있기에 하나의 GameManager만 존재할수있게 하기위해 이 코드를 사용한다는 것은 알았다..
        }
    }

    public void IncreaseCoin() {
        coin += 1;
        text.SetText(coin.ToString()); // SetText()안에는 문자열이 들어가야하기에 int값인 coin을 ToString()을 사용하여 형을 바꿔줄 필요가 있다.

        if (coin % 10 == 0) {
            // OnTriggerEnter2D코드와 달리 가지고 오는 값이 없으므로 객체를 찾아서 가지고 올 필요가 있다
            Player player = FindObjectOfType<Player>(); // FindObjectOfType<>()는 객체의 타입을 찾아서 가지고 온다
            if (player != null) {
                player.Upgrade(); // 타입이 Player인 객체를 찾으면 palyer의 Upgrade함수를 실행한다
            }
        }
    }
}
