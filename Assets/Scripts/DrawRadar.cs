using UnityEngine;
using System.Collections;

// Stolen from https://stackoverflow.com/questions/13708395/how-can-i-draw-a-circle-in-unity3d
public class DrawRadar : MonoBehaviour
{
    public float ThetaScale = 0.01f;
    public float radius = 3f;
    private int Size;
    private LineRenderer LineDrawer;
    private float Theta = 0f;
    public float height = 0f;
    public bool autoDraw = false;

    void Start()
    {
        LineDrawer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (autoDraw) {
            Draw();
        }
    }

    public void Draw()
    {
        Theta = 0f;
        Size = (int)((1f / ThetaScale) + 1f);
        LineDrawer.positionCount = Size;
        for (int i = 0; i < Size; i++)
        {
            Theta += (2.0f * Mathf.PI * ThetaScale);
            float x = radius * Mathf.Cos(Theta);
            float z = radius * Mathf.Sin(Theta);
            LineDrawer.SetPosition(i, transform.position + new Vector3(x, height, z));
        }
    }
}