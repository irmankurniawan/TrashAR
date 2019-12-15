using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private GameObject trashCan;

    private Material[] materials;
    private bool materialIsLoaded = false;

    private TRASHCAN_TYPE currentType;

    public void SetTrashCanType(TRASHCAN_TYPE type) {
        this.currentType = type;
    }

    public TRASHCAN_TYPE GetTrashCanType() {
        return this.currentType;
    }

    void InitMaterial() {
        materials[0] = Resources.Load("Models/plastic_blue.mat", typeof(Material)) as Material;
        materials[1] = Resources.Load("Models/plastic_green.mat", typeof(Material)) as Material;
        materials[2] = Resources.Load("Models/plastic_red.mat", typeof(Material)) as Material;
        materialIsLoaded = true;
        ShowToast("Material loaded!");
    }

    Material GetMaterialById(int number) {
        return materials[number];
    }

    GameObject CariTempatSampah() {
        if(GameObject.FindGameObjectWithTag("TrashCan") == null) {
            ShowToast("trashcan null");
            return null;
            
        }
        else {
            trashCan = GameObject.FindGameObjectWithTag("TrashCan");
            ShowToast("trashcan ditemukan");
            return trashCan;
        }
        
    }

    public void OnGroundPlaced() {
        ShowToast("Content Placed!");
        if(materialIsLoaded==true) {
            int rand = Random.Range(0,3);
            ShowToast("Randoman = " + rand.ToString());
            CariTempatSampah().GetComponent<MeshRenderer>().material = GetMaterialById(rand);
            SetTrashCanType((TRASHCAN_TYPE)rand);
            ShowToast("Material ganti menjadi " + GetTrashCanType().ToString());
            
        } else {
            InitMaterial();
        }
    }

    public bool CheckAnswer() {
        //
        if(GetTrashCanType() == TRASHCAN_TYPE.BLUE) {
            return true;
        }
        else return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowToast(string _message) {
 
        #if UNITY_ANDROID

        AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

        object[] toastParams = new object[3];
        AndroidJavaClass unityActivity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
        toastParams[0] = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");
        toastParams[1] = _message;
        toastParams[2] = toastClass.GetStatic<int>("LENGTH_SHORT");

        AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", toastParams);
        toastObject.Call ("show");

        #endif
     }
}


