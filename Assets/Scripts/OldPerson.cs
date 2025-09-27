using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OldEyes
{
    NEUTRAL,
    GLASSES,
}
public enum OldHairType
{
    NONE,
    HAIR1,
    HAIR2,
    HAIR3,
}
public enum OldHead
{
    HEAD1,
    HEAD2,
    HEAD3,
    HEAD4,
}
public enum OldMouth
{
    MEH,
    SHOUTING,
    SMILING,
}
public enum OldAttachment
{
    NONE,
    CANE,
    WALKER,
}

public class OldPerson : MonoBehaviour
{
    public Color BodyColor;
    public OldEyes Eyes;
    public OldHairType HairType;
    public Color HairColor;
    public OldHead Head;
    public OldMouth Mouth;
    public OldAttachment Attachment;

    public OldPerson(
        Color bodyColor,
        OldEyes eyes,
        OldHairType hairType,
        Color hairColor,
        OldHead head,
        OldMouth mouth,
        OldAttachment attachment)
    {
        BodyColor = bodyColor;
        Eyes = eyes;
        HairType = hairType;
        HairColor = hairColor;
        Head = head;
        Mouth = mouth;
        Attachment = attachment;
    }

    public SpriteRenderer BodySprite;
    public SpriteRenderer EyesSprite;
    public SpriteRenderer HairSprite;
    public SpriteRenderer HeadSprite;
    public SpriteRenderer MouthSprite;
    public SpriteRenderer ArmSprite;
    public SpriteRenderer AttachmentSprite;

    void Start()
    {
        // Body
        BodySprite.sprite = Resources.Load<Sprite>("Images/Scene/oldPerson/body");
        BodySprite.color = BodyColor;

        // Eyes
        EyesSprite.sprite = Eyes switch
        {
            OldEyes.GLASSES => Resources.Load<Sprite>("Images/Scene/oldPerson/head/eyes/eyesGlasses") as Sprite,
            _ => Resources.Load<Sprite>("Images/Scene/oldPerson/head/eyes/eyesNeutral") as Sprite,
        };

        // Hair
        HairSprite.sprite = HairType switch
        {
            OldHairType.HAIR1 => Resources.Load<Sprite>("Images/Scene/oldPerson/head/hair/hair1") as Sprite,
            OldHairType.HAIR2 => Resources.Load<Sprite>("Images/Scene/oldPerson/head/hair/hair2") as Sprite,
            OldHairType.HAIR3 => Resources.Load<Sprite>("Images/Scene/oldPerson/head/hair/hair3") as Sprite,
            _ => null,
        };
        HairSprite.color = HairColor;

        // Head
        HeadSprite.sprite = Head switch
        {
            OldHead.HEAD2 => Resources.Load<Sprite>("Images/Scene/oldPerson/head/Head/head2") as Sprite,
            OldHead.HEAD3 => Resources.Load<Sprite>("Images/Scene/oldPerson/head/Head/head3") as Sprite,
            OldHead.HEAD4 => Resources.Load<Sprite>("Images/Scene/oldPerson/head/Head/head4") as Sprite,
            _ => Resources.Load<Sprite>("Images/Scene/oldPerson/head/Head/head1") as Sprite,
        };

        // Mouth
        MouthSprite.sprite = Mouth switch
        {
            OldMouth.SHOUTING => Resources.Load<Sprite>("Images/Scene/oldPerson/head/mouth/mouthShout") as Sprite,
            OldMouth.SMILING=> Resources.Load<Sprite>("Images/Scene/oldPerson/head/mouth/mouthSmile") as Sprite,
            _ => Resources.Load<Sprite>("Images/Scene/oldPerson/head/mouth/mouthMeh") as Sprite,
        };

        // Arm + Attachment
        if (Attachment == OldAttachment.CANE)
        {
            ArmSprite.sprite = Resources.Load<Sprite>("Images/Scene/oldPerson/cane/caneArm") as Sprite;
            AttachmentSprite.sprite = Resources.Load<Sprite>("Images/Scene/oldPerson/cane/cane") as Sprite;
        }
        else if (Attachment == OldAttachment.WALKER)
        {
            ArmSprite.sprite = Resources.Load<Sprite>("Images/Scene/oldPerson/walker/walkerArm") as Sprite;
            AttachmentSprite.sprite = Resources.Load<Sprite>("Images/Scene/oldPerson/walker/walker") as Sprite;
        }
        else
        {
            ArmSprite.sprite = null;
            AttachmentSprite.sprite = null;
        }
    }
}
