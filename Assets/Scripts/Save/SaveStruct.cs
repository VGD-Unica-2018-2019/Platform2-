using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveStruct
{
    [System.Serializable]
    public struct Triplet
    {
        public int health;
        public string name;
        public Vector3 position;
    };
    //Info del player
    public int scene;
    public Vector3 playerPosition;
    public int playerHp;
    //Info enemy
    public List<Triplet> saveEnemy = new List<Triplet>();
    /*public List<int> listaHealth = new List<int>();
    public List<string> listaNames = new List<string>();
    public List<Vector3> listaPosNemici = new List<Vector3>();*/
}