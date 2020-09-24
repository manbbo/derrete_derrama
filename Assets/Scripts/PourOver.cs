using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourOver : MonoBehaviour
{
    public bool canPour;
    // Checa se pode por o "liquido" ou não

    void Start()
    {
        canPour = false; //começa como nao
    }

    private void OnMouseDown()
    {
        //se clicar na tabua, ele poe
        canPour = true;
    }

    private void OnMouseUp()
    {
        //se parar de clicar na tabua, ele para de por
        canPour = false;
    }
}
