using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour{
    [SerializeField] private float speed = 0.5f;
    public event Action onCursorMoved;

    private void Start(){
        Screen.lockCursor = true;
        Vector3 projection3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(projection3d.x, projection3d.y, transform.position.z);
    }
    private void Update(){ 
        var deltaVector = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * speed; 
        transform.position += deltaVector;
        if (deltaVector != Vector3.zero && onCursorMoved != null) onCursorMoved();
    }
}
