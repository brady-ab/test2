using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaMasterDatabase : MonoBehaviour
{

    public static List<ArenaMaster> arenaMasterList = new List<ArenaMaster>();


    private void Awake()
    {

        arenaMasterList.Add(new ArenaMaster(0, 0, 0, ""));
        arenaMasterList.Add(new ArenaMaster(1, 40, 0, "Deserter General"));
        arenaMasterList.Add(new ArenaMaster(2, 40, 0, "Captured Warmaster"));
        arenaMasterList.Add(new ArenaMaster(3, 30, 0, "Arcane Spirit"));
        arenaMasterList.Add(new ArenaMaster(4, 30, 0, "Imprisoned Shaman"));
        arenaMasterList.Add(new ArenaMaster(5, 40, 0, "Disgraced Competitor"));
        arenaMasterList.Add(new ArenaMaster(6, 40, 0, "Bog Dweller"));

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
