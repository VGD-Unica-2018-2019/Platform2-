using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider c){
         if(c.gameObject.name == "Protagonist"){
             SaveFun();
             Destroy(gameObject);
         }
         else{
            Debug.Log ("Something else triggered");
         }
    }

    void SaveFun(){
        SaveStruct savingStructure = new SaveStruct();
        savingStructure.scene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("scena "+ savingStructure.scene);
        GameObject playerSave =GameObject.Find("Protagonist");
        CharacterStatistics savePl;
        savePl = playerSave.GetComponent<GameCharacterController>().GetStatistics();
        savingStructure.playerHp= savePl.hp;
        savingStructure.playerPosition = GameObject.Find("Protagonist").transform.position;
        GameObject test = GameObject.FindGameObjectWithTag("Player");
        chargeInfoEn(savingStructure);
        //Uso le funzioni d'appoggio per caricare
        //Salvato persitentemente
        string json = JsonUtility.ToJson(savingStructure);
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("File json per ore: "+json);
        //Caricato da file persistente
        SaveStruct output = JsonUtility.FromJson<SaveStruct>(File.ReadAllText(Application.persistentDataPath + "/savefile.json"));
        //Debug.Log("Zona info prese da file");
        //Destroy(gameObject);
    }

    private void chargeInfoEn(SaveStruct referenceStructure){
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject items in go){
            SaveStruct.Triplet save = new SaveStruct.Triplet{health = items.GetComponent<EnemyStatistics>().hp,name = items.name,position = items.transform.position};
            referenceStructure.saveEnemy.Add(save);
            Debug.Log("VITA  NOME " + save.health + " " + save.name);
            /*
            referenceStructure.listaNames.Add(items.name);
            referenceStructure.listaHealth.Add(items.GetComponent<EnemyStatistics>().hp); 
            referenceStructure.listaPosNemici.Add(items.transform.position); 
            */
        }
        Debug.Log(referenceStructure.saveEnemy.Count);
    }
}
