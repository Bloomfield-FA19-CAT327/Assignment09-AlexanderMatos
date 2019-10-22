using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousLevel : MonoBehaviour
{
    void OnTriggerEnter()
    {
        SingletonGameController.Instance.PreviousLevel();
    }
}
