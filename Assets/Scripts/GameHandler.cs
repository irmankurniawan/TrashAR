using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameHandler : MonoBehaviour, ITrackableEventHandler {

    public ImageScript imageScript;
    private TrackableBehaviour mTrackableBehaviour;
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
			// found
            Debug.LogWarning("Play game!");
            imageScript.OnGroundPlaced();
        }
        else {
			// lost
        }
    }	
}
