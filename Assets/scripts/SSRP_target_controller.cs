using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSRP_target_controller : MonoBehaviour {
    PersistantManager boss;// = PersistantManager.Instance;

    // when the Sensor is within Marker distances (within 15m)
    // we allow the the sensorManager to swap over from using icons as visual tracking to an actual marker.
    // we spawn in the market using this. Prefab with the specific Marker ID given to us from the sensor data itself.
    // we can compar this to the Marker DB and generate the expected marker to track.
    // This also provides and anchor point for adding the Sensor Information.

    public GameObject infoPrefab;
    public GameObject MarkerPrefab;
    private List<MVC_entity> prefabList;

    bool isMarkerTractedAndActive = false;
    bool hasPrefabs = false;

    

    // Use this for initialization
    void Start () {
        boss = PersistantManager.Instance;
        prefabList = new List<MVC_entity> { new MVC_entity(infoPrefab) };
        //prefabList.Add(new MVC_entity(MarkerPrefab));
        hasPrefabs = boss.prefabCheck(prefabList);
        if (hasPrefabs)
        { 
            boss.hud.addText("SSRP Target Controller - hasPrefabs: " + hasPrefabs);
        }
    }
	
    public void initFor(string marker_id)
    {

        // access Vuforia;

    }
	// Update is called once per frame
	void Update () {
		
	}
}
