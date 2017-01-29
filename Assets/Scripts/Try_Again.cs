﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class Try_Again : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Enemy_Spawn.gameover)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            GetComponent<Text>().color = Color.white;
        }
    }
}
