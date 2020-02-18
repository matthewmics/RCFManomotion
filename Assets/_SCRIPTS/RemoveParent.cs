using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour
{

    private Transform parentTransform;
    private Vector3 initialPosition;
    private Quaternion initalRotation;
    private string rop;
    // Use this for initialization
    void Start()
    {
        parentTransform = transform.parent;
        initialPosition =
            new Vector3(transform.localPosition.x,
            transform.localPosition.y, transform.localPosition.z);

        initalRotation = Quaternion.Euler(transform.localEulerAngles.x, 
            transform.localEulerAngles.y, 
            transform.localEulerAngles.z);
        transform.parent = null;

        rop = PlayerPrefs.GetString("reposition_objects");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ResetTrnsform();
        }

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode) && kcode.ToString().Equals(rop))
            {
                ResetTrnsform();
            }
        }
    }

    void ResetTrnsform()
    {

        transform.parent = parentTransform;
        transform.localPosition = initialPosition;
        transform.localRotation = initalRotation;
        transform.parent = null;
    }
}
