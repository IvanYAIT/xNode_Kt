using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class Switcher : MonoBehaviour
{
    [SerializeField] private DialogGraph graph;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;
    [SerializeField] private Button yesBtn;
    [SerializeField] private Button noBtn;
    [SerializeField] private Button returnBtn;

    void Start()
    {
        yesBtn.onClick.AddListener(Yes);
        noBtn.onClick.AddListener(No);
        returnBtn.onClick.AddListener(Back);
        graph.Start();
    }

    void Update()
    {
        text.text = graph.GetCurrentNode().text;
        image.sprite= graph.GetCurrentNode().image;
        if (graph.GetCurrentNode().isEndNode)
        {
            yesBtn.gameObject.SetActive(false);
            noBtn.gameObject.SetActive(false);
        } else if (!graph.GetCurrentNode().isEndNode)
        {
            yesBtn.gameObject.SetActive(true);
            noBtn.gameObject.SetActive(true);
        }
    }

    private void Yes() =>
        graph.GetCurrentNode().Yes();

    private void No()=>
        graph.GetCurrentNode().No();

    private void Back()
    {
        if(graph.GetCurrentNode().GetPreviousNode())
            graph.SetCurrentNode(graph.GetCurrentNode().GetPreviousNode());
    }
}
