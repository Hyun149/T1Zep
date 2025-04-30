using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] private string message = "EVENT MAP: 이벤트가 시작됩니다!";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(message);
            // TODO; 미니게임 or 컷씬 시작
        }
    }
}
