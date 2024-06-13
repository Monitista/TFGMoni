using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static OVRSpatialAnchor;

public class AllAnchorsReader : MonoBehaviour
{

    public static AllAnchorsReader Instance;
    SingleAnchorLoader[] singleAnchors;
    

    [SerializeField]
    OVRSpatialAnchor _anchorPrefab;

    Action<OVRSpatialAnchor.UnboundAnchor, bool> _onLoadAnchor;

    Dictionary<Guid, Transform> dictAnchors;

    public bool IsGame;
    // Start is called before the first frame update
    void Awake()
    {
        singleAnchors = GetComponentsInChildren<SingleAnchorLoader>();
        _onLoadAnchor = OnLocalized;
        Instance = this;
    }

   

    void Start()
    {
       
        LoadPlayerAnchorsByUuid();
       
        
    }


    public void LoadPlayerAnchorsByUuid()
    {

        var uuidsList = new List<Guid>();
        dictAnchors = new Dictionary<Guid, Transform>();
        for (int i = 0; i < singleAnchors.Length; i++)
        {
            var currentUuid = PlayerPrefs.GetString(singleAnchors[i].PlayerPrefName, "kk");
            Debug.Log(singleAnchors[i].PlayerPrefName + " / " + currentUuid);
            if (currentUuid != "kk" && singleAnchors[i].PlayerPrefName == "PlayerLookAt")
            {
                Guid uiid = new Guid(currentUuid);
                uuidsList.Add(uiid);

                dictAnchors.Add(uiid, singleAnchors[i].transform);
            }


        }
        var uuids = uuidsList.ToArray();

        Load(new OVRSpatialAnchor.LoadOptions
        {
            Timeout = 0,
            StorageLocation = OVRSpace.StorageLocation.Local,
            Uuids = uuids
        });

    }


    public void LoadAnchorsByUuid()
    {

        var uuidsList = new List<Guid>();
        dictAnchors = new Dictionary<Guid, Transform>();
        for (int i = 0; i < singleAnchors.Length; i++)
        {
            var currentUuid = PlayerPrefs.GetString(singleAnchors[i].PlayerPrefName,"kk");
            Debug.Log(singleAnchors[i].PlayerPrefName + " / " + currentUuid);
            if (currentUuid != "kk" && singleAnchors[i].PlayerPrefName!= "PlayerLookAt")
            {
                Guid uiid = new Guid(currentUuid);
                uuidsList.Add(uiid);
               
                dictAnchors.Add(uiid, singleAnchors[i].transform);
            }
            
           
        }
        var uuids = uuidsList.ToArray();

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
            Debug.Log("can not load " + unboundAnchor.Uuid);
            return;
        }

        var pose = unboundAnchor.Pose;

        
        var spatialAnchor = Instantiate(_anchorPrefab, pose.position, pose.rotation);

        unboundAnchor.BindTo(spatialAnchor);

        if (dictAnchors.ContainsKey(unboundAnchor.Uuid))
        {
            StartCoroutine(SetPosition(unboundAnchor.Uuid, spatialAnchor));

        }
        

    }

    IEnumerator SetPosition(Guid uuid, OVRSpatialAnchor anchor)
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        dictAnchors[uuid].position = anchor.transform.position;
        dictAnchors[uuid].rotation = anchor.transform.rotation;

        

    }

    private static void Log(string message) => Debug.Log($"[SpatialAnchorsUnity]: {message}");

}
