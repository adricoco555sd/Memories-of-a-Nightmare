using System;
using UnityEngine;



public class OnStart : MonoBehaviour
{
    [SerializeField] public GameObject mainMenu;
    [SerializeField] public GameObject logIn;

    private void Start()
    {
        mainMenu.SetActive(false);
        logIn.SetActive(true);
    }

    private void Awake()
    {
        mainMenu.SetActive(false);
        logIn.SetActive(true);
    }
}
