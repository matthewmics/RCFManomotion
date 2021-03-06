﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndMove : MonoBehaviour
{


    private GameObject ToolTip;

    // Use this for initialization
    void Start()
    {
        Transform t = transform.Find("TOOLTIP");
        if (t != null)
        {
            ToolTip = t.gameObject;
        }
        ShowToolTip(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    Color lastColor;



    void OnTriggerEnter(Collider trigCol)
    {
        if (!trigCol.CompareTag("Hand"))
        {
            return;
        }

        lastColor = gameObject.GetComponent<Renderer>().material.color;
        ShowToolTip(true);

        // trigCol.gameObject.GetComponent<Renderer>().material.color = Color.green;

    }

    void ShowToolTip(bool show)
    {
        if (ToolTip != null)
        {
            ToolTip.SetActive(show);
        }
    }

    void OnTriggerStay(Collider trigCol)
    {
        if (!trigCol.CompareTag("Hand"))
        {
            return;
        }
        TrackingInfo myTrackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;

        GestureInfo myGestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;

        grabMove(myTrackingInfo, myGestureInfo, trigCol);
            
    }

    void OnTriggerExit(Collider trigCol)
    {
        if (!trigCol.CompareTag("Hand"))
        {
            return;
        }
        gameObject.GetComponent<Renderer>().material.color = lastColor;
        ShowToolTip(false);
        // trigCol.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

    }

    void grabMove(TrackingInfo trackingInfo, GestureInfo gesture_info, Collider trigCol)
    {
        // checked if we have a closed hand
        if (gesture_info.state >= 10)
        {

            //Change the color of the object being held to green
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;

            // Get the position of the centre of hand
            Vector3 normalizedPalmCentre = trackingInfo.palm_center;
            float depth = trackingInfo.relative_depth;
            Vector3 relativePalmCentrePosition = ManoUtils.Instance.CalculateNewPosition(normalizedPalmCentre, depth);

            //Move the object with hand
            float smoothingVariable = 0.85f;
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, relativePalmCentrePosition, smoothingVariable);



        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;

        }



    }
}
