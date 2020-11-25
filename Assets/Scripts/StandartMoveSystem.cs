using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BodyAnimator))]
public class StandartMoveSystem : MonoBehaviour, IMovingStrategy{
    [SerializeField] private Vector2 left;
    [SerializeField] private Vector2 right;
    [SerializeField] private BodyAnimator animator;
    public void MoveLeft(Rigidbody2D body){
        body.position += left * Time.deltaTime;
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        animator.state = BodyAnimationState.PlayerGoesLeft;
    }
    public void MoveRight(Rigidbody2D body){
        body.position += right * Time.deltaTime;   
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        animator.state = BodyAnimationState.PlayerGoesLeft;
    }
    public void OnKeyUp() => animator.state = BodyAnimationState.Standart; 
}
