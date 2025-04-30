using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] private string message = "이벤트가 시작됩니다!";
    [SerializeField] private GameObject uiTextToShow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(message);
            
            if (uiTextToShow != null)
            {
                uiTextToShow.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (uiTextToShow != null)
            {
                uiTextToShow.SetActive(false);
            }
        }
    }
}
