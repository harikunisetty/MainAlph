using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public string nextSceneName;
    void Start()
    {
        
    }
    public void ScrbbileAlph()
    {
        if (string.IsNullOrEmpty(nextSceneName))
        {
            return;
        }
        Application.LoadLevel(nextSceneName);
    }
}
