using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followObject; 
    private Rigidbody2D followObjectRb;
    public Vector2 followOffset;
    public float speed = 1f;

    public Vector2 threshold;


    // Start is called before the first frame update
    void Start()
    {
        threshold = calculateThreshold();
        followObjectRb = followObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 follow = followObject.transform.position;
        float xDifference  = Vector2.Distance(Vector2.right * transform.position,Vector2.right * follow.x);
        float yDifference  = Vector2.Distance(Vector2.up * transform.position,Vector2.up * follow.y);
        Vector3 newPostion = transform.position;
        if(Mathf.Abs(xDifference) >= threshold.x){
            newPostion.x = follow.x;
        }
        if(Mathf.Abs(yDifference) >= threshold.y){
            newPostion.x = follow.x;
        }
        float moveSpeed = followObjectRb.velocity.magnitude > speed ? followObjectRb.velocity.magnitude : speed;
        transform.position = Vector3.MoveTowards(transform.position, newPostion, moveSpeed * Time.deltaTime );

    }


    private Vector3 calculateThreshold(){
        Rect aspect =  Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x *2,border.y*2,1));
    }
}
