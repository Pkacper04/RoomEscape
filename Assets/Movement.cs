using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction_z = Input.GetAxis("Vertical");
        float direction_x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {

            Vector3 newVelocity = new Vector3(rigid.velocity.x, 0, direction_z * speed );
            float CameraRotation = transform.rotation.eulerAngles.y;

            rigid.position += Quaternion.Euler(0, CameraRotation, 0) * newVelocity * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Vector3 newVelocity = new Vector3(direction_x * speed, 0, rigid.velocity.z);

            float CameraRotation = transform.rotation.eulerAngles.y;

            rigid.position += Quaternion.Euler(0, CameraRotation, 0) * newVelocity * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles = transform.localRotation.eulerAngles + new Vector3(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles = transform.localRotation.eulerAngles + new Vector3(0, 1, 0);
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rigid.velocity = Vector3.zero;
        }
    }
}
