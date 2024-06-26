using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.UIElements;
using UnityEngine.Windows;

public class GrabAnchor : MonoBehaviour
{

    HandGrabInteractable grabbable;

    public string PrefsName;

    public OVRSpatialAnchor SpatialAnchorPrefab;

    private OVRSpatialAnchor _spatialAnchor;

    private Vector3 _position;
    private Quaternion _rotation;
    private bool _grabbing;

    private float _scale;
    private Vector3 _orgScale;

    private float _scaleInput;

    private void Awake()
    {
        _orgScale = transform.localScale;
        _scale = 1;
    }
    void OnEnable()
    {
        grabbable = GetComponentInChildren<HandGrabInteractable>();
        grabbable.WhenStateChanged += OnStateChange;
    }

    private void Start()
    {
       _position = transform.position;
        _rotation = transform.rotation;
        if (PrefsName == "")
            PrefsName = transform.name;
    }

    private void OnStateChange(InteractableStateChangeArgs args)
    {
        if (args.NewState == InteractableState.Select)
            OnGrab();

        if (args.PreviousState== InteractableState.Select && args.NewState != InteractableState.Select)
            OnRelease();
    }

    // Update is called once per frame
    void Update()
    {
       

      

    }

    private void LateUpdate()
    {
        var euler = transform.eulerAngles;
        euler.x = 0;
        euler.z = 0;
        transform.eulerAngles = euler;
    }



    void OnGrab()
    {
        _grabbing = true;
        //GetComponent<Renderer>().material.color = Color.red;
        Erease();
    }

    void OnRelease()
    {
        _grabbing = false;
        // GetComponent<Renderer>().material.color = Color.white;

        StartCoroutine(SaveDelayed());
    }

    IEnumerator SaveDelayed()
    {
        yield return new WaitForSeconds(0.5f);
        _spatialAnchor = Instantiate(SpatialAnchorPrefab, transform.position, transform.rotation);
        while (!_spatialAnchor.Localized)
        {
            yield return null;

        }
        SavePosition();
        SaveScale();
    }

  

    void Erease()
    {
        if (_spatialAnchor == null)
            return;

        _spatialAnchor.Erase((erasedAnchor, success) =>
        {
            if (success)
            {
                Debug.Log("Erased");
            }
        });
        Destroy(_spatialAnchor.gameObject);
    }

    void SavePosition()
    {
        
        if (!_spatialAnchor) return;

        _spatialAnchor.Save((_spatialAnchor, success) =>
        {
            if (!success) return;

            SaveUuidToPlayerPrefs(_spatialAnchor.Uuid);
        });
    }

    void SaveUuidToPlayerPrefs(Guid uuid)
    {
        Debug.Log(" save " + uuid.ToString());
        PlayerPrefs.SetString(PrefsName, uuid.ToString());
       
    }

    private void SaveScale()
    {
        PlayerPrefs.SetFloat(PrefsName+"_scale", _scale);
    }

   
}
