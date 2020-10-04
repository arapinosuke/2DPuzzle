using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ComboCounter : MonoBehaviour
{
    public List<GameObject> DragObjList = new List<GameObject>();

    public int ComboCount => DragObjList.Count;

    public OrbGenerater m_OrbGenerater = null;

    public int CurrentComboCount=0;

    [SerializeField] private LimitTimeCountViewer m_limitTimeCountViwer = null;

    public void AddCombo(GameObject orb)
    {
        DragObjList.Add(orb);
        foreach(var  orbs in DragObjList)
        {
            if(!orbs.GetComponent<OrbController>().ComboEffect.gameObject.activeSelf)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.gameObject.SetActive(true);
            }
        }
    }

    public void MinusCombo()
    {
        DragObjList.LastOrDefault().GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);
        DragObjList.Remove(DragObjList.LastOrDefault());
        
    }

    public void ClearCombo()
    {

        //todo;コンボが3より大きければ秒数を増やす

        if(DragObjList.Count>3)
        {
            m_limitTimeCountViwer.PlusTime();
        }

        foreach (var orbs in DragObjList)
        {
            if(orbs.GetComponent<OrbController>().ComboEffect.gameObject.activeSelf)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);
            }
            CurrentComboCount++;
        }
        DragObjList.Clear();
    }

    public bool CheckCombo(Transform thisOrbTransform)
    {
        //thisOrbTransformとDragObjelistの距離を測る
        float distance = (thisOrbTransform.position - DragObjList.LastOrDefault().transform.position).magnitude;
        Debug.Log(distance);
        //distanceが2より大きければtrueを返す
        return distance>2f;
    }
}
