using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    ROUND,
    SLIM
}

public enum ClothingColor
{
    RED,
    GREEN,
    BLUE,
}

public enum Eyes
{
    NEUTRAL,
    ANGRY
}

public enum Hair
{
    HAIR1,
    HAIR2,
    HAIR3,
    HAIR4,
    HAIR5,
    HAIR6,
    HAIR7,
    HAIR8,
    HAIR9,
    HAIR10,
    HAIR11,
}

public enum HeadColor
{
    WHITE,
    BEIGE,
    LIGHT_BROWN,
    DARK_BROWN,
}

public enum Mouth
{
    NEUTRAL,
    SHOUTING,
    SMILING,
}

public enum Arm
{
    EMPTY,
    SIGN,
    CHILD,
}

public enum ChildHair
{
    NONE,
    HAIR1,
    HAIR2,
    HAIR3,
    HAIR4,
    HAIR5,
    HAIR6,
    HAIR7,
}
public enum ChildHeadColor
{
    NONE,
    WHITE,
    BEIGE,
    LIGHT_BROWN,
    DARK_BROWN,
}

public class Protester : MonoBehaviour
{
    public BodyType BodyType;
    public ClothingColor ClothingColor;
    public Eyes Eyes;
    public Hair Hair;
    public HeadColor HeadColor;
    public Mouth Mouth;
    public Arm Arm;
    public ChildHair ChildHair;
    public ChildHeadColor ChildHeadColor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetHead(Eyes eyes, Hair hair, Mouth mouth)
    {
        Eyes = eyes;
        Hair = hair;
        Mouth = mouth;
    }
}
