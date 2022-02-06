using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossZone : MonoBehaviour
{
    private void Start()
    {
        SceneLoadManager.Instance.SetNewCross();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Box"))
        {
            SceneLoadManager.Instance.SetMinusCross();
        }
    }
}
