using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private RopeAnimationCount animationCount;
    public Transform targetPosition;
    private bool hasMoved = false;
    public float moveSpeed = 5f;

    private void Awake()
    {
        // find를 안쓰려고 노력은 하는데 이번에 처음 써 본 부분이기도 하고, 작은 게임 볼륨을 만든다고 가정하여 사용하기는 했다.
        animationCount = FindObjectOfType<RopeAnimationCount>();
    }

    private void Update()
    {
        // haseMoved가 false라면 실행이 되도록 되어있는데 이 부분은 도움을 받은 부분이라 
        // 거의 무조건 작동한다라고 생각이 든다.
        if (!hasMoved)
        {
            int count = animationCount.instance.count;
            if (count > 10)
            {
                gameObject.SetActive(true);
                obstacleNPC();
            }
        }
    }

    void obstacleNPC()
    {
        if (targetPosition != null)
        {
            // 목표까지 npc를 이동시키려면 지금 현재코드로는 rigidbody가 없어야 하는 것 같다.
            // 그리고 현재 target이라는 GameObject를 지정해두었기 때문에 그 지점까지 움직이는 것이기는 하지만
            // 다른 방식을 사용해보고는 싶지만 아직 떠오르는 부분이 없는 듯 하다.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * moveSpeed);
            if (transform.position == targetPosition.position)
            {
                hasMoved = true;
                gameObject.SetActive(false);
            }
        }
    }
}
