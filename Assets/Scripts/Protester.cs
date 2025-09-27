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

[ExecuteInEditMode]
public class Protester : MonoBehaviour
{
    [SerializeField] private Body Body;
    [SerializeField] private Color BodyColor;
    [SerializeField] private Eyes Eyes;
    [SerializeField] private HairType HairType;
    [SerializeField] private Color HairColor;
    [SerializeField] private Head Head;
    [SerializeField] private Mouth Mouth;
    [SerializeField] private Attachment Attachment;

    [SerializeField] private ChildHairType ChildHairType;
    [SerializeField] private Color ChildHairColor = Color.black;
    [SerializeField] private ChildHead ChildHead;

    [SerializeField] private SpriteRenderer BodySprite;
    [SerializeField] private SpriteRenderer EyesSprite;
    [SerializeField] private SpriteRenderer HairSprite;
    [SerializeField] private SpriteRenderer HeadSprite;
    [SerializeField] private SpriteRenderer MouthSprite;
    [SerializeField] private SpriteRenderer ArmSprite;
    [SerializeField] private SpriteRenderer AttachmentSprite;

    [SerializeField] private SpriteRenderer ChildHairSprite;
    [SerializeField] private SpriteRenderer ChildHeadSprite;
    [SerializeField] private SpriteRenderer ChildFaceSprite;

    [SerializeField] private string sortingLayerName;

    void Update()
    {
        // Body
        BodySprite.sprite = Body switch
        {
            Body.SLIM => Resources.Load<Sprite>("Images/Protester/body/bodySlim") as Sprite,
            _ => Resources.Load<Sprite>("Images/Protester/body/body") as Sprite,
        };
        BodySprite.color = BodyColor;
        BodySprite.sortingLayerName = sortingLayerName;
        // Eyes
        EyesSprite.sprite = Eyes switch
        {
            Eyes.ANGRY => Resources.Load<Sprite>("Images/Protester/head/eyes/eyesAngry") as Sprite,
            _ => Resources.Load<Sprite>("Images/Protester/head/eyes/eyes1") as Sprite,
        };
        EyesSprite.sortingLayerName = sortingLayerName;
        // Hair
        HairSprite.sprite = HairType switch
        {
            HairType.HAIR1 => Resources.Load<Sprite>("Images/Protester/head/hair/hair1") as Sprite,
            HairType.HAIR2 => Resources.Load<Sprite>("Images/Protester/head/hair/hair2") as Sprite,
            HairType.HAIR3 => Resources.Load<Sprite>("Images/Protester/head/hair/hair3") as Sprite,
            HairType.HAIR4 => Resources.Load<Sprite>("Images/Protester/head/hair/hair4") as Sprite,
            HairType.HAIR5 => Resources.Load<Sprite>("Images/Protester/head/hair/hair5") as Sprite,
            HairType.HAIR6 => Resources.Load<Sprite>("Images/Protester/head/hair/hair6") as Sprite,
            HairType.HAIR7 => Resources.Load<Sprite>("Images/Protester/head/hair/hair7") as Sprite,
            HairType.HAIR8 => Resources.Load<Sprite>("Images/Protester/head/hair/hair8") as Sprite,
            HairType.HAIR9 => Resources.Load<Sprite>("Images/Protester/head/hair/hair9") as Sprite,
            HairType.HAIR10 => Resources.Load<Sprite>("Images/Protester/head/hair/hair10") as Sprite,
            HairType.HAIR11 => Resources.Load<Sprite>("Images/Protester/head/hair/hair11") as Sprite,
            _ => null,
        };
        HairSprite.color = HairColor;
        HairSprite.sortingLayerName = sortingLayerName;

        // Head
        HeadSprite.sprite = Head switch
        {
            Head.HEAD2 => Resources.Load<Sprite>("Images/Protester/head/Head/head2") as Sprite,
            Head.HEAD3 => Resources.Load<Sprite>("Images/Protester/head/Head/head3") as Sprite,
            Head.HEAD4 => Resources.Load<Sprite>("Images/Protester/head/Head/head4") as Sprite,
            _ => Resources.Load<Sprite>("Images/Protester/head/Head/head1") as Sprite,
        };
        HeadSprite.sortingLayerName = sortingLayerName;
        // Mouth
        MouthSprite.sprite = Mouth switch
        {
            Mouth.SHOUTING => Resources.Load<Sprite>("Images/Protester/head/mouth/mouthShouting") as Sprite,
            Mouth.SMILING=> Resources.Load<Sprite>("Images/Protester/head/mouth/mouthSmiling") as Sprite,
            _ => Resources.Load<Sprite>("Images/Protester/head/mouth/mouthNeutral") as Sprite,
        };
        MouthSprite.sortingLayerName = sortingLayerName;
        // Arm + Attachment
        if (Attachment == Attachment.SIGN)
        {
            ArmSprite.sprite = Resources.Load<Sprite>("Images/Protester/sign/signArm") as Sprite;
            ArmSprite.color = BodyColor;
            ArmSprite.sortingLayerName = sortingLayerName;
            AttachmentSprite.sprite = Resources.Load<Sprite>("Images/Protester/sign/sign") as Sprite;
            AttachmentSprite.sortingLayerName = sortingLayerName;
            ChildHairSprite.sprite = null;
            ChildHeadSprite.sprite = null;
            ChildFaceSprite.sprite = null;
        }
        else if (Attachment == Attachment.CHILD)
        {
            ArmSprite.sprite = Resources.Load<Sprite>("Images/Protester/Child/adultArm") as Sprite;
            ArmSprite.color = BodyColor;
            ArmSprite.sortingLayerName = sortingLayerName;
            AttachmentSprite.sprite = Resources.Load<Sprite>("Images/Protester/Child/body") as Sprite;
            AttachmentSprite.sortingLayerName = sortingLayerName;
            // Child Hair
            ChildHairSprite.sprite = ChildHairType switch
            {
                ChildHairType.HAIR1 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair1") as Sprite,
                ChildHairType.HAIR2 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair2") as Sprite,
                ChildHairType.HAIR3 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair3") as Sprite,
                ChildHairType.HAIR4 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair4") as Sprite,
                ChildHairType.HAIR5 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair5") as Sprite,
                ChildHairType.HAIR6 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair6") as Sprite,
                _ => Resources.Load<Sprite>("Images/Protester/Child/Childhead/hair/hair7") as Sprite
            };
            ChildHairSprite.color = ChildHairColor;
            ChildHairSprite.sortingLayerName = sortingLayerName;
            // Child Head
            ChildHeadSprite.sprite = ChildHead switch
            {
                ChildHead.HEAD2 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/head/head2") as Sprite,
                ChildHead.HEAD3 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/head/head3") as Sprite,
                ChildHead.HEAD4 => Resources.Load<Sprite>("Images/Protester/Child/Childhead/head/head4") as Sprite,
                _ => Resources.Load<Sprite>("Images/Protester/Child/Childhead/head/head1") as Sprite,
            };
            ChildHeadSprite.sortingLayerName = sortingLayerName;
            // Child Face
            ChildFaceSprite.sprite = Resources.Load<Sprite>("Images/Protester/Child/Childhead/face") as Sprite;
            ChildFaceSprite.sortingLayerName = sortingLayerName;
        }
        else
        {
            ArmSprite.sprite = null;
            AttachmentSprite.sprite = null;
            ChildHairSprite.sprite = null;
            ChildHeadSprite.sprite = null;
            ChildFaceSprite.sprite = null;
        }
    }
}
