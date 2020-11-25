using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Очень рекомендуется устанавливать только на камеру
public class FollowPlayer : MonoBehaviour{
    [SerializeField] private float maxOffsetLeft = 1f;
    [SerializeField] private float maxOffsetRight = -1f; 
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private bool followY;

    private void FixedUpdate() {
        var offset = objectToFollow.position.x - transform.position.x;
        if (offset > maxOffsetRight) transform.position += Vector3.right * Time.deltaTime;
        if (offset < maxOffsetLeft) transform.position += Vector3.left * Time.deltaTime;
        if (followY) 
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, objectToFollow.position.y, 0.1f), transform.position.z);
    }
}
