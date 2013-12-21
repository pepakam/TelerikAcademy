using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;
using TopazOrganizer.Controls;
using TopazOrganizer.OrganizerEvents;
using TopazOrganizer.PopupDialogs;

namespace TopazOrganizer.Dispatchers
{
    public class PopupDispatcher:IPopupDispatcher
    {
        #region Fields
        readonly EventViewModelDispatcher masterDispatcher;
        readonly Popup attachedPopup;
        #endregion

        #region Events
        public delegate void PopupDialogFinishedEventHandler(object sender, PopupDialogFinishedEventArgs e);
        public event PopupDialogFinishedEventHandler EventCreated;
        public event PopupDialogFinishedEventHandler EventChanged;
        public event PopupDialogFinishedEventHandler EventRemoved;
        #endregion

        public PopupDispatcher(EventViewModelDispatcher masterDispatcher)
        {
            this.masterDispatcher = masterDispatcher;
            this.attachedPopup = masterDispatcher.AttachedWeekGridControl.WeekGridPopup;
        }

        #region Public Methods
        public void ShowPopup(object sender, PopupDialogType popupDialogType)
        {
            this.attachedPopup.IsOpen = false;
            this.attachedPopup.Child = null;

            switch (popupDialogType)
            {
                case PopupDialogType.Create:
                    {
                        Rectangle target = sender as Rectangle;
                        if (target != null)
                        {
                            ShowCreateDialog(target);
                        }
                        break;
                    }
                case PopupDialogType.Edit:
                    {
                        EventControl target = sender as EventControl;
                        if (target != null)
                        {
                            ShowEditEventDialog(target);
                        }
                        break;
                    }
                case PopupDialogType.Details:
                    {
                        EventControl target = sender as EventControl;
                        if (target != null)
                        {
                            ShowEventDetailsDialog(target);
                        }
                        break;
                    }
            }
        }

        public void ClosePopup()
        {
            this.attachedPopup.IsOpen = false;
        }
        #endregion

        #region Private Methods
        
        private void ShowEditEventDialog(EventControl target)
        {
            this.attachedPopup.PlacementTarget = target;
            EditEventDialog editPopupDialog = new EditEventDialog();
            editPopupDialog.FillData(target.DataSource);
            editPopupDialog.DialogTitleTextBlock.Text = "Edit";
            editPopupDialog.SubmitButton.Content = "Apply";
            editPopupDialog.SubmitButton.Click += new System.Windows.RoutedEventHandler(this.EditDialogSubmitButton_Clicked);
            editPopupDialog.EventPopupCloseButton.Click += new System.Windows.RoutedEventHandler(this.DialogCloseButton_Clicked);

            this.attachedPopup.Width = editPopupDialog.Width;
            this.attachedPopup.Height = editPopupDialog.Height;
            this.attachedPopup.Child = editPopupDialog;

            this.attachedPopup.IsOpen = true;
        }
        
        private void ShowCreateDialog(Rectangle target)
        {
            const int FirstHourCellRow = WeekGridControl.FirstHourCellRow;
            const int FirstHourCellColumn = WeekGridControl.FirstHourCellColumn;
            
            //Get row/column of the cell that got clicked
            int cellRow = Grid.GetRow(target);
            int cellColumn = Grid.GetColumn(target);

            //Calculate start/end of the new event based on the cell position.
            DateTime newEventStart = masterDispatcher.WeekOnFocusStart.AddDays(cellColumn - FirstHourCellColumn)
                                         .AddHours(cellRow - FirstHourCellRow);
            DateTime newEventEnd = newEventStart.AddHours(1);

            this.attachedPopup.PlacementTarget = target;
            EditEventDialog editPopupDialog = new EditEventDialog();
            editPopupDialog.FillData(String.Empty, String.Empty, OrganizerEventType.Other, newEventStart, newEventEnd, false);
            editPopupDialog.DialogTitleTextBlock.Text = "Create";
            editPopupDialog.SubmitButton.Content = "Create";
            editPopupDialog.SubmitButton.Click += new System.Windows.RoutedEventHandler(this.CreateDialogSubmitButton_Clicked);
            editPopupDialog.EventPopupCloseButton.Click += new System.Windows.RoutedEventHandler(this.DialogCloseButton_Clicked);

            this.attachedPopup.Width = editPopupDialog.Width;
            this.attachedPopup.Height = editPopupDialog.Height;
            this.attachedPopup.Placement = PlacementMode.Top;
            this.attachedPopup.Child = editPopupDialog;

            this.attachedPopup.IsOpen = true;
        }
  
        private void ShowEventDetailsDialog(EventControl target)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private void SubmitDialog(object target, PopupDialogType type)
        {
            EditEventDialog submittedDialog = this.attachedPopup.Child as EditEventDialog;
            if (type == PopupDialogType.Create)
            {
                OrganizerEvent newEvent = OrganizerEventFactory.CreateOrganizerEvent(
                    (OrganizerEventType)submittedDialog.EventTypeComboBox.SelectedItem,
                    submittedDialog.TitleTextBox.Text,
                    submittedDialog.LocationTextBox.Text,
                    submittedDialog.StartTimePicker.Value.Value,
                    submittedDialog.EndTimePicker.Value.Value,
                    submittedDialog.AllDayCheckBox.IsChecked.Value,
                    null);
                //TO-DO: add the optional extended fields instead of null.
                this.masterDispatcher.DataSources[0].Add(newEvent);
            }
            else
            {
                OrganizerEvent dataSource = submittedDialog.DataSource;
                if (dataSource.EventType == (OrganizerEventType)submittedDialog.EventTypeComboBox.SelectedItem)
                {
                    dataSource.Title = submittedDialog.TitleTextBox.Text;
                    dataSource.Location = submittedDialog.LocationTextBox.Text;
                    dataSource.End = submittedDialog.EndTimePicker.Value.Value;
                    dataSource.Start = submittedDialog.StartTimePicker.Value.Value;
                }
                else
                {
                    OrganizerEvent newEvent = OrganizerEventFactory.CreateOrganizerEvent(
                        (OrganizerEventType)submittedDialog.EventTypeComboBox.SelectedItem,
                        submittedDialog.TitleTextBox.Text,
                        submittedDialog.LocationTextBox.Text,
                        submittedDialog.StartTimePicker.Value.Value,
                        submittedDialog.EndTimePicker.Value.Value,
                        submittedDialog.AllDayCheckBox.IsChecked.Value,
                        null);
                    this.masterDispatcher.DataSources[0].Remove(dataSource);
                    this.masterDispatcher.DataSources[0].Add(newEvent);
                }
            }
            this.attachedPopup.IsOpen = false;
        }
        #endregion

        #region Event Handlers
        private void DialogCloseButton_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ClosePopup();
        }

        private void CreateDialogSubmitButton_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.SubmitDialog(sender, PopupDialogType.Create);
        }

        private void EditDialogSubmitButton_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.SubmitDialog(sender, PopupDialogType.Edit);
        }
        
        private void OnEventCreated(OrganizerEvent createdEvent)
        {
            if (this.EventCreated != null)
                this.EventCreated(this, new PopupDialogFinishedEventArgs(createdEvent, null));
        }
        
        private void OnEventChanged(OrganizerEvent changedEvent, EventControl callingControl)
        {
            if (this.EventCreated != null)
                this.EventCreated(this, new PopupDialogFinishedEventArgs(changedEvent, callingControl));
        }

        private void OnEventRemoved(OrganizerEvent removedEvent, EventControl callingControl)
        {
            if (this.EventCreated != null)
                this.EventCreated(this, new PopupDialogFinishedEventArgs(removedEvent, callingControl));
        }


        #endregion
    }
}
