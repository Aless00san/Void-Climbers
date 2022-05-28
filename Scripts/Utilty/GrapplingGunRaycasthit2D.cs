//************** REAL GAMES STUDIO ***************
//************************************************
//realgamesss.weebly.com
//gamejolt.com/@Real_Game
//realgamesss.newgrounds.com/
//real-games.itch.io/
//youtube.com/channel/UC_Adg-mo-IPg6uLacuQCZCQ
//************************************************
using UnityEngine;

public class GrapplingGunRaycasthit2D : MonoBehaviour
{
    public static GrapplingGunRaycasthit2D instance;

    public LayerMask ropeLayerMask;

    public DistanceJoint2D theJoint;

    public float distance = 90.0f;

    public LineRenderer line;

    Vector2 lookDirection;

    public bool checker = true;

    private void Awake()
    {
        instance = this;
    }
        void Start()
    {
        line = GetComponent<LineRenderer>();

        theJoint.enabled = false;
        line.enabled = false;
    }

    void Update()
    {
        line.SetPosition(0, transform.position);

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        Debug.DrawLine(transform.position, lookDirection);

        if (Input.GetMouseButtonDown(0) && checker == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, distance, ropeLayerMask);
            
            if (hit.collider != null)
            {
                checker = false;
                ResourceController.instance.air = false;
                CharacterController2D.instance.m_Grappled = true;
                CharacterController2D.instance.m_AirControl = false;
                ResourceController.instance.air = true;
                SetRope(hit);
            }
        }
        else if (Input.GetMouseButtonDown(0) && checker == false)
        {
            CharacterController2D.instance.m_AirControl = true;
            CharacterController2D.instance.m_Grappled = false;
            ResourceController.instance.air = false;
            checker = true;
            DestroyRope();
        }

        if (theJoint.distance <= 0.005)
        {
            theJoint.distance = 1;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            theJoint.distance -= 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            theJoint.distance += 1;
        }
    }

    void SetRope(RaycastHit2D hit)
    {
        theJoint.enabled = true;
        theJoint.connectedAnchor = hit.point;

        line.enabled = true;
        line.SetPosition(1, hit.point);
    }

    void DestroyRope()
    {
        theJoint.enabled = false;
        line.enabled = false;
    }
}