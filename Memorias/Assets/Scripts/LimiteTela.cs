using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteTela : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 Limite;
    private float LarguraObj;
    private float AlturaObj;

    // Use this for initialization
    void Start()
    {
        Limite = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
            MainCamera.transform.position.z));//recebe os limites x,y da main camera

        LarguraObj = transform.GetComponent<SpriteRenderer>().bounds.extents.x;//até qual largura a peca se extende
        AlturaObj = transform.GetComponent<SpriteRenderer>().bounds.extents.y;//até qual altura a peca se extende
    }

    // Update is called once per frame
    void LateUpdate()//atualizacao apos o movimento
    {
        Vector3 AlteraPos = transform.position;//transforma a posição atual da peca

        //Limite min e max que a peca pode atingir no eixo X e Y considerando as suas margens e não o centro do objeto, por isso a necessidade da LarguraObj e AlturaObj
        AlteraPos.x = Mathf.Clamp(AlteraPos.x, -Limite.x + (LarguraObj + 2400), Limite.x - LarguraObj);

        AlteraPos.y = Mathf.Clamp(AlteraPos.y, -Limite.y + (AlturaObj + 1450), Limite.y - AlturaObj);

        transform.position = AlteraPos;//posição é alterada
    }
}
