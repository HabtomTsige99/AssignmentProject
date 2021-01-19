using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPlayer : MonoBehaviour
{ 
   public Rigidbody2D rb;
   public Rigidbody2D anchor;
   public float ReleaseTime = 5f;
   public float maxDragDistance = 2f;

   private bool isPressed = false;
   private Vector2 mousePos;

    void Update()
   {
       if (isPressed)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(mousePos, anchor.position) > maxDragDistance)
            rb.position = (anchor.position - mousePos).normalized * maxDragDistance;
        }
        //
        else
        {
            rb.position = mousePos;
        }    
    }
   void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
         isPressed =false; 
        rb.isKinematic = false;
        StartCoroutine(Release());
    }
    IEnumerator Release()
    {
        yield return new WaitForSeconds(ReleaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }
    
 

  
    
}
