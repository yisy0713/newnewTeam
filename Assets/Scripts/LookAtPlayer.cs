using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform ������Ʈ�� �����ؾ� �մϴ�.
    private Animator animator; // NPC ��ü�� Animator ������Ʈ�� �����ؾ� �մϴ�.

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ���⿡ ���� �ִϸ��̼��� �����մϴ�.
            if (direction.x < 0)
            {
                animator.Play("npc_left_idle");
            }
            else
            {
                animator.Play("npc_right_idle");
            }
        }
    }
}
