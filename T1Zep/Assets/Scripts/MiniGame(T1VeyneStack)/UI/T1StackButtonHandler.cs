using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T1StackButtonHandler : MonoBehaviour
{
    public void LoadStackScene()
    {
        SceneLoader.Load(SceneType.TStackScene);
    }
}
