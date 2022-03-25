using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private float movementSpeed = 7;
    [SerializeField] private float rotationSpeed = 100;

    private bool inShake = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimerController.StartTime)
            return;
        MovePlayer();

        RotatePlayer();

        

    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.Q))
            transform.eulerAngles = transform.localRotation.eulerAngles + new Vector3(0, -1 * rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.E))
            transform.eulerAngles = transform.localRotation.eulerAngles + new Vector3(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        float CameraRotation = transform.rotation.eulerAngles.y;

        rigid.position += Quaternion.Euler(0, CameraRotation, 0) * movement * movementSpeed * Time.deltaTime;

        if (!inShake && movement != Vector3.zero)
            StartCoroutine("CameraShaking");
        else if (movement == Vector3.zero)
        {
            StopCoroutine("CameraShaking");
            inShake = false;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }


    
    private IEnumerator CameraShaking()
    {
        inShake = true;
        transform.eulerAngles += new Vector3(.1f, 0, 0);
        yield return new WaitForSeconds(.1f);
        transform.eulerAngles -= new Vector3(.1f, 0, 0);
        yield return new WaitForSeconds(.1f);
        inShake = false;
    }
}
