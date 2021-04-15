using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notion_Link : MonoBehaviour{
    //Esse script atua para abrir o link externo que for passado como parâmetro
    public void AbreLink(){
        Application.OpenURL("https://www.notion.so/Refer-ncias-d385869ec3dc42d5a296323fcda7381c");
    }
}
