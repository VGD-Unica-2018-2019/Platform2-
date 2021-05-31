using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    private bool condition = true;
    void Start (){
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if(condition){
           if(Input.GetKeyDown(KeyCode.Backspace)){
            condition = false;
            StartCoroutine("load");
            Debug.Log("loading");
            //condition si comporta in modo strano
        }  
        } 
    }
    IEnumerator load(){
        SaveStruct output = JsonUtility.FromJson<SaveStruct>(File.ReadAllText(Application.persistentDataPath + "/savefile.json"));
        SceneManager.LoadScene("Blank");
        while (!SceneManager.GetActiveScene().name.Equals("Blank"))
        {
            yield return 1;
        }
        Debug.Log("qua");
        if(output!=null  ){
            SceneManager.LoadScene(output.scene,LoadSceneMode.Single);
            while (SceneManager.GetActiveScene().buildIndex != output.scene)
            {
                yield return null;
                yield return 1;
            }
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(Application.persistentDataPath);
        CharacterStatistics save = player.GetComponent<CharacterStatistics>();
        save.hp = output.playerHp;
        player.GetComponent<GameCharacterHealthBarController>().setHealth(output.playerHp);
        CharacterController cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.transform.position=output.playerPosition;
        cc.enabled = true;
        loadInfoEn(output);
        yield return new WaitForSeconds(2);
    }
    private void loadInfoEn(SaveStruct referenceStructure){
        int i=0;
        int counteEntity = 0;
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject items in go){
            int indexSave = referenceStructure.saveEnemy.FindIndex(x => x.name == items.name);
            if(indexSave>=0){
                items.transform.position = referenceStructure.saveEnemy[indexSave].position;
                CharacterStatistics save = items.GetComponent<CharacterStatistics>();
                save.hp = referenceStructure.saveEnemy[indexSave].health;
                save.GetComponent<GameCharacterHealthBarController>().setHealth(referenceStructure.saveEnemy[indexSave].health);
                Debug.Log(items.name);
                referenceStructure.saveEnemy.RemoveAt(indexSave);
            }else{
               Destroy(items);
            }
        }
    }
}
