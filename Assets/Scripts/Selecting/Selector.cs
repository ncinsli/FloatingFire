using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable{
    void Select();
    void Deselect();
}

public class Selector : MonoBehaviour{
    protected ISelectable selectedObject;
    protected ISelectable lastSelectedObject;
    protected RaycastHit2D hit;

    public void TrySelect(){
        hit = Physics2D.Raycast(transform.position, Vector3.forward);
        if (hit.collider != null){
            if (hit.collider.gameObject.GetComponent<ISelectable>() == null) return;
            selectedObject = hit.collider.GetComponent<ISelectable>();
            lastSelectedObject?.Deselect();
            selectedObject.Select();
            lastSelectedObject = selectedObject;
        }
    }
}
