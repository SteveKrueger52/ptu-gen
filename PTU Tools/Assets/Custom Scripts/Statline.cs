using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statline : MonoBehaviour {
    
    [SerializeField] public Stat statTag;
    [SerializeField] public int baseStat = 0;
    [SerializeField] public bool hideCS = false;

    [SerializeField][HideInInspector] private Text tagText;
    [SerializeField][HideInInspector] private Text baseText;
    [SerializeField][HideInInspector] private CanvasGroup CSMask;

    private Text modText;
    private Text totalText;
    private Text effectiveText;

    private bool scriptLoaded = false;

    private int added = 0;
    private int statMod = 0;
    private int combatStage = 0;

    void OnValidate() {
        if (!scriptLoaded) {
            CSMask = gameObject.GetComponentInChildren<CanvasGroup> ();
            Text[] texts = gameObject.GetComponentsInChildren <Text> ();
            foreach (Text t in texts) {
                switch (t.name) {
                case "Tag":
                    tagText = t;
                    break;
                case "Base":
                    baseText = t;
                    break;
                case "Mod":
                    modText = t;
                    break;
                case "Total":
                    totalText = t;
                    break;
                case "Effective Total":
                    effectiveText = t;
                    break;
                }
            }
            scriptLoaded = true;
        }
        CSMask.alpha = hideCS ? 0 : 1;
        tagText.text = Stats.toString(statTag) + ":";
        baseText.text = baseStat.ToString ();
        modText.text = getMod().ToString ();
        totalText.text = (getMod() + added).ToString ();
        effectiveText.text = (applyCS (getMod() + added, combatStage)).ToString();
    }

    // Use this for initialization
	void Start () {
        tagText.text = Stats.toString(statTag) + ":";
        baseText.text = baseStat.ToString ();
        modText.text = getMod().ToString ();
        totalText.text = (getMod() + added).ToString ();
        effectiveText.text = (applyCS (getMod() + added, combatStage)).ToString();
	}

	// Update is called once per frame
	void Update () {
        modText.text = getMod().ToString ();
        totalText.text = (getMod() + added).ToString ();
        effectiveText.text = (applyCS (getMod() + added, combatStage)).ToString();
	}

    public void ChangeAddedStat(InputField input) {
        int res = 0;
        int.TryParse (input.text, out res);
        added = res;
    }

    public void ChangeCombatStage(Dropdown drop) {
        combatStage = drop.value - 6;
    }

    public void ChangeStatMod(InputField input) {
        int res = 0;
        int.TryParse (input.text, out res);
        statMod = res;
    }

    private int getMod() {
        return Mathf.Max(baseStat + statMod, 1);
    }

    private static int applyCS(int stat, int cs) {
        if (cs > 0) {
            return Mathf.FloorToInt (stat * cs * .2f + stat);
        }
        else {
            return Mathf.CeilToInt (stat * cs * .1f + stat);
        }
    }
}
