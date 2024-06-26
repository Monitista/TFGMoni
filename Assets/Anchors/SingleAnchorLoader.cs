using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAnchorLoader : MonoBehaviour
{

    [SerializeField]
    OVRSpatialAnchor _anchorPrefab;

    Action<OVRSpatialAnchor.UnboundAnchor, bool> _onLoadAnchor;

    public string PlayerPrefName;

    private void Awake()
    {
        _onLoadAnchor = OnLocalized;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefName == "")
            PlayerPrefName = transform.name;
        LoadAnchorsByUuid();
    }

  
    public void LoadAnchorsByUuid()
    {
        
        var uuids = new Guid[1];      
        var currentUuid = PlayerPrefs.GetString(PlayerPrefName);          

        Debug.Log(currentUuid);
        uuids[0] = new Guid(currentUuid);

        Load(new OVRSpatialAnchor.LoadOptions
        {
            Timeout = 0,
            StorageLocation = OVRSpace.StorageLocation.Local,
            Uuids = uuids
        });

    }

    private void Load(OVRSpatialAnchor.LoadOptions options) => OVRSpatialAnchor.LoadUnboundAnchors(options, anchors =>
    {
        if (anchors == null)
        {
            Debug.Log("Query failed.");
            return;
        }

        foreach (var anchor in anchors)
        {
            if (anchor.Localized)
            {
                _onLoadAnchor(anchor, true);
            }
            else if (!anchor.Localizing)
            {
                anchor.Localize(_onLoadAnchor);
            }
        }
    });

    private void OnLocalized(OVRSpatialAnchor.UnboundAnchor unboundAnchor, bool success)
    {
        if (!success)
        {
            Debug.Log("not local");
            return;
        }

        Debug.Log("local");
        var pose = unboundAnchor.Pose;
        

        var spatialAnchor = Instantiate(_anchorPrefab, pose.position, pose.rotation);

        unboundAnchor.BindTo(spatialAnchor);

        transform.position = spatialAnchor.transform.position;
        transform.rotation = spatialAnchor.transform.rotation;

       

    }

    private static void Log(string message) => Debug.Log($"[SpatialAnchorsUnity]: {message}");
}
