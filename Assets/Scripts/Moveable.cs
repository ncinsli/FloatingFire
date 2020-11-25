using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovingStrategy{
    void MoveLeft(Rigidbody2D rigidbody);
    void MoveRight(Rigidbody2D rigidbody);
    void OnKeyUp();
}

[RequireComponent(typeof(Rigidbody2D))]
public class Moveable : MonoBehaviour{
    [SerializeField] private KeyCode[] keyCodes = {KeyCode.A, KeyCode.D};
    protected IMovingStrategy movingStrategy;
    protected Rigidbody2D rigidbody;
    private void Start(){ 
        movingStrategy = GetComponent<IMovingStrategy>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable() => Start();

    private void FixedUpdate(){
        if (Input.GetKey(keyCodes[0])) movingStrategy.MoveLeft(rigidbody);
        if (Input.GetKey(keyCodes[1])) movingStrategy.MoveRight(rigidbody);
    }

    private void Update(){ if (Input.GetKeyUp(keyCodes[0]) || Input.GetKeyUp(keyCodes[1])) movingStrategy.OnKeyUp(); }
}
