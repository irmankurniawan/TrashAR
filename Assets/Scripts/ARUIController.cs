using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARUIController : MonoBehaviour
{
    Button backButton;    
    
    void Awake() {
        backButton = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() => OnBackButtonClick());
    }

    void OnBackButtonClick() {
        SceneManager.LoadScene("Menu");
    }


    void Start() {
        
    }

}
