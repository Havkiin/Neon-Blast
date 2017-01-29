using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class BulletHell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

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
        SceneManager.LoadScene("Game");
        Player.bulletHellCount = 1;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            GetComponent<Text>().color = Color.white;
        }
    }
}
