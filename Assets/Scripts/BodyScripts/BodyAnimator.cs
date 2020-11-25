using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BodyAnimator : MonoBehaviour{
    protected Animator animator;
    [SerializeField] private BodyAnimationState _state;
    public BodyAnimationState state{ get => _state; set{ 
        CallAnimation(value);
        _state = value; 
    }}
    private Dictionary<BodyAnimationState, string> animationMap = new Dictionary<BodyAnimationState, string> {
        {BodyAnimationState.Standart, "GoesToStandartTrigger"},
        {BodyAnimationState.PlayerGoesLeft, "GoesLeftTrigger"},
        {BodyAnimationState.PlayerGoesUp, "GoesUpTrigger"}
    };
    private void Start() => animator = GetComponent<Animator>();
    private void CallAnimation(BodyAnimationState callState) => animator.SetTrigger(animationMap[callState]);
}

public enum BodyAnimationState{Standart, PlayerGoesLeft, PlayerGoesUp}