using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Selector))]
[RequireComponent(typeof(Cursor))]
public class CursorSelect : MonoBehaviour{
    protected Selector selector;
    protected Cursor cursor;
    private void Start(){
        selector = GetComponent<Selector>();
        cursor = GetComponent<Cursor>();
        cursor.onCursorMoved += selector.TrySelect;
    }

    private void OnApplicationQuit() => cursor.onCursorMoved -= selector.TrySelect; //Отписка от события 
}
