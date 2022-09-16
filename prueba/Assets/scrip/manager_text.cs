using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO; // para acceder a archivos dentro del computador
using System.Runtime.Serialization.Formatters.Binary;

public class manager_text : MonoBehaviour
{
    public Text gold_text;
    public Text bronze_text;
    public Text silver_text;
    public Text puntos_text;
    private float bronze, gold, silver, puntos;


    //gold
    public void suma_puntos_gold()
    {
        gold = gold + 1f;
    }
    public void muestra_moneda_gold() {
        gold_text.text = "gold = " + gold;
    }
    //bronze
    public void suma_puntos_bronze()
    {
        bronze = bronze + 1f;
    }
    public void muestra_moneda_bronze()
    {
        
        bronze_text.text = "bronze = " + bronze;
    }

    //silver
    public void suma_puntos_silver()
    {
        silver = silver + 1f;
    }
    public void muestra_moneda_silver()
    {
        silver_text.text = "silver = " + silver;
    }
    //zombie
    public void sumar_puntos() {
        puntos = puntos + 5f;
    }
    public void muestra_puntos()
    {
        puntos_text.text = "puntos =  " + puntos;
    }
    void Start()
    {
        bronze = 0;
        silver = 0;
        gold = 0;
        puntos = 0;
        Loadgame();
        
       
    }
    public void SaveGame() {
        var filePath = Application.persistentDataPath + "/save_2.dat";
        FileStream file;
        if (File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
            Debug.Log("save");
        }
        else {
            file = File.Create(filePath);   
        }
            


        game_data data = new game_data();
        data.puntaje = puntos;
        data.bronze = bronze;
        data.gold = gold;
        data.silver = silver;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public void Loadgame()
    {
        var filePath = Application.persistentDataPath + "/save_2.dat";
        FileStream file;
        if (File.Exists(filePath)) {

            file = File.OpenRead(filePath);
            //Debug.Log(Application.persistentDataPath); 
        }
        else {
              File.Create(filePath);
            //Debug.LogError("No se encontro archivo ");
            return;
        }
        
            BinaryFormatter bf = new BinaryFormatter();
            game_data data = (game_data)bf.Deserialize(file);
        
        
        
        //utiliza los datos guardados
        puntos = data.puntaje;
        bronze = data.bronze;
        silver = data.silver;
        gold = data.gold;
       // Debug.Log("son los puntos : "+puntos);
        file.Close();
        muestra_puntos();
        muestra_moneda_bronze();
        muestra_moneda_gold();
        muestra_moneda_silver();
    }
    // Update is called once per frame

}
