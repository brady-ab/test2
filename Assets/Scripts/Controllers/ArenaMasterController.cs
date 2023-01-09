using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ArenaMasterController : MonoBehaviour
{


    public int ID;
    public string arenaMasterName;
    public int currentSeals;
    public int currentHealth;

    public GameObject background;
    public TMP_Text healthText;
    public TMP_Text sealsText;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Initialize(ArenaMaster arenaMaster, int ownerID)
    {
        ID = arenaMaster.ID;
        arenaMasterName = arenaMaster.arenaMasterName;
        currentSeals = arenaMaster.playerSeals;
        currentHealth = arenaMaster.playerHealth;

        /*
        this.arenaMaster = new ArenaMaster(arenaMaster) 
        { 
        };\
        **/

        healthText.text = currentHealth.ToString();
        sealsText.text = currentSeals.ToString();
            
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
