using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public int number; // 10. n�mero do captador, que ir� definir qual �cone ir� aparecer no menu do invent�rio, ao pegar o item no mapa

    public bool redMushroom = false; // 10.1
    public bool purpleMushroom = false; // 10.1
    public bool brownMushroom = false; // 10.1
    public bool redFlower = false; //10.1
    public bool blueFlower = false; //10.1

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------

  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Input.GetMouseButtonDown(0)) //10.2 Ao clicar, ele coleta o item
            {
                MostraItems();

            }
        }
    }

    void DisplayIcons() //10.1
    {
        //10== Far� o c�digo de adicionar o �cone do �tem, ao menu de invent�rio, executar antes de destru�-lo--v
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
        //10== Far� o c�digo de adicionar o �cone do �tem, ao menu de invent�rio, executar antes de destru�-lo--^
    }
    private void MostraItems()
    {
        if (redMushroom == true) //10.1 Este trecho ir� reconhecer quando o n�mero do item for igual a 1 (pois 0 seria 1 cogumelo aqui), ir� mostrar no invent�rio. Sempre que coletar mais que um, adiciona ele e o destr�i, a fim de n�o aparecer no menu a imagem repetida
        {
            if (InventoryItems.redMushrooms == 0)
            {
                DisplayIcons();
            }
            InventoryItems.redMushrooms++;
            Destroy(gameObject);
        }
        else if (brownMushroom == true) //10.1 Este trecho ir� reconhecer quando o n�mero do item for igual a 1 (pois 0 seria 1 cogumelo aqui), ir� mostrar no invent�rio. Sempre que coletar mais que um, adiciona ele e o destr�i, a fim de n�o aparecer no menu a imagem repetida
        {

            if (InventoryItems.brownMushrooms == 0)
            {
                DisplayIcons();
            }
            InventoryItems.brownMushrooms++;
            Destroy(gameObject);
        }
        else if (blueFlower == true) //10.1 Este trecho ir� reconhecer quando o n�mero do item for igual a 1 (pois 0 seria 1 cogumelo aqui), ir� mostrar no invent�rio. Sempre que coletar mais que um, adiciona ele e o destr�i, a fim de n�o aparecer no menu a imagem repetida
        {

            if (InventoryItems.blueFlowers == 0)
            {
                DisplayIcons();
            }
            InventoryItems.blueFlowers++;
            Destroy(gameObject);
        }
        else if (redFlower == true) //10.1 Este trecho ir� reconhecer quando o n�mero do item for igual a 1 (pois 0 seria 1 cogumelo aqui), ir� mostrar no invent�rio. Sempre que coletar mais que um, adiciona ele e o destr�i, a fim de n�o aparecer no menu a imagem repetida
        {

            if (InventoryItems.redFlowers == 0)
            {
                DisplayIcons();
            }
            InventoryItems.redFlowers++;
            Destroy(gameObject);
        }

        else //10.1 se n�o, apenas mostre o item e o destrua
        {
            DisplayIcons();
            Destroy(gameObject);
        }
    }

   
}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

