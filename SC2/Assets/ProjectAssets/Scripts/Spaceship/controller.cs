using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class controller : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 1;
    void Update()
    {
        // object rotation to movement vector 
        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward*rotationSpeed);
        }

        // movement by GetAxis
        float translationy = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float translationx = CrossPlatformInputManager.GetAxis("Horizontal") * -speed;
        translationx *= Time.deltaTime;
        translationy *= Time.deltaTime;
        
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-translationx, translationy));
    }
}
