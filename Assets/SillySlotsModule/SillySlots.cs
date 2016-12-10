using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum SlotShape {
    BOMB, GRAPE, CHERRY, COIN
}
public enum SlotColor {
    RED, GREEN, BLUE
}
public struct Slot {
    public SlotShape shape;
    public SlotColor color;
    public float position;
    public Slot(SlotShape shape, SlotColor color, float position) {
        this.shape = shape;
        this.color = color;
        this.position = position;
    }
}
public static class Slots {
    public static Slot[] slots = new Slot[]{
        new Slot(SlotShape.GRAPE, SlotColor.BLUE, 7f),
        new Slot(SlotShape.CHERRY, SlotColor.RED, 39f),
        new Slot(SlotShape.BOMB, SlotColor.GREEN, 66f),
        new Slot(SlotShape.COIN, SlotColor.GREEN, 101f),
        new Slot(SlotShape.CHERRY, SlotColor.BLUE, 130f),
        new Slot(SlotShape.GRAPE, SlotColor.GREEN, 160f),
        new Slot(SlotShape.BOMB, SlotColor.RED, 190f),
        new Slot(SlotShape.COIN, SlotColor.BLUE, 220f),
        new Slot(SlotShape.CHERRY, SlotColor.GREEN, 250f),
        new Slot(SlotShape.GRAPE, SlotColor.RED, 280f),
        new Slot(SlotShape.BOMB, SlotColor.BLUE, 310f),
        new Slot(SlotShape.COIN, SlotColor.RED, 340f),
    };

    public static Slot Random() {
        return slots[UnityEngine.Random.Range(0, slots.Length)];
    }
        
    public static Dictionary<string, Dictionary<string, SlotColor>> slotColors;
    public static Dictionary<string, Dictionary<string, SlotShape>> slotShapes;

    public static void PopulateSubstitionTable()
    {
        if (slotColors != null && slotShapes != null) return;

        slotColors = new Dictionary<string, Dictionary<string, SlotColor>>();
        slotShapes = new Dictionary<string, Dictionary<string, SlotShape>>();

        var sassyColors = new Dictionary<string, SlotColor>();
        sassyColors.Add("Sassy", SlotColor.BLUE);
        sassyColors.Add("Silly", SlotColor.RED);
        sassyColors.Add("Soggy", SlotColor.GREEN);
        var sillyColors = new Dictionary<string, SlotColor>();
        sillyColors.Add("Sassy", SlotColor.BLUE);
        sillyColors.Add("Silly", SlotColor.GREEN);
        sillyColors.Add("Soggy", SlotColor.RED);
        var soggyColors = new Dictionary<string, SlotColor>();
        soggyColors.Add("Sassy", SlotColor.GREEN);
        soggyColors.Add("Silly", SlotColor.BLUE);
        soggyColors.Add("Soggy", SlotColor.RED);
        var sallyColors = new Dictionary<string, SlotColor>();
        sallyColors.Add("Sassy", SlotColor.RED);
        sallyColors.Add("Silly", SlotColor.BLUE);
        sallyColors.Add("Soggy", SlotColor.GREEN);
        var simonColors = new Dictionary<string, SlotColor>();
        simonColors.Add("Sassy", SlotColor.RED);
        simonColors.Add("Silly", SlotColor.GREEN);
        simonColors.Add("Soggy", SlotColor.BLUE);
        var sausageColors = new Dictionary<string, SlotColor>();
        sausageColors.Add("Sassy", SlotColor.RED);
        sausageColors.Add("Silly", SlotColor.BLUE);
        sausageColors.Add("Soggy", SlotColor.GREEN);
        var stevenColors = new Dictionary<string, SlotColor>();
        stevenColors.Add("Sassy", SlotColor.GREEN);
        stevenColors.Add("Silly", SlotColor.RED);
        stevenColors.Add("Soggy", SlotColor.BLUE);
        slotColors.Add("Sassy", sassyColors);
        slotColors.Add("Silly", sillyColors);
        slotColors.Add("Soggy", soggyColors);
        slotColors.Add("Sally", sallyColors);
        slotColors.Add("Simon", simonColors);
        slotColors.Add("Sausage", sausageColors);
        slotColors.Add("Steven", stevenColors);

        var sassyShapes = new Dictionary<string, SlotShape>();
        sassyShapes.Add("Sally", SlotShape.CHERRY);
        sassyShapes.Add("Simon", SlotShape.GRAPE);
        sassyShapes.Add("Sausage", SlotShape.BOMB);
        sassyShapes.Add("Steven", SlotShape.COIN);
        var sillyShapes = new Dictionary<string, SlotShape>();
        sillyShapes.Add("Sally", SlotShape.COIN);
        sillyShapes.Add("Simon", SlotShape.BOMB);
        sillyShapes.Add("Sausage", SlotShape.GRAPE);
        sillyShapes.Add("Steven", SlotShape.CHERRY);
        var soggyShapes = new Dictionary<string, SlotShape>();
        soggyShapes.Add("Sally", SlotShape.COIN);
        soggyShapes.Add("Simon", SlotShape.CHERRY);
        soggyShapes.Add("Sausage", SlotShape.BOMB);
        soggyShapes.Add("Steven", SlotShape.GRAPE);
        var sallyShapes = new Dictionary<string, SlotShape>();
        sallyShapes.Add("Sally", SlotShape.GRAPE);
        sallyShapes.Add("Simon", SlotShape.CHERRY);
        sallyShapes.Add("Sausage", SlotShape.BOMB);
        sallyShapes.Add("Steven", SlotShape.COIN);
        var simonShapes = new Dictionary<string, SlotShape>();
        simonShapes.Add("Sally", SlotShape.BOMB);
        simonShapes.Add("Simon", SlotShape.GRAPE);
        simonShapes.Add("Sausage", SlotShape.CHERRY);
        simonShapes.Add("Steven", SlotShape.COIN);
        var sausageShapes = new Dictionary<string, SlotShape>();
        sausageShapes.Add("Sally", SlotShape.GRAPE);
        sausageShapes.Add("Simon", SlotShape.BOMB);
        sausageShapes.Add("Sausage", SlotShape.COIN);
        sausageShapes.Add("Steven", SlotShape.CHERRY);
        var stevenShapes = new Dictionary<string, SlotShape>();
        stevenShapes.Add("Sally", SlotShape.CHERRY);
        stevenShapes.Add("Simon", SlotShape.BOMB);
        stevenShapes.Add("Sausage", SlotShape.COIN);
        stevenShapes.Add("Steven", SlotShape.GRAPE);
        slotShapes.Add("Sassy", sassyShapes);
        slotShapes.Add("Silly", sillyShapes);
        slotShapes.Add("Soggy", soggyShapes);
        slotShapes.Add("Sally", sallyShapes);
        slotShapes.Add("Simon", simonShapes);
        slotShapes.Add("Sausage", sausageShapes);
        slotShapes.Add("Steven", stevenShapes);
    }
}

public class SillySlots : MonoBehaviour
{
    public Transform Slot1;
    public Transform Slot2;
    public Transform Slot3;
    public KMSelectable Lever;
    public KMSelectable Keep;
    public TextMesh Display;
    public MeshRenderer[] LEDs;

    public float SpinPower = 10f;
    public float SpinDampending = 5f;

    List<Slot[]> mPreviousSlots = new List<Slot[]>();
    Transform[] mSlots;
    Slot[] mCurrentSlots;
    float[] mSlotTargets;
    float[] mSlotVelocity;
    float[] mSlotDuration;
    float mStartRollTime;
    bool bActivated = false;
    bool bAnimating = false;
    Animator mAnimator;
    int mStage = 0;

    static string[] Keywords = new string[]{"Sally", "Simon", "Steven", "Sausage", "Sassy", "Silly", "Soggy"};
    static int MaxStages = 4;

    void Awake()
    {
        Slots.PopulateSubstitionTable();

        mSlots = new Transform[]{Slot1, Slot2, Slot3};
        mSlotTargets = new float[]{0f, 0f, 0f};
        mSlotVelocity = new float[]{0f, 0f, 0f};
        mSlotDuration = new float[]{0f, 0f, 0f};
        mCurrentSlots = new Slot[3];
        mStartRollTime = 0f;
        Display.text = "";

        for(int i = 0; i < mSlots.Length; i++)
        {
            mCurrentSlots[i] = Slots.Random();
            mSlots[i].localRotation = Quaternion.AngleAxis(mCurrentSlots[i].position, Vector3.right);
            mSlotTargets[i] = mCurrentSlots[i].position;
        }
        mPreviousSlots.Add((Slot[])mCurrentSlots.Clone());

        mAnimator = GetComponentInChildren<Animator>();
        Lever.OnInteract += LeverInteract;
        Keep.OnInteract += KeepInteract;
        GetComponent<KMBombModule>().OnActivate += OnActivate;
    }

    void SetLED( int index, bool isOn )
    {
        LEDs[index].material.SetFloat("_Blend", isOn ? 1f : 0f);
    }

    void OnActivate()
    {
        bActivated = true;
        SetLED(0, true);
        NewKeyword();
    }

    bool KeepInteract()
    {
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        if (bActivated && !bAnimating)
        {
            if (!CheckIllegalState())
            {
                GetComponent<KMBombModule>().HandlePass();
                GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
            }
            else
            {
                GetComponent<KMBombModule>().HandleStrike();
            }
        }
        return false;
    }

    bool LeverInteract()
    {
        if (bActivated && !bAnimating)
        {
            LeverPull();
        }
        return false;
    }

    void LeverPull()
    {
        if (!CheckIllegalState())
        {
            GetComponent<KMBombModule>().HandleStrike();
        }

        for(int i = 0; i < mSlots.Length; i++)
        {
            mCurrentSlots[i] = Slots.Random();
            mSlotTargets[i] = mCurrentSlots[i].position;
            mSlotDuration[i] = Random.Range(4f, 6f);
            mSlotVelocity[i] = 0f;
        }
        mPreviousSlots.Add((Slot[])mCurrentSlots.Clone());

        Display.text = "";
        mStartRollTime = Time.time;
        GetComponent<KMAudio>().PlaySoundAtTransform("LeverPull", transform);
        Invoke("PlaySlotMachineSound", 1.0f);

        InvokeRepeating("NewKeyword", 0f, 0.1f);
        Invoke("StopRolling", 7.0f);
        mStage++;

        mAnimator.SetTrigger("Lever");
        bAnimating = true;
    }

    void PlaySlotMachineSound()
    {
        GetComponent<KMAudio>().PlaySoundAtTransform("SlotMachineRoll", transform);
    }

    void NewKeyword()
    {
        Display.text = Keywords[Random.Range(0, Keywords.Length)];
    }

    void StopRolling()
    {
        CancelInvoke("NewKeyword");
        NewKeyword();
        for (int i = 0; i < LEDs.Length; i++)
        {
            if (i <= mStage) {
                SetLED(i, true);
            } else {
                SetLED(i, false);
            }
        }

        if (mStage == MaxStages)
        {
            GetComponent<KMBombModule>().HandlePass();
            GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
        }
    }

    void Update()
    {
        if (!bActivated || mStartRollTime == 0f) return;

        float elapsed = Time.time - mStartRollTime;
        for (int i = 0; i < mSlots.Length; i++)
        {
            if (elapsed < 2f)
            {
                mSlotVelocity[i] += 5f * Time.deltaTime;
                mSlots[i].Rotate(mSlotVelocity[i], 0f, 0f, Space.Self);
            }
            else if (elapsed < mSlotDuration[i])
            {
                Mathf.SmoothDampAngle(mSlots[i].localRotation.eulerAngles.x, mSlotTargets[i], ref mSlotVelocity[i], mSlotDuration[i] * 0.85f, Mathf.Infinity, Time.deltaTime);
                mSlots[i].Rotate(mSlotVelocity[i], 0f, 0f, Space.Self);
            } else {
                mSlotVelocity[i] = 0f;
                mSlots[i].localRotation = Quaternion.Slerp(mSlots[i].localRotation, Quaternion.AngleAxis(mSlotTargets[i], Vector3.right), 3f * Time.deltaTime);
                bAnimating = false;
            }
        }

        if (elapsed < 6f)
        {
            int ledIndex = ((int)Mathf.Floor(elapsed*10f) % LEDs.Length);
            int ledIndex2 = ((int)Mathf.Floor(elapsed*10f)+1) % LEDs.Length;
            SetLED(ledIndex, false);
            SetLED(ledIndex2, true);
        }
    }

    System.Func<Slot, bool> SlotPredicate( string predicateColor, string predicateShape )
    {
        var slotColors = Slots.slotColors[Display.text];
        var slotShapes = Slots.slotShapes[Display.text];
        return (Slot s) => {
            return s.color == slotColors[predicateColor] && s.shape == slotShapes[predicateShape];
        };
    }

    System.Func<Slot, bool> SlotColorPredicate( string predicateColor )
    {
        var slotColors = Slots.slotColors[Display.text];
        return (Slot s) => {
            return s.color == slotColors[predicateColor];
        };
    }

    System.Func<Slot, bool> SlotShapePredicate( string predicateShape )
    {
        var slotShapes = Slots.slotShapes[Display.text];
        return (Slot s) => {
            return s.shape == slotShapes[predicateShape];
        };
    }

    int CountSlots( string predicateColor, string predicateShape )
    {
        return mCurrentSlots.Count(SlotPredicate(predicateColor, predicateShape));
    }

    int CountSlots( Slot[] slots, string predicateColor, string predicateShape )
    {
        return slots.Count(SlotPredicate(predicateColor, predicateShape));
    }

    int CountSlotsAllStages( string predicateColor, string predicateShape )
    {
        int count = 0;
        for (int i = 0; i <= mPreviousSlots.Count-2; i++)
        {
            count += CountSlots(mPreviousSlots[i], predicateColor, predicateShape);
        }
        return count;
    }

    int CountSlotShapes( string predicateShape )
    {
        return mCurrentSlots.Count(SlotShapePredicate(predicateShape));
    }

    int CountSlotColors( string predicateColor )
    {
        return mCurrentSlots.Count(SlotColorPredicate(predicateColor));
    }

    Slot? GetFirstSlotShape( string predicateShape )
    {
        var slotShapes = Slots.slotShapes[Display.text];
        for (int i = 0; i < 3; i++)
        {
            if (mCurrentSlots[i].shape == slotShapes[predicateShape])
                return mCurrentSlots[i];
        }
        return null;
    }

    Slot? GetFirstSlotColor( string predicateColor )
    {
        var slotColors = Slots.slotColors[Display.text];
        for (int i = 0; i < 3; i++)
        {
            if (mCurrentSlots[i].color == slotColors[predicateColor])
                return mCurrentSlots[i];
        }
        return null;
    }

    Slot[] GetSlotShapes( string predicateShape )
    {
        return mCurrentSlots.Where(SlotShapePredicate(predicateShape)).ToArray();
    }

    Slot[] GetSlotColors( string predicateColor )
    {
        return mCurrentSlots.Where(SlotColorPredicate(predicateColor)).ToArray();
    }

    bool CheckIllegalState()
    {
        string keyword = Display.text;
        var slotColors = Slots.slotColors[keyword];
        var slotShapes = Slots.slotShapes[keyword];

        // There is a single Silly Sasusage.
        if (CountSlots("Silly", "Sausage") == 1)
        {
            Debug.Log("There is a single Silly Sasusage.");
            return true;
        }
        // There is a single Sassy Sally, unless the slot in the same position 2 stages ago was soggy.
        if (CountSlots("Sassy", "Sally") == 1)
        {
            if (mPreviousSlots.Count > 2)
            {
                int index = mCurrentSlots.ToList().FindIndex(s => {return s.color == slotColors["Sassy"] && s.shape == slotShapes["Sally"];});
                if (mPreviousSlots[mPreviousSlots.Count-3][index].color == slotColors["Soggy"])
                {
                    Debug.Log("Fallthrough: There is a single Sassy Sally, but the slot in the same position 2 stages ago was soggy.");
                }
                else
                {
                    Debug.Log("There is a single Sassy Sally, unless the slot in the same position 2 stages ago was soggy.");
                    return true;
                }
            }
            Debug.Log("There is a single Sassy Sally, unless the slot in the same position 2 stages ago was soggy.");
            return true;
        }
        // There is a single Sassy slot, unless it's Simon.
//        if ((CountSlotColors("Sassy") == 1) && (GetFirstSlotColor("Sassy").Value.shape != slotShapes["Simon"]))
//        {
//            Debug.Log("There is a single Sassy slot, unless it's Simon.");
//            return true;
//        }
        // There are 2 or more Soggy Stevens.
        if (CountSlots("Soggy", "Steven") >= 2)
        {
            Debug.Log("There are 2 or more Soggy Stevens.");
            return true;
        }
        // There are 3 Simons, unless any of them are Sassy.
        if (CountSlotShapes("Simon") == 3 && CountSlotColors("Sassy") == 0)
        {
            Debug.Log("There are 3 Simons, unless any of them are Sassy.");
            return true;
        }
        // There are exactly 2 Silly slots, unless they are both Steven.
        if (CountSlotColors("Silly") == 2)
        {
            Slot[] sillySlots = GetSlotColors("Silly");
            int count = sillySlots.Count(SlotShapePredicate("Steven"));
            if (count != sillySlots.Length)
            {
                Debug.Log("There are exactly 2 Silly slots, unless they are both Steven.");
                return true;
            }
            else
            {
                Debug.Log("Fallthrough: There are exactly 2 Silly slots, but they were both Steven.");
            }
        }
        // There is a Sausage adjacent to a Sally, unless Sally is Soggy.
        if(CountSlotShapes("Sausage") > 0 && CountSlotShapes("Sally") > 0)
        {
            Slot a = mCurrentSlots[0];
            Slot b = mCurrentSlots[1];
            Slot c = mCurrentSlots[2];
            bool isAdjacent = false;
            if (a.shape == slotShapes["Sally"] && b.shape == slotShapes["Sausage"] && c.shape == slotShapes["Sally"] && (a.color == slotColors["Soggy"] || c.color == slotColors["Soggy"]))
            {
                isAdjacent = true;
            }
            else if (a.shape == slotShapes["Sausage"] && b.shape == slotShapes["Sally"] && b.color != slotColors["Soggy"])
            {
                isAdjacent = true;
            }
            else if (a.shape == slotShapes["Sally"] && b.shape == slotShapes["Sausage"] && a.color != slotColors["Soggy"])
            {
                isAdjacent = true;
            }
            else if (b.shape == slotShapes["Sausage"] && c.shape == slotShapes["Sally"] && c.color != slotColors["Soggy"])
            {
                isAdjacent = true;
            }
            else if (b.shape == slotShapes["Sally"] && c.shape == slotShapes["Sausage"] && b.color != slotColors["Soggy"])
            {
                isAdjacent = true;
            }

            if (isAdjacent)
            {
                Debug.Log("There are exactly 2 Silly slots, unless they are both Steven.");
                return true;
            }
        }
        // There is a single Soggy slot, unless the previous stage had any number of Sausage slots.
        if(CountSlotColors("Soggy") == 1)
        {
            if (mPreviousSlots.Count > 1)
            {
                int count = mPreviousSlots[mPreviousSlots.Count-2].Count(SlotShapePredicate("Sausage"));
                if (count == 0)
                {
                    Debug.Log("There is a single Soggy slot, unless the previous stage had any number of Sausage slots.");
                    return true;
                }
                else
                {
                    Debug.Log("Fallthrough: There is a single Soggy slot, but the previous stage had any number of Sausage slots.");
                }
            }
            else
            {
                Debug.Log("There is a single Soggy slot, unless the previous stage had any number of Sausage slots.");
                return true;
            }
        }
        // All 3 slots are the same symbol and colour, unless there has been a Soggy Sausage at any stage.
        if (mCurrentSlots[0].shape == mCurrentSlots[1].shape && mCurrentSlots[0].color == mCurrentSlots[1].color && 
                 mCurrentSlots[1].shape == mCurrentSlots[2].shape && mCurrentSlots[1].color == mCurrentSlots[2].color)
        {
            int count = CountSlotsAllStages("Soggy", "Sausage");
            if (count == 0)
            {
                Debug.Log("All 3 slots are the same symbol and colour, unless there has been a Soggy Sausage at any stage.");
                return true;
            }
            else
            {
                Debug.Log("Fallthrough: All 3 slots are the same symbol and colour, but there has been a Soggy Sausage at any stage.");
            }
        }
        // All 3 slots are the same color, unless any of them are Sally or there was a Silly Steven in the last stage.
        if (mCurrentSlots[0].color == mCurrentSlots[1].color && mCurrentSlots[1].color == mCurrentSlots[2].color)
        {
            if (CountSlotShapes("Sally") > 0)
            {
                Debug.Log("Fallthrough: All 3 slots are the same color, but any of them are Sally.");
            }
            else if (mPreviousSlots.Count > 1)
            {
                int count = mPreviousSlots[mPreviousSlots.Count-2].Count(SlotPredicate("Silly", "Steven"));
                if (count == 0)
                {
                    Debug.Log("All 3 slots are the same color, unless any of them are Sally or there was a Silly Steven in the last stage.");
                    return true;
                }
                else
                {
                    Debug.Log("Fallthrough: All 3 slots are the same color, but there was a Silly Steven in the last stage.");
                }
            }
            else
            {
                Debug.Log("All 3 slots are the same color, unless any of them are Sally or there was a Silly Steven in the last stage.");
                return true;
            }
        }
        // There are any number of Silly Simons, unless there has been a Sassy Sausage in any stage.
        if (CountSlots("Silly", "Simon") > 0 && CountSlotsAllStages("Sassy", "Sausage") == 0)
        {
            Debug.Log("There are any number of Silly Simons, unless there has been a Sassy Sausage in any stage.");
            return true;
        }

        return false;
    }
}
