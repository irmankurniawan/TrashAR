using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Button markerButton, markerlessButton;    
    
    void Awake() {
        markerButton = GameObject.FindGameObjectWithTag("MarkerButton").GetComponent<Button>();
        markerlessButton = GameObject.FindGameObjectWithTag("MarkerlessButton").GetComponent<Button>();

        markerButton.onClick.RemoveAllListeners();
        markerlessButton.onClick.RemoveAllListeners();
        markerButton.onClick.AddListener(() => OnMarkerButtonClick());
        markerlessButton.onClick.AddListener(() => OnMarkerlessButtonClick());
    }

    void OnMarkerButtonClick() {
        SceneManager.LoadScene("MarkerScene");
    }

    void OnMarkerlessButtonClick() {
        SceneManager.LoadScene("MarkerlessScene");
    }

    void Start() {
        
    }

}
