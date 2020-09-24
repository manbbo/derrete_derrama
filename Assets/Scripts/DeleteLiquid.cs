using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLiquid : MonoBehaviour
{
    void Update()
    {
        if (this.transform.localPosition.y < -2)
        {
            // se a posição do liquido for menor que -2, ele deleta o objeto
            Destroy(this.gameObject);
        }
    }
}
