using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public GameObject materials;
    // pega os liquidos como objetos
    public GameObject[] otherBottles;
    // pega as outras bisnagas
    public float factor = 0.0f;
    //adiciona o fator X ao clique do mouse
    public PourOver pourOver;

    Vector3 firstPosition;
    // pega a primeira posição local
    bool canBeUsed;
    // pode ser usado? se sim, então ativa um metodo, senão nao ativa

    void Start()
    {
        canBeUsed = false;
        firstPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (pourOver.canPour && canBeUsed)
        {
            StartCoroutine("createMaterial");
            // começa a co rotina
        }

        playAnimation(); // iniciar a animação das particulas

        if (!canBeUsed && this.transform.localPosition != this.firstPosition)
        {
            this.transform.localPosition = this.firstPosition; //a posicao reseta
        } else if (canBeUsed) {
            if (Input.GetAxis("Fire1") > 0) //pressionar com o mouse
            {
                //ele assume a posição relativa do mouse
               this.transform.localPosition = 
                    new Vector3(-1.1f + ((Input.mousePosition.x / 110)-factor), 
                    this.firstPosition.y,
                    ((Input.mousePosition.y / 110)-factor));
            }
        }
    }

    private void playAnimation()
    {
        ParticleSystem particleSystem = this.GetComponentInChildren<ParticleSystem>();

        if (Input.GetMouseButton(0) && pourOver.canPour && canBeUsed)
        {
            if (particleSystem.isStopped)
            {
                particleSystem.Play();
            }
        } else {
            if (Time.frameCount % 2 == 0)
                particleSystem.Stop();
        }
    }

    private IEnumerator createMaterial()
    {
        // ele cria os materiais (liquidos) de 2 em 2 frames (1 segundo)
        while (Input.GetMouseButton(0) && Time.frameCount % 2 == 0)
        {
            var material = Instantiate(materials);
            material.transform.parent = this.transform; // ele coloca as bisnagas como parentes do criador de particula
            material.transform.localPosition = Vector3.zero; // coloca a posicao em ZERO

            material.transform.localScale = new Vector3(1, 1, 1); // mexe na escala pra ficar normal
            material.transform.parent = null; // retorna o parentesco para nenhum
            material.SetActive(true); // ativa o material

            yield return 0;
        }
    }

    private void OnMouseDown()
    {
        // Pega se o mouse foi clicado no objeto
        if (!canBeUsed)
        {
            canBeUsed = true;
            otherBottles[0].GetComponent<Bottle>().canBeUsed = false;
            otherBottles[1].GetComponent<Bottle>().canBeUsed = false;
        }
    }
}
