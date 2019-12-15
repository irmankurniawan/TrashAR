using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDetection : MonoBehaviour
{
    public ImageScript imageScript;
    string typeTrash;

    void Start() {
        typeTrash = ConvertTrashTypeToString(imageScript.GetTrashCanType());
    }

    void OnTriggerEnter(Collider col) {
        Debug.LogWarning("collide");
        typeTrash = ConvertTrashTypeToString(imageScript.GetTrashCanType());
        if(col.gameObject.tag == typeTrash) {
            //destroy;
            imageScript.GantiWarna();
            Debug.LogWarning("destroy");
            Destroy(col.gameObject);
        }
        else {
            //
//            Debug.LogWarning("tidak");
        }
    }

    string ConvertTrashTypeToString(TRASHCAN_TYPE type) {
        if(type == TRASHCAN_TYPE.BLUE)
            return "BlueCube";
        else if(type == TRASHCAN_TYPE.RED)
            return "RedCube";
        else if(type == TRASHCAN_TYPE.GREEN)
            return "GreenCube";
        else return "";
    }
}
