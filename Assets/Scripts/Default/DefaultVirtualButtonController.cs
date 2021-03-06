﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DefaultVirtualButtonController : MonoBehaviour, IVirtualButtonEventHandler
{
    void Start()
    {
        // Gera uma lista dos filhos que são botões virtuais
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; i++)
        {
            //Registra os botões para que eventos possam ser acionados
            vbs[i].RegisterEventHandler(this);
        }
    }

    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        //Desativa "Botão" (GameObject) filho do container do botão virtual se ele for o primeiro filho
        //Transform button = transform.Find(vb.transform.gameObject.name).transform;
        transform.Find(vb.transform.gameObject.name).Find("Botao").gameObject.SetActive(false);
        ButtonPressed();
    }
    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
        ButtonReleased();
        //Ativa "Botão" (GameObject) filho do container do botão virtual se ele for o primeiro filho
        transform.Find(vb.transform.gameObject.name).Find("Botao").gameObject.SetActive(true);
    }

    virtual protected void ButtonPressed() { }
    virtual protected void ButtonReleased() { }
}
