using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Обычный селект объекта цветом, суть в том, что таких вариантов выбора объектов может быть много. Потому имплементируем ISelectable
[RequireComponent(typeof(SpriteRenderer))]
public class Selectable : MonoBehaviour, ISelectable{
    [SerializeField] private Color selectedColor;
    [Space] [SerializeField] private UnityEvent onSelects;  
    [SerializeField] private UnityEvent onDeselects;
    protected SpriteRenderer spriteRenderer;
    protected Color originColor;
    private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

    public void Select(){
        originColor = spriteRenderer.color;
        spriteRenderer.color = selectedColor;
        onSelects?.Invoke();
    }

    public void Deselect(){
        spriteRenderer.color = originColor;
        onDeselects?.Invoke();
    }
}
