using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 9. inventario

public class InventoryItems : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------
    public GameObject inventoryMenu; //8
    public GameObject openBook; //8
    public GameObject closedBook; //8

    //===�CONES NO INVENT�RIO--v
    public Image[] emptySlots; //10 Acessando os espa�os dos �cones no invent�rio
    public Sprite[] icons; //10 Acessando as sprites dos �cones
    public Sprite emptyIcon; //10 comparando o �cone vazio para ver se possui sprite ou n�o para, assim, poder armazenar o �tem no slot vazio

    public static int newIcon = 0; //10
    public static bool iconUpdate = false; //10
    private int max; //10

    public static int redMushrooms = 0; //10.1 Ele lembrar�, sempre, esse valor de 0 para a vari�vel
    public static int purpleMushrooms = 0; //12.1 Ele lembrar�, sempre, esse valor de 0 para a vari�vel
    public static int brownMushrooms = 0; //12.1 Ele lembrar�, sempre, esse valor de 0 para a vari�vel
    public static int blueFlowers = 0; //10.1
    public static int redFlowers = 0;
    public static int roots = 0; //10.1
    public static int leafDew = 0; 
    public static int dragonEgg = 0; 
    public static int redPotion = 0; 
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;

    //===�CONES NO INVENT�RIO e suas vari�veis est�ticas--^

    /* EXPLICA��O DA L�GICA DA MENSAGEM DO INVENT�RIO:-------v 
     
        Irei adicionar os meus itens nas vari�veis est�ticas aqui. Ap�s isso, irei determin�-los como 0 no start, para sempre iniciarem como 0, pois preciso colet�-los
        para contar. Cada item adicionado a um slot da array icons, deve seguir este procedimento. Devo ficar atentto, pois o script HintMessage ir� definir a mensagem
        de acordo com o n�mero do slot da array atribu�do ao �tem l� na engine. Assim, eu adiciono o �cone ao slot da array, coloco a vari�vel aqui, seto a mensagem
        no HintMessage com o n�mero exato do �tem na array e a mensagem que quero passar.

        PEGANDO O ITEM:
        
        Devo adicionar o �tem, atribu�do a vari�vel aqui, como explicado acima, no Script Pickup. Apenas preciso manter o padr�o do c�digo do script Pickup e ir copiando
        para outros �tens que adicione. Eu posso fazer um m�todo para apenas mudar a vari�vel, sem ter que usar todo aquele c�digo repetido (vou mudar isso depois). Preciso
        adicionar a vari�vel booleana em Pickups, correspondente ao meu item, junto com o n�mero do captador dele da vari�vel correspondente ao array do InventoryItems. Depois
        atacho o script pickup ao objeto, a ser coletado na cena e correspondente ao meu �cone do menu, e marco a op��o booleana dele na engine.

        RESUMO -> Fa�o a vari�vel do item no InventoryItems, depois irei adicionar o �cone ma array na engine, fa�o a vari�vel no pickups e atacho o script no objeto correspondente
                  e depois s� preciso repetir os c�digos de mensagem em HintMessage e Pickups. Basicamente, qualquer item que eu v� adicionar, s� preciso repetir este processo feito
                  aqui, pois a base do c�digo j� est� pronta.
    */
    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    void Start()
    {
        //8 Inicia o game com o menu fechado---v //9
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        //8 Inicia o game com o menu fechado---^

        max = emptySlots.Length; //10 Vai come�ar o game a corresponder ao total de �cones vazios

        //=== Iniciando os itens do zero, sempre que eu os pegar v�o iniciar com 0---v
        redMushrooms = 0; //10.1
        purpleMushrooms = 0;
        brownMushrooms = 0;
        blueFlowers = 0; //10.1 sempre que iniciamos o game, o valor dos itens ser� 0
        redFlowers = 0;
        roots = 0; //10.1
        leafDew = 0;
        dragonEgg = 0;
        redPotion = 0;
        bluePotion = 0;
        greenPotion = 0;
        purplePotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;
        //=== Iniciando os itens do zero, sempre que eu os pegar v�o iniciar com 0---^

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    void Update()
    {
        if(iconUpdate == true) // 10 c�digo para mudar o icone do inventario ao pegar no mapa
        {
            for(int i = 0; i < max; i++)
            {
                if(emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon; //12 Vou passar a mensagem, do script dde mensagem, para o slot definito em i aqui
                }
            }

            StartCoroutine(Reset()); // 10

        }
        

    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------
    
    public void OpenMenu() // 8 Abre o menu e mostra o �cone do livro aberto
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        Time.timeScale = 0; // 8.1 Este comando congela (pausa o tempo) o tempo do jogo. Se fosse 1, seria normal (como na outra fun��o); Se fosse 2, seria 2x mais r�pido
    }
    public void CloseMenu() // 8 fecha o menu e mostra o �cone do livro fechado
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1; // 8.1 Este comando normaliza o game que foi pausado na fun��o anterior. 

    }

    private IEnumerator Reset() //10 Courotine esperando 1 segundo para executar
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;

    }


}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
