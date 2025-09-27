using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Body
{
    NEUTRAL,
    SLIM,
}
public enum Eyes
{
    NEUTRAL,
    ANGRY,
}
public enum HairType
{
    NONE,
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
public enum Head
{
    HEAD1,
    HEAD2,
    HEAD3,
    HEAD4,
}
public enum Mouth
{
    NEUTRAL,
    SHOUTING,
    SMILING,
}
public enum Attachment
{
    NONE,
    SIGN,
    CHILD,
}

public enum ChildHairType
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
public enum ChildHead
{
    NONE,
    HEAD1,
    HEAD2,
    HEAD3,
    HEAD4,
}

public class Protester : MonoBehaviour
{
    public Body Body;
    public Color BodyColor;
    public Eyes Eyes;
    public HairType HairType;
    public Color HairColor;
    public Head Head;
    public Mouth Mouth;
    public Attachment Attachment;

    public ChildHairType ChildHairType;
    public Color? ChildHairColor;
    public ChildHead ChildHead;

    public Protester(
        Body body,
        Color bodyColor,
        Eyes eyes,
        HairType hairType,
        Color hairColor,
        Head head,
        Mouth mouth,
        Attachment attachment,

        ChildHairType childHairType = ChildHairType.NONE,
        Color? childHairColor = null,
        ChildHead childHead = ChildHead.NONE)
    {
        Body = body;
        BodyColor = bodyColor;
        Eyes = eyes;
        HairType = hairType;
        HairColor = hairColor;
        Head = head;
        Mouth = mouth;
        Attachment = attachment;

        ChildHairType = childHairType;
        ChildHairColor = childHairColor;
        ChildHead = childHead;
    }

    public SpriteRenderer BodySprite = new SpriteRenderer();
    public SpriteRenderer EyesSprite = new SpriteRenderer();
    public SpriteRenderer HairSprite = new SpriteRenderer();
    public SpriteRenderer HeadSprite = new SpriteRenderer();
    public SpriteRenderer MouthSprite = new SpriteRenderer();
    public SpriteRenderer ArmSprite = new SpriteRenderer();
    public SpriteRenderer AttachmentSprite = new SpriteRenderer();

    public SpriteRenderer ChildHairSprite = new SpriteRenderer();
    public SpriteRenderer ChildHeadSprite = new SpriteRenderer();
    public SpriteRenderer ChildFaceSprite = new SpriteRenderer();

    void Start()
    {
        // Body
        BodySprite.sprite = Body switch
        {
            Body.SLIM => Resources.Load("Images/Protester/body/bodySlim") as Sprite,
            _ => Resources.Load("Images/Protester/body/body") as Sprite,
        };
        BodySprite.color = BodyColor;

        // Eyes
        BodySprite.sprite = Eyes switch
        {
            Eyes.ANGRY => Resources.Load("Images/Protester/head/eyes/eyesAngry") as Sprite,
            _ => Resources.Load("Images/Protester/head/eyes/eyes1") as Sprite,
        };

        // Hair
        HairSprite.sprite = HairType switch
        {
            HairType.HAIR1 => Resources.Load("Images/Protester/head/hair/hair1") as Sprite,
            HairType.HAIR2 => Resources.Load("Images/Protester/head/hair/hair2") as Sprite,
            HairType.HAIR3 => Resources.Load("Images/Protester/head/hair/hair3") as Sprite,
            HairType.HAIR4 => Resources.Load("Images/Protester/head/hair/hair4") as Sprite,
            HairType.HAIR5 => Resources.Load("Images/Protester/head/hair/hair5") as Sprite,
            HairType.HAIR6 => Resources.Load("Images/Protester/head/hair/hair6") as Sprite,
            HairType.HAIR7 => Resources.Load("Images/Protester/head/hair/hair7") as Sprite,
            HairType.HAIR8 => Resources.Load("Images/Protester/head/hair/hair8") as Sprite,
            HairType.HAIR9 => Resources.Load("Images/Protester/head/hair/hair9") as Sprite,
            HairType.HAIR10 => Resources.Load("Images/Protester/head/hair/hair10") as Sprite,
            HairType.HAIR11 => Resources.Load("Images/Protester/head/hair/hair11") as Sprite,
            _ => null,
        };
        HairSprite.color = HairColor;

        // Head
        HeadSprite.sprite = Head switch
        {
            Head.HEAD2 => Resources.Load("Images/Protester/head/Head/head2") as Sprite,
            Head.HEAD3 => Resources.Load("Images/Protester/head/Head/head3") as Sprite,
            Head.HEAD4 => Resources.Load("Images/Protester/head/Head/head4") as Sprite,
            _ => Resources.Load("Images/Protester/head/Head/head1") as Sprite,
        };

        // Mouth
        MouthSprite.sprite = Mouth switch
        {
            Mouth.SHOUTING => Resources.Load("Images/Protester/head/mouth/mouthShouting") as Sprite,
            Mouth.SMILING=> Resources.Load("Images/Protester/head/mouth/mouthSmiling") as Sprite,
            _ => Resources.Load("Images/Protester/head/mouth/mouthNeutral") as Sprite,
        };

        // Arm + Attachment
        if (Attachment == Attachment.SIGN)
        {
            ArmSprite.sprite = Resources.Load("Images/Protester/sign/signArm") as Sprite;
            AttachmentSprite.sprite = Resources.Load("Images/Protester/sign/sign") as Sprite;
        }
        else if (Attachment == Attachment.CHILD)
        {
            ArmSprite.sprite = Resources.Load("Images/Protester/Child/adultArm") as Sprite;
            AttachmentSprite.sprite = Resources.Load("Images/Protester/Child/body") as Sprite;

            // Child Hair
            ChildHairSprite.sprite = ChildHairType switch
            {
                ChildHairType.HAIR1 => Resources.Load("Images/Protester/Child/Childhead/hair/hair1") as Sprite,
                ChildHairType.HAIR2 => Resources.Load("Images/Protester/Child/Childhead/hair/hair2") as Sprite,
                ChildHairType.HAIR3 => Resources.Load("Images/Protester/Child/Childhead/hair/hair3") as Sprite,
                ChildHairType.HAIR4 => Resources.Load("Images/Protester/Child/Childhead/hair/hair4") as Sprite,
                ChildHairType.HAIR5 => Resources.Load("Images/Protester/Child/Childhead/hair/hair5") as Sprite,
                ChildHairType.HAIR6 => Resources.Load("Images/Protester/Child/Childhead/hair/hair6") as Sprite,
                ChildHairType.HAIR7 => Resources.Load("Images/Protester/Child/Childhead/hair/hair7") as Sprite,
                _ => null,
            };
            ChildHairSprite.color = (Color) ChildHairColor;

            // Child Head
            ChildHeadSprite.sprite = ChildHead switch
            {
                ChildHead.HEAD2 => Resources.Load("Images/Protester/Child/Childhead/head/head2") as Sprite,
                ChildHead.HEAD3 => Resources.Load("Images/Protester/Child/Childhead/head/head3") as Sprite,
                ChildHead.HEAD4 => Resources.Load("Images/Protester/Child/Childhead/head/head4") as Sprite,
                _ => Resources.Load("Images/Protester/Child/Childhead/head/head1") as Sprite,
            };

            // Child Face
            ChildFaceSprite.sprite = Resources.Load("Images/Protester/Child/Childhead/face") as Sprite;
        }
    }
}
