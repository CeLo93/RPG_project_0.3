using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 6.1 usar a interface da Unity, assim teremos acesso aos elementos do Canvas
using UnityEngine.SceneManagement; // 6.2 Poderei administrar a transi��o de cenas


public class Choose : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject[] characters; // 5
    private int p = 0; // 5
    public Text playerName; // 6.1 Vari�vel que aramazenar� o nome do player e jogar� para a classe saveScript, para ser salvo


    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------


    public void Next() // 5� Ativa o pr�ximo personagem e deixa desativado o anterior
    {
        if (p < characters.Length - 1)
        {
            characters[p].SetActive(false);
            p++;
            characters[p].SetActive(true);
        }




    }//-----------------------------------------------------------------------------------------------------------------^ Next() ^--------------------------------------------------------------------------------------------------------
    public void Back() // 5� Ativa o  personagem anterior e deixa desativado o pr�ximo
    {
        if (p > 0) // ou posso usar if (p <= characters.Length - 1 && p >= characters.Length - 5 )
        {
            characters[p].SetActive(false);
            p--;
            characters[p].SetActive(true);
        }
       




    }//-----------------------------------------------------------------------------------------------------------------^ Next() ^--------------------------------------------------------------------------------------------------------

    public void Accept() // 6.1 ir� salvar o nome e o personagem, assim que pressionar o bot�o accept.
    {
        SaveScript.pchar = p; // 6.1 Ir� passar o valor de "p", que �, na pr�tica, o meu personagem, para a vari�vel pchar, que ir� salvar esse valor.
        SaveScript.pname = playerName.text; // 6.1 Ir� salvar o nosso elemento de texto (nosso nome de personagem) para a vari�vel pname, da classe SaveScript.
        SceneManager.LoadScene(1); // 6.2 Ir� carregar a pr�xima cena, assim que eu clicar em Accept na tela

    }





}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------

