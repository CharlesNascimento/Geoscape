using UnityEngine;
using System.Collections;

public class BlockMover : MonoBehaviour {

	public enum motionDirections {Spin,Horizontal, Vertical, Round};
 
    public float motionMagnitude = 0.1f;
    public bool blockTriggered = true;
    public float spinSpeed = 180.0f;
 
    public motionDirections motionState = motionDirections.Horizontal;
 
    private Vector3 _startPosition;
 
    void Start () 
    {
        _startPosition = transform.position;
    }
 
 
    // Update is called once per frame
    void Update () {
        if (blockTriggered) {
            switch (motionState) {
                case motionDirections.Spin:
                    // rotate around the up axix of the gameObject
                    gameObject.transform.Rotate (Vector3.forward * spinSpeed * Time.deltaTime);
                    break;
                case motionDirections.Horizontal:
                    // move up and down over time
                    //gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.time) * motionMagnitude);
                    /* Vector3 _newPosition;
                    _newPosition = transform.position;
                    _newPosition.x += Mathf.Sin(Time.time) * Time.deltaTime;
                    transform.position = _newPosition ;*/
                transform.position = _startPosition + new Vector3 (Mathf.Sin (Time.timeSinceLevelLoad) * motionMagnitude, 0.0f, 0.0f);
                     
                    break;
                case motionDirections.Vertical:
                    // move up and down over time
                transform.position = _startPosition + new Vector3 (0.0f, Mathf.Sin (Time.time) * motionMagnitude, 0.0f);
                    break;
                case motionDirections.Round:
                transform.position = _startPosition + new Vector3 (Mathf.Sin (Time.timeSinceLevelLoad) * motionMagnitude, Mathf.Cos (Time.timeSinceLevelLoad) * motionMagnitude, 0.0f);
                    break;
            }
        }
 
    }
}
