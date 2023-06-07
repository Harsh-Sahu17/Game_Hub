using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Dino_Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        float speed = Dino_GameManager.Instance.gameSpeed/50;// transform.localScale.x;
        meshRenderer.material.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
    }

}
