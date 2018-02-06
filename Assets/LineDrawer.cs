using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {

    public Color lineColor;
    static Material lineMaterial;

    void Awake()
    {
        CreateLineMaterial();
    }

    // It is executed when camera finished current scene rendering
    void OnPostRender()
    {
        Draw();
    }

    // To show the lines in the editor
    void OnDrawGizmos()
    {
        Draw();
    }

    private void Draw()
    {
        foreach (List<Vector2> line in MousePointCapturer.lines)
        {
            for (int i = 0; i < line.Count - 1; i++)
            {
                GL.PushMatrix();

                lineMaterial.SetPass(0);
                GL.Begin(GL.LINES);
                GL.Color(lineColor);
                GL.Vertex(line[i]);
                GL.Vertex(line[i + 1]);
                GL.End();

                GL.PopMatrix();
            }
        }
    }    

    // Create line material with Unity built-in shader
    // It enables lines' transparency and makes lines 'flat'
    static void CreateLineMaterial()
    {
        if (lineMaterial)
        {
            return;
        }

        Shader shader = Shader.Find("Hidden/Internal-Colored");
        lineMaterial = new Material(shader);
        lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        lineMaterial.SetInt("_ZWrite", 0);
    }
}
