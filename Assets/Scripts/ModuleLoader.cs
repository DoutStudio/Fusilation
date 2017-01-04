using UnityEngine;
using System.Linq;
using System.Collections;

public class ModuleLoader : MonoBehaviour
{
    public GameObject[] Modules;

    void Start()
    {
        //instantiate module on every latch point and make module child under ship ( or under a empty module child which is a child of ship)
        Transform[] latchSlots;
        latchSlots = transform.GetComponentsInChildren<Transform>().Where(x => x.tag == "LatchSlot").ToArray();

        Transform[] leftSlots = transform.FindChild("LatchSlots").GetComponentsInChildren<Transform>().Where(x => x.tag == "LeftSlot").ToArray();
        Transform[] rightSlots = transform.FindChild("LatchSlots").GetComponentsInChildren<Transform>().Where(x => x.tag == "RightSlot").ToArray();
        Transform[] centerSlots = transform.FindChild("LatchSlots").GetComponentsInChildren<Transform>().Where(x => x.tag == "LeftCenter").ToArray();

        foreach (Transform slot in leftSlots)
        {
            GameObject module = (GameObject)Instantiate(Modules[Random.Range(0, Modules.Length)], slot.transform.position, slot.transform.rotation);
            module.transform.parent = slot.root.FindChild("Modules");
            Vector3 rot = new Vector3(0, 0, 90);
            if (module.GetComponent<TargetingComputer>())
            {
                module.GetComponent<TargetingComputer>().defaultRotation = rot;
            }
            module.transform.Rotate(rot);
            module.layer = 10;
        }
        foreach (Transform slot in rightSlots)
        {
            GameObject module = (GameObject)Instantiate(Modules[Random.Range(0, Modules.Length)], slot.transform.position, slot.transform.rotation);
            module.transform.parent = slot.root.FindChild("Modules");
            Vector3 rot = new Vector3(0, 0, -90);
            if (module.GetComponent<TargetingComputer>())
            {
                module.GetComponent<TargetingComputer>().defaultRotation = rot;
            }
            module.transform.Rotate(rot);
            module.layer = 10;
        }
    }
}
