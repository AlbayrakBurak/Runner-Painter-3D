using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureBrush : MonoBehaviour
{
    public Camera cam;
    public MeshRenderer meshRenderer;
    public Texture2D brush;
    public Vector2Int texturArea;
    Texture2D texture;
    void Start()
    {
        texture=new Texture2D(texturArea.x,texturArea.y,TextureFormat.ARGB32,false);
        meshRenderer.material.mainTexture=texture;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            RaycastHit hitInfo;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),out hitInfo)){
                Debug.Log(hitInfo.textureCoord);
                Paint(hitInfo.textureCoord);
            }
        }
    }

    private void Paint(Vector2 coordinate){
        coordinate.x*=texture.width;
        coordinate.y*=texture.height;
        Color32[] textureC32=texture.GetPixels32();
        Color32[] brushC32=brush.GetPixels32();


        Vector2Int halfBrush=new Vector2Int(brush.width/2, brush.height/2);

        for(int x=0; x<brush.width; x++)
        {
            int xPos=x-halfBrush.x+(int)coordinate.x;
            if(xPos<0 || xPos >=texture.width){
            continue;
            }
            for(int y=0; y<brush.height;y++)
            {
                int yPos=y-halfBrush.y+(int)coordinate.y;
                 if(yPos<0 || yPos >=texture.height){
            continue;
            }
                if(brushC32[x+(y*brush.width)].a>0f)
                {
                    int tPos=
                    xPos+(texture.width*yPos);                   
                    if(brushC32[x+(y*brush.width)].r<textureC32[tPos].r)
                    {
                        textureC32[tPos]=brushC32[x+(y*brush.width)];
                    }
                }
            }
        }
        texture.SetPixels32(textureC32);
        texture.Apply();

    }
    
}


