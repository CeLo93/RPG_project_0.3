using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    //====CURSOR--v
    public GameObject CursorObject; // 4. Referenciando o GO Cursor nesta vari�vel
    public Sprite CursorBasic; //4
    public Sprite CursorHand; //4
    public Image CursorImage; // 4 Referencia o componente imagem nesta vari�vel
    //====CURSOR--^

 

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    void Start()
    {
        Cursor.visible = false; // 4. Oculta o cursor do mouse

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    void Update()
    {

        CursorObject.transform.position = Input.mousePosition; // 4.0 Vai fazer o nosso GO Cursor (com a imagem do cursor) seguir o "ponteiro" do mouse, que est� oculto, aonde quer que ele v�.
        if (Input.GetMouseButton(1))
        {
            //=== 8.2 Mant�m o �one do mouse na seta, quando abrir o menu de invent�rio--v
            if (Time.timeScale == 0)
            {
                CursorImage.sprite = CursorBasic;
            }
            if (Time.timeScale != 0)
            {
                CursorImage.sprite = CursorHand; // 4.1 Se eu pressionar o Mouse 1 (direito), meu componente Image ir� mudar para a sprite referenciarda no CursorHand, pois eu referenciei o meu componente Image na vari�vel, aqui citada, Cursor Image
            }
            //=== 8.2 Mant�m o �one do mouse na seta, quando abrir o menu de invent�rio--^

        }

        if (Input.GetMouseButtonUp(1))
        {
            CursorImage.sprite = CursorBasic; // 4.1 Ao solotar o mouse, volta ao cursor original. Poderia ser usado um else tamb�m
        }
        



    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------







}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

