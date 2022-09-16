using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivetrigger : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject triggerDoor; // 13 Vari�vel dos telhados
    public GameObject roof; // 13 Vari�vel dos telhados
    public GameObject props; // 13 Vari�vel dos itens das constru��es


    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------


    void Start()
    {
        roof.SetActive(true); //13 Inicia o game com os telhados ativados
        props.SetActive(false); //13 Inicia o game com os itens das contru��es desativados
        triggerDoor.SetActive(false); //13 Inicia o game com os telhados ativados

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter(Collider other) // 13 Ir� ativar o gatilho ao tocar o colisor, desativando o telhado e ativando os props
    {
        if (other.CompareTag("Player"))
        {
            triggerDoor.SetActive(true);
            
        }
    }
    private void OnTriggerExit(Collider other) // 13 Aqui ir� restaur� a configura��o padr�o ao sair do colisor
    {
        if (other.CompareTag("Player"))
        {
            triggerDoor.SetActive(true);

        }
    }





}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
