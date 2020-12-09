using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Простая имплементация поведения при выборе объекта - следование его за курсором          
public class DragBySelect : MonoBehaviour, ISelectorBehaviour{
    public void OnSelectExists(GameObject target, Vector3 cursorPosition, Vector3 cursorOffset){
        if (!Input.GetKey(KeyCode.Mouse0)){
            target.GetComponent<Rigidbody2D>().gravityScale = 1f; return; 
        }
        cursorPosition.z = target.transform.position.z;
        target.GetComponent<Rigidbody2D>().gravityScale = 0f;
        target.transform.position = cursorPosition;
    }
}
