using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class botaoSalvar : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
             
    }

    // Update is called once per frame
    public void salvarJogo(int id_da_fase){
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO ultimo_save (id, tela_salva) VALUES ("+SQLite.id_do_save+", "+id_da_fase+")";
        cmnd.ExecuteNonQuery();

         //Fechando a conexão
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT * FROM ultimo_save";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while(reader.Read()){
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("última tela salva: " + reader[1].ToString());
        }
        SQLite.id_do_save = SQLite.id_do_save + 1;
        dbcon.Close();
          
    }

    public void limparTabela(){
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "DELETE FROM ultimo_save";
        cmnd.ExecuteNonQuery();

        IDbCommand cmnd2 = dbcon.CreateCommand();
        cmnd2.CommandText = "VACUUM";
        cmnd2.ExecuteNonQuery();

        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT * FROM ultimo_save";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while(reader.Read()){
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("última tela salva: " + reader[1].ToString());
        }

        dbcon.Close();
    }
}
