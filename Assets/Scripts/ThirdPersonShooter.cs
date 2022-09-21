using StarterAssets;
using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject aimCamera;
    public float rotateSpeed = 15;
    StarterAssetsInputs input;
    Transform mainCamera;
    ThirdPersonController tpc;

    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        mainCamera = Camera.main.transform;
        tpc = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        //Ativar camera de mira ao clicar com o botão do mouse
        aimCamera.SetActive(input.aim);

        //Ativar bool do controller para andar olhando para o centro com a mira ativada
        tpc.setRotateOnMove(!input.aim);

        if(input.aim)
        {
            //Fazer o personagem olhar para o centro ao ativar a mira
            var yawCamera = mainCamera.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                Quaternion.Euler(0, yawCamera, 0),
                                                Time.deltaTime * rotateSpeed);
        }
    }
}
