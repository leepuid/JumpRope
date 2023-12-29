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
        // find�� �Ⱦ����� ����� �ϴµ� �̹��� ó�� �� �� �κ��̱⵵ �ϰ�, ���� ���� ������ ����ٰ� �����Ͽ� ����ϱ�� �ߴ�.
        animationCount = FindObjectOfType<RopeAnimationCount>();
    }

    private void Update()
    {
        // haseMoved�� false��� ������ �ǵ��� �Ǿ��ִµ� �� �κ��� ������ ���� �κ��̶� 
        // ���� ������ �۵��Ѵٶ�� ������ ���.
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
            // ��ǥ���� npc�� �̵���Ű���� ���� �����ڵ�δ� rigidbody�� ����� �ϴ� �� ����.
            // �׸��� ���� target�̶�� GameObject�� �����صξ��� ������ �� �������� �����̴� ���̱�� ������
            // �ٸ� ����� ����غ���� ������ ���� �������� �κ��� ���� �� �ϴ�.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * moveSpeed);
            if (transform.position == targetPosition.position)
            {
                hasMoved = true;
                gameObject.SetActive(false);
            }
        }
    }
}
