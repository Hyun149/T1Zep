using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
