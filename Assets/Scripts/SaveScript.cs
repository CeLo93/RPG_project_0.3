using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public static int pchar = 0; // 6? qual o player escolhido no valor "p" da classe Choose
    public static string pname = "player"; // 6? nome player
    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------


    void Start()
    {
        DontDestroyOnLoad(this); // 6 pe?o para n?o destruir, este script, ao carregar o game e, asim, mant?-lo salvo durante o jogo


    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    /*void Update()
    {
        

    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------
    */




}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
