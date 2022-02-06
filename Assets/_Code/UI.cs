using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance;

    [SerializeField] private GameObject _winScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivateWinScreen()
    {
        _winScreen.SetActive(true);
    }
}
