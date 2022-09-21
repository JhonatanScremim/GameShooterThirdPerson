using StarterAssets;
using UnityEngine;

public class ThirdPersonShooter : MonoBehaviour
{
    public GameObject aimCamera;
    public float rotateSpeed = 15;
    public Transform debugTransform;

    [Header("Variavables Publics")]
    public float aimMaxDistance = 100;

    StarterAssetsInputs input;
    Camera mainCamera;
    ThirdPersonController tpc;

    void Start()
    {
        input = GetComponent<StarterAssetsInputs>();
        mainCamera = Camera.main;
        tpc = GetComponent<ThirdPersonController>();
    }

    void Update()
    {
        //Movimentação
        //Ativar camera de mira ao clicar com o botão do mouse
        aimCamera.SetActive(input.aim);

        //Ativar bool do controller para andar olhando para o centro com a mira ativada
        tpc.setRotateOnMove(!input.aim);

        if(input.aim)
        {
            //Fazer o personagem olhar para o centro ao ativar a mira
            var yawCamera = mainCamera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                                                Quaternion.Euler(0, yawCamera, 0),
                                                Time.deltaTime * rotateSpeed);
        }

        //Adicionar o raio para debug na distancia máxima do tiro
        //Pegar o centro da camera
        Vector3 aimPosition = Vector3.zero;
        Vector2 screenCenterPos = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = mainCamera.ScreenPointToRay(screenCenterPos);

        if(Physics.Raycast(ray, out RaycastHit hit, aimMaxDistance))
        {
            debugTransform.position = hit.point;
            aimPosition = hit.point;
        }
        else
        {
            debugTransform.position = (ray.origin + ray.direction) * aimMaxDistance;
            aimPosition = (ray.origin + ray.direction) * aimMaxDistance;
        }

    }
}
