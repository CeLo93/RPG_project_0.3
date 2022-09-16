using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------


    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    public void OnPointerEnter(PointerEventData eventData) // 8.2 Este c�digo evita que toda a fun��o MovePlayer() (Do script PlayerMove2) execute quando o menu estiver aberto (como ele � um button raycaster, ser� um evento), pois o canMove ir� funcionar, apenas, ao ser true. E, assim que o livro abrir, este evento ir� ativar este m�todo aqui e deixar� o canMove false, paralisando o movimento
    {
        if (Time.timeScale == 1)
        {
            PlayerMove2.canMove = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // 8.2 Ao concluir o evento, ele volta a ser true e o MovePlayer() funciona
    {
        if (Time.timeScale == 1)
        {
            PlayerMove2.canMove = true;
        }
    }
   

  




}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
