using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{
    public List<GameObject[]> liquidBalls; //pega os objetos que crio de liquidos com esse codigo (pra cada uma, criar um objeto que dá esses valores

    public int value; //pega o valor da scrollbar

    void Start()
    {
        liquidBalls = new List<GameObject[]>(); // inicia a lista de objetos
    }

    // Update is called once per frame
    void Update()
    {
        value = (int)(this.GetComponent<Scrollbar>().value * 10);
        manageTime(value); //pega o valor da scrollbar
    }


    public void manageTime(int value)
    {
        passTime(value); reverseTime(value);
    }

    void passTime(int value)
    {
        if (liquidBalls.Count < value) //verifica se a contagem é menor que o valor vezes 10
        {
            List<GameObject> gameObjects = new List<GameObject>();
            foreach (var g in GameObject.FindGameObjectsWithTag("MainLiquid"))
            {
                //GameObject gameObject = Instantiate(g, g.transform.localPosition - new Vector3(-0.5f, -0.5f, 8.28f), g.transform.rotation);
                GameObject gameObject = Instantiate(g, g.transform.localPosition, g.transform.rotation);
                gameObject.tag = "Untagged";
                gameObject.SetActive(true);
                gameObjects.Add(gameObject);
            }
            liquidBalls.Add(gameObjects.ToArray());
        }
    }

    void reverseTime(int value)
    {
        if (liquidBalls.Count >
            value && liquidBalls.Count > 0)//verifica se a contagem é maior que o valor vezes 10
        {
            GameObject[] gameObjects = liquidBalls[value];
            foreach (var g in gameObjects)
            {
                Destroy(g);
            }
            liquidBalls.RemoveAt(liquidBalls.Count - 1);
        }
    }
}
