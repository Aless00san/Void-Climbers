using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public static EnemyIA instance;

    private float speed = 5f;
    public bool stunned;
    //private bool flipp;
    private Vector2 targetV;
    private Vector2 targetV2;
    //private Vector2 moveWing;

    public int timeToTurn;
    public GameObject target, target2, wing;
    public SpriteRenderer theSR, theSR2;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetV = new Vector2(0.0f, 0.0f);
        targetV2 = new Vector2(0.0f, 0.0f);
        targetV = new Vector2(target.transform.position.x, target.transform.position.y);
        targetV2 = new Vector2(target2.transform.position.x, target2.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //moveWing = new Vector2(wing.transform.position.x - 0.145f, wing.transform.position.y);

        

        if ((gameObject.transform.position.x, gameObject.transform.position.y) == (targetV.x, targetV.y) && stunned == false)
        {
            
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                //theSR.flipX = true;
                //theSR2.flipX = true;
                //flipp = true;
                //anim.SetBool("Flipped", true);
                yield return new WaitForSeconds(2);
                transform.position = Vector2.MoveTowards(transform.position, targetV2, step);
            }
            
        }

        /*if (flipp == true)
        {
            wing.transform.position = (moveWing);
        }*/

        if ((gameObject.transform.position.x, gameObject.transform.position.y) == (targetV2.x, targetV2.y) && stunned == false)
        {
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                yield return new WaitForSeconds(2);
                transform.position = Vector2.MoveTowards(transform.position, targetV, step);
            }
        }
        if (stunned == true)
        {
            StartCoroutine(waiter());
            IEnumerator waiter()
            {
                yield return new WaitForSeconds(2);
                stunned = false;
            }
        }
    }
}
