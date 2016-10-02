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

        foreach (Transform slot in latchSlots)
        {
            GameObject module = (GameObject)Instantiate(Modules[Random.Range(0, Modules.Length)], slot.transform.position, slot.transform.rotation);
            module.transform.parent = slot.root.FindChild("Modules");
        }
    }
}
