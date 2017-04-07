using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Random = UnityEngine.Random;

public class SillySlots : MonoBehaviour
{
    public enum SlotShape
    {
        BOMB, GRAPE, CHERRY, COIN
    }
    public enum SlotColor
    {
        RED, GREEN, BLUE
    }

    public enum ShapeWord
    {
        Sally, Simon, Sausage, Steven
    }
    public enum ColorWord
    {
        Sassy, Silly, Soggy
    }

    public struct Slot
    {
        public SlotShape shape;
        public SlotColor color;
        public float position;
        public Slot(SlotShape shape, SlotColor color, float position)
        {
            this.shape = shape;
            this.color = color;
            this.position = position;
        }
    }
    public static class Slots
    {
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

        public static Slot Random()
        {
            return slots[UnityEngine.Random.Range(0, slots.Length)];
        }

        public static Dictionary<string, Dictionary<ColorWord, SlotColor>> slotColors;
        public static Dictionary<string, Dictionary<ShapeWord, SlotShape>> slotShapes;

        public static void PopulateSubstitionTable()
        {
            if (slotColors != null && slotShapes != null)
                return;

            slotColors = new Dictionary<string, Dictionary<ColorWord, SlotColor>>();
            slotShapes = new Dictionary<string, Dictionary<ShapeWord, SlotShape>>();

            var sassyColors = new Dictionary<ColorWord, SlotColor>();
            sassyColors.Add(ColorWord.Sassy, SlotColor.BLUE);
            sassyColors.Add(ColorWord.Silly, SlotColor.RED);
            sassyColors.Add(ColorWord.Soggy, SlotColor.GREEN);
            var sillyColors = new Dictionary<ColorWord, SlotColor>();
            sillyColors.Add(ColorWord.Sassy, SlotColor.BLUE);
            sillyColors.Add(ColorWord.Silly, SlotColor.GREEN);
            sillyColors.Add(ColorWord.Soggy, SlotColor.RED);
            var soggyColors = new Dictionary<ColorWord, SlotColor>();
            soggyColors.Add(ColorWord.Sassy, SlotColor.GREEN);
            soggyColors.Add(ColorWord.Silly, SlotColor.BLUE);
            soggyColors.Add(ColorWord.Soggy, SlotColor.RED);
            var sallyColors = new Dictionary<ColorWord, SlotColor>();
            sallyColors.Add(ColorWord.Sassy, SlotColor.RED);
            sallyColors.Add(ColorWord.Silly, SlotColor.BLUE);
            sallyColors.Add(ColorWord.Soggy, SlotColor.GREEN);
            var simonColors = new Dictionary<ColorWord, SlotColor>();
            simonColors.Add(ColorWord.Sassy, SlotColor.RED);
            simonColors.Add(ColorWord.Silly, SlotColor.GREEN);
            simonColors.Add(ColorWord.Soggy, SlotColor.BLUE);
            var sausageColors = new Dictionary<ColorWord, SlotColor>();
            sausageColors.Add(ColorWord.Sassy, SlotColor.RED);
            sausageColors.Add(ColorWord.Silly, SlotColor.BLUE);
            sausageColors.Add(ColorWord.Soggy, SlotColor.GREEN);
            var stevenColors = new Dictionary<ColorWord, SlotColor>();
            stevenColors.Add(ColorWord.Sassy, SlotColor.GREEN);
            stevenColors.Add(ColorWord.Silly, SlotColor.RED);
            stevenColors.Add(ColorWord.Soggy, SlotColor.BLUE);
            slotColors.Add("Sassy", sassyColors);
            slotColors.Add("Silly", sillyColors);
            slotColors.Add("Soggy", soggyColors);
            slotColors.Add("Sally", sallyColors);
            slotColors.Add("Simon", simonColors);
            slotColors.Add("Sausage", sausageColors);
            slotColors.Add("Steven", stevenColors);

            var sassyShapes = new Dictionary<ShapeWord, SlotShape>();
            sassyShapes.Add(ShapeWord.Sally, SlotShape.CHERRY);
            sassyShapes.Add(ShapeWord.Simon, SlotShape.GRAPE);
            sassyShapes.Add(ShapeWord.Sausage, SlotShape.BOMB);
            sassyShapes.Add(ShapeWord.Steven, SlotShape.COIN);
            var sillyShapes = new Dictionary<ShapeWord, SlotShape>();
            sillyShapes.Add(ShapeWord.Sally, SlotShape.COIN);
            sillyShapes.Add(ShapeWord.Simon, SlotShape.BOMB);
            sillyShapes.Add(ShapeWord.Sausage, SlotShape.GRAPE);
            sillyShapes.Add(ShapeWord.Steven, SlotShape.CHERRY);
            var soggyShapes = new Dictionary<ShapeWord, SlotShape>();
            soggyShapes.Add(ShapeWord.Sally, SlotShape.COIN);
            soggyShapes.Add(ShapeWord.Simon, SlotShape.CHERRY);
            soggyShapes.Add(ShapeWord.Sausage, SlotShape.BOMB);
            soggyShapes.Add(ShapeWord.Steven, SlotShape.GRAPE);
            var sallyShapes = new Dictionary<ShapeWord, SlotShape>();
            sallyShapes.Add(ShapeWord.Sally, SlotShape.GRAPE);
            sallyShapes.Add(ShapeWord.Simon, SlotShape.CHERRY);
            sallyShapes.Add(ShapeWord.Sausage, SlotShape.BOMB);
            sallyShapes.Add(ShapeWord.Steven, SlotShape.COIN);
            var simonShapes = new Dictionary<ShapeWord, SlotShape>();
            simonShapes.Add(ShapeWord.Sally, SlotShape.BOMB);
            simonShapes.Add(ShapeWord.Simon, SlotShape.GRAPE);
            simonShapes.Add(ShapeWord.Sausage, SlotShape.CHERRY);
            simonShapes.Add(ShapeWord.Steven, SlotShape.COIN);
            var sausageShapes = new Dictionary<ShapeWord, SlotShape>();
            sausageShapes.Add(ShapeWord.Sally, SlotShape.GRAPE);
            sausageShapes.Add(ShapeWord.Simon, SlotShape.BOMB);
            sausageShapes.Add(ShapeWord.Sausage, SlotShape.COIN);
            sausageShapes.Add(ShapeWord.Steven, SlotShape.CHERRY);
            var stevenShapes = new Dictionary<ShapeWord, SlotShape>();
            stevenShapes.Add(ShapeWord.Sally, SlotShape.CHERRY);
            stevenShapes.Add(ShapeWord.Simon, SlotShape.BOMB);
            stevenShapes.Add(ShapeWord.Sausage, SlotShape.COIN);
            stevenShapes.Add(ShapeWord.Steven, SlotShape.GRAPE);
            slotShapes.Add("Sassy", sassyShapes);
            slotShapes.Add("Silly", sillyShapes);
            slotShapes.Add("Soggy", soggyShapes);
            slotShapes.Add("Sally", sallyShapes);
            slotShapes.Add("Simon", simonShapes);
            slotShapes.Add("Sausage", sausageShapes);
            slotShapes.Add("Steven", stevenShapes);
        }
    }

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
    int lastFlashingLed = 0;
    bool solved = false;

    static string[] Keywords = new string[] { "Sally", "Simon", "Steven", "Sausage", "Sassy", "Silly", "Soggy" };
    static int MaxStages = 4;

    static int _moduleIdCounter = 1;
    int _moduleId;

    void Awake()
    {
        _moduleId = _moduleIdCounter++;

        Slots.PopulateSubstitionTable();

        mSlots = new Transform[] { Slot1, Slot2, Slot3 };
        mSlotTargets = new float[] { 0f, 0f, 0f };
        mSlotVelocity = new float[] { 0f, 0f, 0f };
        mSlotDuration = new float[] { 0f, 0f, 0f };
        mCurrentSlots = new Slot[3];
        mStartRollTime = 0f;
        Display.text = "";

        for (int i = 0; i < mSlots.Length; i++)
        {
            mCurrentSlots[i] = Slots.Random();
            mSlots[i].localRotation = Quaternion.AngleAxis(mCurrentSlots[i].position, Vector3.right);
            mSlotTargets[i] = mCurrentSlots[i].position;
        }
        mPreviousSlots.Add((Slot[]) mCurrentSlots.Clone());

        mAnimator = GetComponentInChildren<Animator>();
        Lever.OnInteract += LeverInteract;
        Keep.OnInteract += KeepInteract;
        GetComponent<KMBombModule>().OnActivate += OnActivate;
    }

    public IEnumerator ProcessTwitchCommand(string command)
    {
        Match modulesMatch = Regex.Match(command, "^(keep|pull)$", RegexOptions.IgnoreCase);
        if (!modulesMatch.Success || mStage == MaxStages)
        {
            yield break;
        }

        yield return command;
        KMSelectable buttonSelectable = command.Equals("keep", StringComparison.InvariantCultureIgnoreCase) 
            ? Keep 
            : Lever;
        yield return buttonSelectable;
        yield return new WaitForSeconds(0.1f);
        yield return buttonSelectable;
        if (mStage == MaxStages)
        {
            yield return "solve";  //Solve for the 4th pull is delayed.
        }

    }

    void SetLED(int index, bool isOn)
    {
        LEDs[index].material.SetFloat("_Blend", isOn ? 1f : 0f);
    }

    void OnActivate()
    {
        bActivated = true;
        SetLED(0, true);
        NewKeyword();
        LogCurrentStage();
    }

    bool KeepInteract()
    {
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
        if (bActivated && !bAnimating && !solved)
        {
            if (!CheckIllegalState(false))
            {
                Debug.LogFormat("[Silly Slots #{0}] KEEP is correct.", _moduleId);
                GetComponent<KMBombModule>().HandlePass();
                GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
                solved = true;
            }
            else
            {
                Debug.LogFormat("[Silly Slots #{0}] Pressed KEEP, should have pulled the lever.", _moduleId);
                GetComponent<KMBombModule>().HandleStrike();
            }
        }
        return false;
    }

    bool LeverInteract()
    {
        if (bActivated && !bAnimating && !solved)
            LeverPull();
        return false;
    }

    void LeverPull()
    {
        if (!CheckIllegalState(false))
        {
            Debug.LogFormat("[Silly Slots #{0}] Pulled lever, should have pressed KEEP.", _moduleId);
            GetComponent<KMBombModule>().HandleStrike();
        }

        for (int i = 0; i < mSlots.Length; i++)
        {
            mCurrentSlots[i] = Slots.Random();
            mSlotTargets[i] = mCurrentSlots[i].position;
            mSlotDuration[i] = Random.Range(4f, 6f);
            mSlotVelocity[i] = 0f;
        }
        mPreviousSlots.Add((Slot[]) mCurrentSlots.Clone());

        mStartRollTime = Time.time;
        GetComponent<KMAudio>().PlaySoundAtTransform("LeverPull", transform);
        Invoke("PlaySlotMachineSound", 1.0f);

        InvokeRepeating("NewKeywordAndLED", 1.0f, 0.1f);
        Invoke("StopRolling", 7.0f);
        mStage++;

        mAnimator.SetTrigger("Lever");
        bAnimating = true;
    }

    void PlaySlotMachineSound()
    {
        GetComponent<KMAudio>().PlaySoundAtTransform("SlotMachineRoll", transform);
    }

    void NewKeywordAndLED()
    {
        NewKeyword();
        SetLED(lastFlashingLed, false);
        lastFlashingLed = (lastFlashingLed + 1) % LEDs.Length;
        SetLED(lastFlashingLed, true);
    }

    void NewKeyword()
    {
        Display.text = Keywords[Random.Range(0, Keywords.Length)];
    }

    void StopRolling()
    {
        bAnimating = false;
        CancelInvoke("NewKeywordAndLED");
        NewKeyword();
        for (int i = 0; i < LEDs.Length; i++)
            SetLED(i, i <= mStage);

        if (mStage == MaxStages)
        {
            GetComponent<KMBombModule>().HandlePass();
            GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.CorrectChime, transform);
            solved = true;
        }
        else
        {
            LogCurrentStage();
        }
    }

    private void LogCurrentStage()
    {
        Debug.LogFormat("[Silly Slots #{4}] Stage {0}: {1}\n{2}\n{3}", mStage + 1, Display.text,
            string.Join(" │ ", mCurrentSlots.Select(slot => string.Format("{0} {1}", slot.color.ToString().PadRight(7, ' '), Slots.slotColors[Display.text].FirstOrDefault(kvp => kvp.Value == slot.color).Key.ToString().PadRight(8, ' '))).ToArray()),
            string.Join(" │ ", mCurrentSlots.Select(slot => string.Format("{0} {1}", slot.shape.ToString().PadRight(7, ' '), Slots.slotShapes[Display.text].FirstOrDefault(kvp => kvp.Value == slot.shape).Key.ToString().PadRight(8, ' '))).ToArray()),
            _moduleId);
        var answer = CheckIllegalState(true);
        Debug.LogFormat("[Silly Slots #{0}] Answer: {1}", _moduleId, answer ? "PULL" : "KEEP");
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
            }
            else
            {
                mSlotVelocity[i] = 0f;
                mSlots[i].localRotation = Quaternion.Slerp(mSlots[i].localRotation, Quaternion.AngleAxis(mSlotTargets[i], Vector3.right), 3f * Time.deltaTime);
            }
        }
    }

    int CountSlotsAllStages(SlotColor color, SlotShape shape)
    {
        int count = 0;
        for (int i = 0; i <= mPreviousSlots.Count - 2; i++)
            count += mPreviousSlots[i].Count(s => s.color == color && s.shape == shape);
        return count;
    }

    bool CheckIllegalState(bool doLogging)
    {
        string keyword = Display.text;
        var slotColors = Slots.slotColors[keyword];
        var slotShapes = Slots.slotShapes[keyword];

        var silly = slotColors[ColorWord.Silly];
        var sassy = slotColors[ColorWord.Sassy];
        var soggy = slotColors[ColorWord.Soggy];

        var sally = slotShapes[ShapeWord.Sally];
        var sausage = slotShapes[ShapeWord.Sausage];
        var simon = slotShapes[ShapeWord.Simon];
        var steven = slotShapes[ShapeWord.Steven];

        // There is a single Silly Sasusage.
        if (mCurrentSlots.Count(s => s.color == silly && s.shape == sausage) == 1)
        {
            if (doLogging)
                Debug.LogFormat("[Silly Slots #{0}] There is a single Silly Sasusage ({1} {2}).", _moduleId, silly, sausage);
            return true;
        }

        // There is a single Sassy Sally, unless the slot in the same position 2 stages ago was soggy.
        if (mCurrentSlots.Count(s => s.color == sassy && s.shape == sally) == 1)
        {
            if (mPreviousSlots.Count > 2)
            {
                int index = System.Array.FindIndex(mCurrentSlots, s => s.color == sassy && s.shape == sally);
                if (mPreviousSlots[mPreviousSlots.Count - 3][index].color == soggy)
                {
                    if (doLogging)
                        Debug.LogFormat("[Silly Slots #{0}] Fallthrough: There is a single Sassy Sally ({1} {2}), but the slot in the same position 2 stages ago was Soggy ({3}).", _moduleId, sassy, sally, soggy);
                }
                else
                {
                    if (doLogging)
                        Debug.LogFormat("[Silly Slots #{0}] There is a single Sassy Sally ({1} {2}), and the slot in the same position 2 stages ago was not Soggy ({3}).", _moduleId, sassy, sally, soggy);
                    return true;
                }
            }
            else
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] There is a single Sassy Sally ({1} {2}), and there were no 2 previous stages.", _moduleId, sassy, sally, soggy);
                return true;
            }
        }
        // There are 2 or more Soggy Stevens.
        if (mCurrentSlots.Count(s => s.color == soggy && s.shape == steven) >= 2)
        {
            if (doLogging)
                Debug.LogFormat("[Silly Slots #{0}] There are 2 or more Soggy Stevens ({1} {2}).", _moduleId, soggy, steven);
            return true;
        }
        // There are 3 Simons, unless any of them are Sassy.
        if (mCurrentSlots.Count(s => s.shape == simon) == 3 && !mCurrentSlots.Any(s => s.color == sassy))
        {
            if (doLogging)
                Debug.LogFormat("[Silly Slots #{0}] There are 3 Simons ({1}), and none of them are Sassy ({2}).", _moduleId, simon, sassy);
            return true;
        }
        // There is a Sausage adjacent to a Sally, unless Sally is Soggy.
        if (mCurrentSlots.Any(s => s.shape == sausage) && mCurrentSlots.Any(s => s.shape == sally))
        {
            Slot a = mCurrentSlots[0];
            Slot b = mCurrentSlots[1];
            Slot c = mCurrentSlots[2];
            if ((a.shape == sausage && b.shape == sally && b.color != soggy) ||
                (b.shape == sausage && a.shape == sally && a.color != soggy) ||
                (b.shape == sausage && c.shape == sally && c.color != soggy) ||
                (c.shape == sausage && b.shape == sally && b.color != soggy))
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] There is a Sausage ({1}) adjacent to a Sally ({2}), and Sally ({2}) isn’t Soggy ({3}).", _moduleId, sausage, sally, soggy);
                return true;
            }
        }
        // There are exactly 2 Silly slots, unless they are both Steven.
        if (mCurrentSlots.Count(s => s.color == silly) == 2)
        {
            Slot[] sillySlots = mCurrentSlots.Where(s => s.color == silly).ToArray();
            int count = sillySlots.Count(s => s.shape == steven);
            if (count != sillySlots.Length)
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] There are exactly 2 Silly ({1}) slots, and they are not both Steven ({2}).", _moduleId, silly, steven);
                return true;
            }
            else
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] Fallthrough: There are exactly 2 Silly ({1}) slots, but they were both Steven ({2}).", _moduleId, silly, steven);
            }
        }
        // There is a single Soggy slot, unless the previous stage had any number of Sausage slots.
        if (mCurrentSlots.Count(s => s.color == soggy) == 1)
        {
            if (mPreviousSlots.Count > 1)
            {
                if (!mPreviousSlots[mPreviousSlots.Count - 2].Any(s => s.shape == sausage))
                {
                    if (doLogging)
                        Debug.LogFormat("[Silly Slots #{0}] There is a single Soggy ({1}) slot, and the previous stage did not have any number of Sausage ({2}) slots.", _moduleId, soggy, sausage);
                    return true;
                }
                else
                {
                    if (doLogging)
                        Debug.LogFormat("[Silly Slots #{0}] Fallthrough: There is a single Soggy ({1}) slot, but the previous stage had a Sausage ({2}) slot.", _moduleId, soggy, sausage);
                }
            }
            else
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] There is a single Soggy ({1}) slot and there is no previous stage.", _moduleId, soggy);
                return true;
            }
        }
        // All 3 slots are the same symbol and colour, unless there has been a Soggy Sausage in any previous stage.
        if (mCurrentSlots[0].shape == mCurrentSlots[1].shape && mCurrentSlots[0].color == mCurrentSlots[1].color &&
                 mCurrentSlots[1].shape == mCurrentSlots[2].shape && mCurrentSlots[1].color == mCurrentSlots[2].color)
        {
            var index = mPreviousSlots.FindIndex(ss => ss.Any(s => s.color == soggy && s.shape == sausage));
            if (index >= 0 && index < mPreviousSlots.Count - 1)
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] Fallthrough: All 3 slots are the same symbol and colour, but there has been a Soggy Sausage ({1} {2}) in stage {3}.", _moduleId, soggy, sausage, index + 1);
            }
            else
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] All 3 slots are the same symbol and colour, and there has not been a Soggy Sausage ({1} {2}) in any previous stage.", _moduleId, soggy, sausage);
                return true;
            }
        }
        // All 3 slots are the same color, unless any of them are Sally or there was a Silly Steven in the last stage.
        if (mCurrentSlots[0].color == mCurrentSlots[1].color && mCurrentSlots[1].color == mCurrentSlots[2].color)
        {
            if (mCurrentSlots.Any(s => s.shape == sally))
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] Fallthrough: All 3 slots are the same color, but there was a Sally ({1}).", _moduleId, sally);
            }
            else if (mPreviousSlots.Count > 1)
            {
                if (!mPreviousSlots[mPreviousSlots.Count - 2].Any(s => s.color == silly && s.shape == steven))
                {
                    if (doLogging)
                        Debug.LogFormat("[Silly Slots #{0}] All 3 slots are the same color, none of them is Sally ({1}), and there was no Silly Steven ({2} {3}) in the last stage.", _moduleId, sally, silly, steven);
                    return true;
                }
                else
                {
                    if (doLogging)
                        Debug.LogFormat("[Silly Slots #{0}] Fallthrough: All 3 slots are the same color, but there was a Silly Steven ({2} {3}) in the last stage.", _moduleId, silly, steven);
                }
            }
            else
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] All 3 slots are the same color, none of them is Sally ({1}), and there was no previous stage.", _moduleId, sally);
                return true;
            }
        }
        // There are any number of Silly Simons, unless there has been a Sassy Sausage in any previous stage.
        if (mCurrentSlots.Any(s => s.color == silly && s.shape == simon))
        {
            var index = mPreviousSlots.FindIndex(ss => ss.Any(s => s.color == sassy && s.shape == sausage));
            if (index >= 0 && index < mPreviousSlots.Count - 1)
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] Fallthrough: There is a Silly Simon ({1} {2}), but there has been a Sassy Sausage ({3} {4}) in stage {5}.", _moduleId, silly, simon, sassy, sausage, index + 1);
            }
            else
            {
                if (doLogging)
                    Debug.LogFormat("[Silly Slots #{0}] There is a Silly Simon ({1} {2}), and there has not been a Sassy Sausage ({3} {4}) in any previous stage.", _moduleId, silly, simon, sassy, sausage);
                return true;
            }
        }

        return false;
    }
}
