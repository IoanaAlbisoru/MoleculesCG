using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedAtomManager : MonoBehaviour {
    private float cycleInterval = 0.01f;

    private List<ChargedAtom> chargedAtoms;
    private List<MovingChargedAtom> movingChargedAtoms;

    public void Start()
    {
        chargedAtoms = new List<ChargedAtom>(FindObjectsOfType<ChargedAtom>());
        movingChargedAtoms = new List<MovingChargedAtom>(FindObjectsOfType<MovingChargedAtom>());

        foreach(MovingChargedAtom mca in movingChargedAtoms)
        {
            StartCoroutine(Cycle(mca));
        }
    }

    public IEnumerator Cycle(MovingChargedAtom mca)
    {
        bool isFirst = true;

        while (true)
        {
            if (isFirst)
            {
                isFirst = false;
                yield return new WaitForSeconds(Random.Range (0,0.01f));

            }
            ApplyMagneticForce(mca);
            yield return new WaitForSeconds(cycleInterval);
        }
    }

    private void ApplyMagneticForce(MovingChargedAtom mca)
    {
        Vector3 newForce = Vector3.zero;

        foreach (ChargedAtom ca in chargedAtoms )
        {
            if (mca == ca)
                continue;

            float distance = Vector3.Distance(mca.transform.position, ca.gameObject.transform.position);
            float force = 1000 * mca.charge * ca.charge / Mathf.Pow(distance, 2);

            Vector3 direction = mca.transform.position - ca.transform.position;
            direction.Normalize();

            newForce += force * direction * cycleInterval;

            if(float.IsNaN(newForce.x))
                newForce = Vector3.zero;

            mca.rb.AddForce(newForce);
            
        }
    }
}
