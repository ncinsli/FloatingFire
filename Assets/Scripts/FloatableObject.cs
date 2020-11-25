using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FloatableObject : MonoBehaviour{
    [SerializeField] private Vector2 pullOffset = Vector2.up;
    [SerializeField] private float frequency = 0.1f;
    protected Rigidbody2D rigidbody;

    private void Start(){ 
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ForeverFloating());
    }
    public void PullUp() => rigidbody.gravityScale = -frequency - 0.2f;
    public void PullDown() => rigidbody.gravityScale = frequency;

    private void OnCollisionEnter2D(Collision2D col){
        //Из-за прерываний, к сожалению, бывают баги. Захардкодим их:
        PullUp(); 
    }

    private void OnTriggerEnter2D(Collider2D col) {
        var objectTouched = col.gameObject;
        var floatingSurface = objectTouched.GetComponent<FloatingSurface>();
        if (floatingSurface != null) PullUp();     
    }

    private void OnTriggerExit2D(Collider2D col){
        var objectTouched = col.gameObject;
        var floatingSurface = objectTouched.GetComponent<FloatingSurface>();
        if (floatingSurface != null) PullDown();   
    }

    private IEnumerator ForeverFloating(){
        for (int i = 0; i < 100; i++){
            rigidbody.velocity += Vector2.up * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        for (int j = 0; j < 100; j++){
            rigidbody.velocity += Vector2.up * Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(ForeverFloating());
    }
}
