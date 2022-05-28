using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    public CharacterController2D controller;
    public static HookScript instance;

    private Vector3 mousePos;
    public Camera Cam;

    public LayerMask grapplingMask;
    public bool check;
    [HideInInspector]
   

    public LineRenderer lineRenderer;

    public Vector3 tempPos;

    public DistanceJoint2D distanceJoint;


    public bool hookable = false;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        distanceJoint = GetComponent<DistanceJoint2D>();
        lineRenderer = GetComponent<LineRenderer>();

        distanceJoint.enabled = false;
        check = true;
        lineRenderer.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();

        RaycastHit2D hit2d = Physics2D.Raycast(Cam.transform.position, mousePos, Mathf.Infinity, grapplingMask);        

        if(Input.GetMouseButtonDown(0) && check /*&& hit2d*/ && hookable )
        {
            CharacterController2D.instance.m_Grappled = true;
            CharacterController2D.instance.m_AirControl = false;
            tempPos = mousePos;
            distanceJoint.enabled = true;
            //distanceJoint.connectedAnchor = hit2d.point;
            distanceJoint.connectedAnchor = mousePos;
            lineRenderer.positionCount = 2;

            ResourceController.instance.air = true;
            check = false;
        } else if (Input.GetMouseButtonDown(0) && PlayerController.instance.canMove == true)
        {
            distanceJoint.enabled = false;
            CharacterController2D.instance.m_AirControl = true;
            CharacterController2D.instance.m_Grappled = false;
            check = true;
            lineRenderer.positionCount = 0;
            ResourceController.instance.air = false;
        }
        DrawLine();

        if (distanceJoint.distance <= 0.005)
        {
            distanceJoint.distance = 1;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            distanceJoint.distance -= 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            distanceJoint.distance += 1;
        }
    }

    private void DrawLine()
    {
        if (lineRenderer.positionCount <= 0) return;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, tempPos);
    }

    private void GetMousePos ()
    {
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);
    }

}
