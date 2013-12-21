using System;

namespace TopazOrganizer.Dispatchers
{
    public interface IPopupDispatcher
    {
        void ShowPopup(object sender, PopupDialogType popupDialogType);
        void ClosePopup();
    }
}
