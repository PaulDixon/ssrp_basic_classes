using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantManager : MonoBehaviour {

    public static PersistantManager Instance { get; private set; }

    
    bool hasPrefabs = false;
    bool hasHud = false;
    
    public GameObject hudView;
    public GameObject ssrpStatusView;
    public GameObject internetStatusView;
    public GameObject workingStatusView;

    private BinaryStateIcon _ssrpIcon;
    private BinaryStateIcon _connectIcon;
    private BinaryStateIcon _workingIcon;
    private SSRP_hud_controller _hud;

    private List<MVC_entity> prefabList;

    /*
       peopleToThank = new List<string>(new string[] {
       "[dev] Paul Dixon (paul.dixon@northkingdom)",
       "[LTU] LTU",
       "[SSRP] Sense Smart Region platform",
       "[icon] Rami McMin ( https://www.flaticon.com/authors/rami-mcmin )",
        "[icon] Eleonor Wang(https://www.flaticon.com/authors/eleonor-wang )",
        "[icon] https://www.flaticon.com/"
         });*/

    public bool prefabCheck(List<MVC_entity> prefabList)
    {

        foreach (MVC_entity entity in prefabList)
        {
            if (entity.go == null)
            {
               Debug.Log("Prefab not set");

                return false;
            }
            /*
            if (entity.scripts == null)
            {
                return false;
            }
            */
        }
        return true;
    }

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            init();
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public BinaryStateIcon connectIcon
    {
        get
        {
            return _connectIcon;
        }

       
    }
   

    public BinaryStateIcon ssrpIcon
    {
        get
        {
            return _ssrpIcon;
        }
        
    }

    public BinaryStateIcon workingIcon
    {
        get
        {
            return _workingIcon;
        }
        
    }

    public SSRP_hud_controller hud
    {
        get
        {
            return _hud;
        }
    }

    
    private void init()
    {
        


        hasHud = false;
        try
        {
            _hud = hudView.GetComponent<SSRP_hud_controller>();
            _ssrpIcon = ssrpStatusView.GetComponent<BinaryStateIcon>();
            _connectIcon = internetStatusView.GetComponent<BinaryStateIcon>();
            _workingIcon = workingStatusView.GetComponent<BinaryStateIcon>();
            hasHud = true;
            Debug.Log("Hud Found, debugging to commence there");
            hud.addText("HUD active");
        }
        catch
        {
            Debug.LogWarning("Hud and icons not found");
        }
            
       
        

            //hud.addText("[peopleToThank]");
            /*
            foreach (string person in peopleToThank)
            {
                hud.addText("Thanks to: ");
            }
            // */

        
    }

   

}
