using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable{
    void Select();
    void Deselect();
}
public interface ISelectorBehaviour{ void OnSelectExists(GameObject target, Vector3 cursorPosition, Vector3 cursorOffset); }

[RequireComponent(typeof(Cursor))]
public class Selector : MonoBehaviour{
    protected Cursor cursor;
    protected ISelectorBehaviour selectBehaviour; 
    protected ISelectable selectedObject;
    protected ISelectable lastSelectedObject;
    protected RaycastHit2D hit;
    private void Start(){ 
        selectBehaviour = GetComponent<ISelectorBehaviour>();
        cursor = GetComponent<Cursor>();
        cursor.onCursorMoved += TrySelect;
    }

    public void TrySelect(){
        hit = Physics2D.Raycast(transform.position, Vector3.forward);
        if (hit.collider != null){
            if (hit.collider.gameObject.GetComponent<ISelectable>() == null) return;
            selectedObject = hit.collider.GetComponent<ISelectable>();
            lastSelectedObject?.Deselect();
            selectedObject.Select();
            lastSelectedObject = selectedObject;
            selectBehaviour?.OnSelectExists(hit.collider.gameObject, cursor.position, cursor.offset);
        }
    }

    private void OnEnable() => cursor.onCursorMoved -= TrySelect;
}
