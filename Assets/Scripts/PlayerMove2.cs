using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
public class PlayerMove2 : MonoBehaviour
{
    #region---------------------------------------------------------------------------------------------------------v VARIAVEIS v--------------------------------------------------------------------------------------

    Vector3 target; // 1.
    Rigidbody rb; // 1.
    //private Ray ray; //1
    //private NavMeshAgent nav; // 1.
    //private RaycastHit hit; // 1.
    //private Vector3 pos; // 3 ser� a posi��o do mouse

    //====CAMERAROTATE-v*
    public Transform cameraP;
    //====CAMERAROTATE-^*

    //====CINEMACHINE--v (3)
    CinemachineTransposer ct; // 3. Vari�vel para acessar os componentes do Cinemachine na Unity.
    public CinemachineVirtualCamera playerCam; // 3. Acesso p�blico a c�mera, para que possamos arrastar objetos para ela.
   
    private Vector3 currPos; // 3. Achar a posi��o atual
    //====CINEMACHINE--^

    //====MENU--v
    public static bool canMove = true; // 8.2 [Script: CursorOver.cs]
    private Animator animator;
    [SerializeField] float velocidade = 5f;
    private Vector3 inputs;
    //====MENU--^

    private NavMeshAgent character;

    #endregion------------------------------------------------------------------------------------------------------^ VARIAVEIS ^-------------------------------------------------------------------------------------
    void Start()
    {
        //nav = GetComponent<NavMeshAgent>(); // 1. Atribuindo o Objeto, que possui o componente NavMeshAgent, � vari�vel "nav"
        rb = GetComponent<Rigidbody>(); // 1
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>(); // 3. Obtemos o componente de giro "CinemachineTransposer", que � o que quermos para girar a c�mera, e temos que citaro playerCam., pois ele ser� refer�nciado com nosso objeto a ser acessado o Cinemachine.
        currPos = ct.m_FollowOffset; // 3. Passar� os valores da c�mera, referente a posi��o do mouse atual, para a vari�vel.

        character = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // 2. Atribui o Animator do Objeto � vari�vel

    }//-----------------------------------------------------------------------------------------------------------------^ START ^--------------------------------------------------------------------------------------------------------


    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(Time.deltaTime * velocidade * inputs.normalized);
        character.Move(Vector3.down.normalized * Time.deltaTime);

        if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = Vector3.Slerp(transform.forward.normalized, inputs, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("andando", false);
        }

        
    }//-----------------------------------------------------------------------------------------------------------------^ UPDATE ^--------------------------------------------------------------------------------------------------------



    #region comentados----v
    /*private void MovePlayer() // 2�
    {
        if (canMove == true)
        {
            //====Movimenta��o com o WASD e Giro da c�mera do mouse--v
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 dir = new Vector3(h, 0, v).normalized;

            transform.Translate(dir * velocityC * Time.deltaTime);

            if (Input.GetMouseButton(1))
            {

                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                transform.Rotate(new Vector3(0, mouseX * rotationC * Time.deltaTime, 0));
                //transform.Rotate(new Vector3(mouseY * rotationC * Time.deltaTime, 0, 0));
                //transform.eulerAngles = new Vector3(mouseY, mouseX, 0);


            }

            //====Movimenta��o com o WASD e Giro da c�mera do mouse--^
            #region ======== ANIMA��ES DE MOVIEMENTO---v
            velH = h;
            velV = v;
            velHV = h + v;
            velHV2 = h - v;
            velHV3 = -h + v;
            velHV4 = -h - v;


            // ==== MOVIMENTACAO CIMA BAIXO
            if (velV > 0 && velH == 0) // 2.2 
            {
                anim.SetBool("sprinting", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
            }

            if (velV < 0 || velV == 0) // 2.2
            {
                anim.SetBool("sprinting", false);
            }
            if (velV < 0 && velH == 0) // 2.2 
            {
                anim.SetBool("sprintingback", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
            }

            if (velV > 0 || velV == 0) // 2.2
            {
                anim.SetBool("sprintingback", false);
            }

            // ==== MOVIMENTACAO ESQUERDA DIREITA


            if (velH > 0 && velV > 0) // 2.2 
            {
                anim.SetBool("sprintingright", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
                anim.SetBool("runbasicright", true);
                anim.SetBool("runfrontright", true);
            }
            if (velH == 0 || velV == 0)
            {
                anim.SetBool("sprintingright", false);
                anim.SetBool("runbasicright", false);
                anim.SetBool("runfrontright", false);
            }


            if (velH < 0 && velV > 0) // 2.2 
            {
                anim.SetBool("sprintingleft", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
                anim.SetBool("runbasicleft", true);
                anim.SetBool("runfrontleft", true);
            }

            if (velH == 0 || velV == 0)
            {
                anim.SetBool("sprintingleft", false);
                anim.SetBool("runbasicleft", false);
                anim.SetBool("runfrontleft", false);
            }


            if (velH < 0 && velV == 0) // 2.2 
            {
                anim.SetBool("basicleft", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
            }
            if (velH == 0 || velH > 0)
            {
                anim.SetBool("basicleft", false);
            }


            if (velH > 0 && velV == 0) // 2.2 
            {
                anim.SetBool("basicright", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
            }
            if (velH == 0 || velH < 0)
            {
                anim.SetBool("basicright", false);
            }

            if (velH > 0 && velV < 0) // 2.2 
            {
                anim.SetBool("runbackright", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
                anim.SetBool("strafebackright", true);
                anim.SetBool("backbackright", true);
            }
            if (velH == 0 || velV == 0)
            {
                anim.SetBool("runbackright", false);
                anim.SetBool("strafebackright", false);
                anim.SetBool("backbackright", false);
            }

            if (velH < 0 && velV < 0) // 2.2 
            {
                anim.SetBool("runbackleft", true); // 2.2 Caso a condi��o realize, este comando ir� ativar a nossa anima��o, condicionada no Animator com o a condi��o de nome sprinting
                anim.SetBool("strafebackleft", true);
                anim.SetBool("backbackleft", true);
            }
            if (velH == 0 || velV == 0)
            {
                anim.SetBool("runbackleft", false);
                anim.SetBool("strafebackleft", false);
                anim.SetBool("backbackleft", false);
            }

            #endregion ======== ANIMA��ES DE MOVIEMENTO---^*/


    /*//=====C�lculo-v
    x = nav.velocity.x;
    z = nav.velocity.z;
    velocitySpeed = x + z;
    //Explica��o---^: O c�lculo ir� atribuir o valor ao x, z e velocitySpeed da seguinte maneira, os valores do componente NavMeshAgent de velocidade ser�o atribuidos a vari�vel "x" no eixo X e na vari�vel "z" no Z,
    //o velocitySpeed � a soma dos dois, pois independente do valor, precisamos que ela seja diferente de 0 para acionr a anima��o. Como o personagem se movimenta em dire��es variadas entre os eixos X e Z, a soma ir�
    // sempre ser um valor diferente de zero.


    if (Input.GetMouseButtonDown(0))
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            nav.destination = hit.point;
        }
    }*/

    #endregion comentados----^
}//-----------------------------------------------------------------------------------------------------------------^^^ MonoBehaviour{} ^^^--------------------------------------------------------------------------------------------------------
