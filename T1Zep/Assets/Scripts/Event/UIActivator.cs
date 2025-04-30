using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] targets;

    public void Activate()
    {
        SetActiveAll(true);
    }

    public void Deactivate()
    {
        SetActiveAll(false);
    }

    private void SetActiveAll(bool state)
    {
        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                target.SetActive(state);
            }
        }
    }
}
