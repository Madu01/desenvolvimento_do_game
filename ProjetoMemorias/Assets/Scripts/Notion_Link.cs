using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notion_Link : MonoBehaviour{
    //Esse script atua para abrir o link externo que for passado como parâmetro
    public void AbreLink(string link){
        Application.OpenURL(link);
    }
}
