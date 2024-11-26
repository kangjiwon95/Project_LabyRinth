using UnityEngine;
using UnityEngine.UI;

namespace DarkPixelRPGUI.Scripts.UI
{
    public class TooltipWindow : MonoBehaviour
    {
        [SerializeField] private Text headerText;
        [SerializeField] private Text descriptionText;
        [SerializeField] private RectTransform windowTransform;

        private void Start()
        {
            HideTooltip();
        }

        public void ShowTooltip(string header, string description, float positionX)
        {
            headerText.text = header;
            descriptionText.text = description;
            var position = windowTransform.position;
            windowTransform.position = new Vector3(positionX, position.y, position.z);
            gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }
    }
}