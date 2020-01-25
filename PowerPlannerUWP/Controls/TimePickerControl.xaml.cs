using BareMvvm.Core.ViewModels;
using PowerPlannerAppDataLibrary;
using PowerPlannerAppDataLibrary.Extensions;
using PowerPlannerAppDataLibrary.Helpers;
using PowerPlannerAppDataLibrary.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ToolsPortable;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PowerPlannerUWP.Controls
{
    public sealed partial class TimePickerControl : UserControl
    {
        private static readonly TimeSpan InitialSelectedTime = new TimeSpan(9, 0, 0);

        private List<BaseEntry> _entries = new List<BaseEntry>()
        {
            new TimeEntry(InitialSelectedTime)
        };

        private ObservableCollection<BaseEntry> _observableEntries = new ObservableCollection<BaseEntry>()
        {
            new TimeEntry(InitialSelectedTime)
        };

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(string), typeof(TimePickerControl), new PropertyMetadata(""));

        /// <summary>
        /// If this is an end time control, bind to the StartTime value so times can be adjusted automatically.
        /// </summary>
        public TimeSpan? StartTime
        {
            get { return (TimeSpan?)GetValue(StartTimeProperty); }
            set { SetValue(StartTimeProperty, value); }
        }

        public static readonly DependencyProperty StartTimeProperty =
            DependencyProperty.Register(nameof(StartTime), typeof(TimeSpan?), typeof(TimePickerControl), new PropertyMetadata(null));

        /// <summary>
        /// The current selected time.
        /// </summary>
        public TimeSpan SelectedTime
        {
            get { return (TimeSpan)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(TimeSpan), typeof(TimePickerControl), new PropertyMetadata(InitialSelectedTime));



        bool _timeChanged;

        public string Selected
        {
            get => (string)TimePickerComboBox.SelectedItem;
            set => TimePickerComboBox.SelectedItem = value;
        }

        public TimePickerControl()
        {
            InitializeComponent();
            //TimePickerComboBox.ItemsSource = _observableEntries;
            Initialize();
        }

        private bool _initialized;

        private async void Initialize()
        {
            await PowerPlannerUWPLibrary.Extensions.UWPDateTimeFormatterExtension.InitializeAllShortTimesAsync();

            TimePickerComboBox.DropDownOpened += TimePickerComboBox_DropDownOpened;
            TimePickerComboBox.DropDownClosed += TimePickerComboBox_DropDownClosed;

            _initialized = true;

            UpdateItems();
        }

        private async void TimePickerComboBox_DropDownClosed(object sender, object e)
        {
            //_ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, delegate
            //{
            //    UpdateItems();
            //});

            await System.Threading.Tasks.Task.Delay(5);
            UpdateItems();
        }

        private void TimePickerComboBox_DropDownOpened(object sender, object e)
        {
            UpdateItems();
        }

        private static void OnStartTimeChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //(sender as TimePickerControl).UpdateItems();
        }

        //private static void TimeChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    var timePicker = ((TimePickerControl)sender);
        //    timePicker.UpdateTimes();
        //}

        //private void UpdateTimes()
        //{
        //    var mainTimeTicks = GetMainTime(this).Ticks;
        //    _timeChanged = true;
        //    UpdateItems();

        //    if (GetIsEnd(this))
        //        Selected = DateTimeFormatterExtension.Current.FormatAsShortTime(new DateTime(mainTimeTicks)) + CustomTimePickerHelpers.GenerateTimeOffsetText(new TimeSpan(mainTimeTicks - GetStartTime(this).Ticks));
        //    else
        //        Selected = DateTimeFormatterExtension.Current.FormatAsShortTime(new DateTime(mainTimeTicks));
        //}

        private void TimePickerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Note: If I assign ItemsSource to a new list, even if the items are the same objects, it'll clear the selected item

            if (TimePickerComboBox.SelectedItem is TimeEntry timeEntry)
            {
                SelectedTime = timeEntry.Time;
            }
            else if (TimePickerComboBox.SelectedItem == null)
            {
                //UpdateComboBoxSelectedItem();
            }

            // If we've changed this through the "TimeChanged" method then don't do anything.
            //if (_timeChanged)
            //{
            //    _timeChanged = false;
            //    return;
            //}

            //var isEnd = GetIsEnd(this);

            //// Attempt to parse the value that was just set into the ComboBox.
            ////if (!CustomTimePickerHelpers.ParseComboBoxItem(isEnd ? new DateTime(GetStartTime(this).Ticks) : DateTime.MinValue, (string)TimePickerComboBox.SelectedItem, out var t))
            ////{
            ////    var correctString = "EditingClassScheduleItemView_Invalid" + (isEnd ? "End" : "Start") + "Time";
            ////    var correctTitle = PowerPlannerResources.GetString(correctString + ".Title");
            ////    var correctContent = PowerPlannerResources.GetString(correctString + ".Content");
            ////    new PortableMessageDialog(correctContent, correctTitle).Show();
            ////    return;
            ////}

            //SetMainTime(this, t);
        }

        private void UpdateComboBoxSelectedItem()
        {
            if (TimePickerComboBox.SelectedItem == null)
            {
                int index = (TimePickerComboBox.ItemsSource as List<BaseEntry>)?.FindIndex(i => (i as TimeEntry).Time == SelectedTime) ?? -1;
                TimePickerComboBox.SelectedIndex = index;
            }
        }

        private TimeSpan GetStartTime()
        {
            return StartTime.GetValueOrDefault(new TimeSpan());
        }

        private void UpdateItems()
        {
            List<TimeSpan> desiredTimes = GenerateDesiredTimes().ToList();

            List<BaseEntry> desiredEntries = GenerateDesiredTimes().Select(i => new TimeEntry(i) as BaseEntry).ToList();

            try
            {
                //_observableEntries.MakeListLike(desiredEntries);
                //_entries = _entries.ToList();
                //_entries.MakeListLike(desiredEntries);

                // Seems like it isn't happy when this changes
                //TimePickerComboBox.SelectedItem = null;
                TimePickerComboBox.ItemsSource = desiredEntries;
                UpdateComboBoxSelectedItem();
                //TimePickerComboBox.SelectedItem = _entries.FirstOrDefault(i => (i as TimeEntry).Time == SelectedTime);
            }
            catch (Exception ex)
            {

            }
            //_entries.MakeListLike(desiredEntries);
        }

        private IEnumerable<TimeSpan> GenerateDesiredTimes()
        {
            TimeSpan startTime = GetStartTime();
            TimeSpan selectedTime = SelectedTime;
            TimeSpan incrementInterval = TimePickerComboBox.IsDropDownOpen ? TimeSpan.FromMinutes(30) : TimeSpan.FromMinutes(1);
            TimeSpan time = startTime;
            var addedExtraItem = false;

            while (time.Days < 1)
            {
                // Don't add the extra item if it exactly matches something already in the list.
                if (selectedTime == time)
                {
                    addedExtraItem = true;
                }

                if (!addedExtraItem && time > selectedTime)
                {
                    yield return selectedTime;
                    addedExtraItem = true;
                }

                yield return time;

                time = time.Add(incrementInterval);
            }
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        private abstract class BaseEntry
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public BaseEntry(string displayText)
            {
                DisplayText = displayText;
            }

            public string DisplayText { get; private set; }

            public override bool Equals(object obj)
            {
                if (obj is BaseEntry other)
                {
                    return DisplayText == other.DisplayText;
                }

                return base.Equals(obj);
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private class TimeEntry : BaseEntry
        {
            public TimeSpan Time { get; internal set; }

            public TimeEntry(TimeSpan time) : base(DateTimeFormatterExtension.Current.FormatAsShortTime(DateTime.Today.Add(time)))
            {
                Time = time;
            }
        }

        private class RelativeEntry : BaseEntry
        {
            public TimeSpan Offset { get; private set; }

            public RelativeEntry(TimeSpan offset) : base(CustomTimePickerHelpers.GeneratePlainTimeOffsetText(offset))
            {
                Offset = offset;
            }
        }
    }
}