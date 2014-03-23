// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using System.Threading;
using System.Windows.Controls.Primitives;
using UsnJournal;
using PInvoke;
using System.Diagnostics;

namespace UsnJournalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties

        private NtfsUsnJournal _usnJournal = null;
        public NtfsUsnJournal Journal
        {
            get { return _usnJournal; }
        }

        #endregion

        public enum EntryDetail
        {
            Folder = 0,
            File = 1,
            UsnEntry = 2
        }

        #region private member variables

        private Win32Api.USN_JOURNAL_DATA _usnCurrentJournalState;

        private MainWindow _usnEntryDetail;
        private double _lbItemX;
        private double _lbItemY;

        private EntryDetail _entryDetail;

        #endregion

        #region delegates

        private delegate void FillListBoxDelegate(NtfsUsnJournal.UsnJournalReturnCode rtnCode, List<Win32Api.UsnEntry> usnEntries, Win32Api.USN_JOURNAL_DATA newUsnState);
        private delegate void FillListBoxWithFilesDelagate(NtfsUsnJournal.UsnJournalReturnCode rtnCode, List<Win32Api.UsnEntry> fileList);
        private delegate void FillListBoxWithFoldersDelegate(NtfsUsnJournal.UsnJournalReturnCode rtnCode, List<Win32Api.UsnEntry> folders);

        #endregion

        #region constructor(s)

        public MainWindow()
        {
            InitializeComponent();
            _usnCurrentJournalState = new Win32Api.USN_JOURNAL_DATA();
        }

        #endregion

        #region event handler functions

        private void SelectVolume_Click(object sender, RoutedEventArgs e)
        {
            //_usnEntryDetail.Visibility = Visibility.Hidden;
            resultsLb.ItemsSource = null;
            resultsLb.Items.Clear();

            VolumeSelectDialog selectVolumeDlg = new VolumeSelectDialog(this);

            bool? rtn = selectVolumeDlg.ShowDialog();
            if (rtn != null && rtn.Value)
            {
                DriveInfo volume = selectVolumeDlg.Volume;
                try
                {
                    _usnJournal = new NtfsUsnJournal(volume);
                    FunctionElapsedTime.Content = string.Format("{0} elapsed time {1}(ms) - Volume: {2}",
                        "NtfsUsnJournal() constructor", NtfsUsnJournal.ElapsedTime.Milliseconds.ToString(), volume.Name);
                    CreateUsnJournal.IsEnabled = true;
                    DeleteUsnJournal.IsEnabled = true;
                    SaveUsnState.IsEnabled = true;
                    ViewUsnChanges.IsEnabled = true;
                }
                catch (Exception excptn)
                {
                    if (excptn.Message.Contains("Access is denied"))
                    {
                        ListBoxItem lbItem = new ListBoxItem();
                        lbItem.Content = string.Format("Potrzebujesz praw administratora.");
                        lbItem.Foreground = Brushes.Red;
                        resultsLb.Items.Add(lbItem);
                    }
                    else
                    {
                        ListBoxItem lbItem = new ListBoxItem();
                        lbItem.Content = string.Format("Błąd wybrania woluminu");
                        lbItem.Foreground = Brushes.Red;
                        resultsLb.Items.Add(lbItem);
                    }
                }
            }
            else
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = string.Format("Żaden wolumin dysku nie został wybrany.");
                lbItem.Foreground = Brushes.Red;
                resultsLb.Items.Add(lbItem);
            }
        }
                
        private void CreateUsnJournal_Click(object sender, RoutedEventArgs e)
        {
            //_usnEntryDetail.Visibility = Visibility.Hidden;
            resultsLb.ItemsSource = null;
            resultsLb.Items.Clear();
            NtfsUsnJournal.UsnJournalReturnCode rtn = _usnJournal.CreateUsnJournal(1000*1024, 16*1024);

            //FunctionElapsedTime.Content = string.Format("Create->{0} elapsed time {1}(ms)",
            //    "CreateUsnJournal()", NtfsUsnJournal.ElapsedTime.Milliseconds.ToString());

            if (rtn == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Foreground = Brushes.Black;
                lbItem.Content = string.Format("Dziennik został pomyślnie utworzony.", rtn.ToString());
                resultsLb.Items.Add(lbItem);
            }
            else
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = string.Format("Błąd przy tworzeniu dziennika.");
                lbItem.Foreground = Brushes.Red;
                resultsLb.Items.Add(lbItem);
            }
        }

        private void DeleteUsnJournal_Click(object sender, RoutedEventArgs e)
        {
            resultsLb.ItemsSource = null;
            resultsLb.Items.Clear();
            NtfsUsnJournal.UsnJournalReturnCode rtn;
            if (_usnCurrentJournalState.UsnJournalID == 0)
            {
                Win32Api.USN_JOURNAL_DATA journalState = new Win32Api.USN_JOURNAL_DATA();
                rtn = _usnJournal.GetUsnJournalState(ref journalState);
                if (rtn != NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
                {
                    ListBoxItem lbItem = new ListBoxItem();
                    lbItem.Content = string.Format("Błąd przy usuwaniu dziennika.");
                    lbItem.Foreground = Brushes.Red;
                    resultsLb.Items.Add(lbItem);
                    return;
                }
                else
                {
                    _usnCurrentJournalState = journalState;
                }
            }

            rtn = _usnJournal.DeleteUsnJournal(_usnCurrentJournalState);

            //FunctionElapsedTime.Content = string.Format("Delete->{0} elapsed time {1}(ms)",
            //    "DeleteUsnJournal()", NtfsUsnJournal.ElapsedTime.Milliseconds.ToString());

            if (rtn == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Foreground = Brushes.Black;
                lbItem.Content = string.Format("Dziennik pomyślnie usunięty.");
                resultsLb.Items.Add(lbItem);
            }
            else
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = string.Format("Błąd przy usuwaniu dziennika.");
                lbItem.Foreground = Brushes.Red;
                resultsLb.Items.Add(lbItem);
            }
        }

        private void SaveUsnState_Click(object sender, RoutedEventArgs e)
        {
            //_usnEntryDetail.Visibility = Visibility.Hidden;
            resultsLb.ItemsSource = null;
            resultsLb.Items.Clear();
            Win32Api.USN_JOURNAL_DATA journalState = new Win32Api.USN_JOURNAL_DATA();
            NtfsUsnJournal.UsnJournalReturnCode rtn = _usnJournal.GetUsnJournalState(ref journalState);

            FunctionElapsedTime.Content = string.Format("Stan zachowany. Kliknij na 'Zobacz zmiany' po jakiejkolwiek operacji na pliku.");

            if (rtn == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                _usnCurrentJournalState = journalState;
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Foreground = Brushes.Black;
                lbItem.Content = FormatUsnJournalState(journalState);
                resultsLb.Items.Add(lbItem);
            }
            else
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = string.Format("Nastąpił błąd przy zachowaniu zmian.");
                lbItem.Foreground = Brushes.Red;
                resultsLb.Items.Add(lbItem);
            }
        }

        private void ViewUsnChanges_Click(object sender, RoutedEventArgs e)
        {
            if (_usnCurrentJournalState.UsnJournalID != 0)
            {
                resultsLb.ItemsSource = null;
                resultsLb.Items.Clear();

                Thread usnJournalThread = new Thread(ViewChangesThreadStart);
                Cursor = Cursors.Wait;
                usnJournalThread.Start();
            }
            else
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = string.Format("Musisz wpierw zachować stan, bo później zobaczyć zmiany.");
                lbItem.Foreground = Brushes.Red;
                resultsLb.Items.Add(lbItem);
            }
        }

        private void ViewChangesThreadStart()
        {
            uint reasonMask = Win32Api.USN_REASON_DATA_OVERWRITE |
                    Win32Api.USN_REASON_DATA_EXTEND |
                    Win32Api.USN_REASON_NAMED_DATA_OVERWRITE |
                    Win32Api.USN_REASON_NAMED_DATA_TRUNCATION |
                    Win32Api.USN_REASON_FILE_CREATE |
                    Win32Api.USN_REASON_FILE_DELETE |
                    Win32Api.USN_REASON_EA_CHANGE |
                    Win32Api.USN_REASON_SECURITY_CHANGE |
                    Win32Api.USN_REASON_RENAME_OLD_NAME |
                    Win32Api.USN_REASON_RENAME_NEW_NAME |
                    Win32Api.USN_REASON_INDEXABLE_CHANGE |
                    Win32Api.USN_REASON_BASIC_INFO_CHANGE |
                    Win32Api.USN_REASON_HARD_LINK_CHANGE |
                    Win32Api.USN_REASON_COMPRESSION_CHANGE |
                    Win32Api.USN_REASON_ENCRYPTION_CHANGE |
                    Win32Api.USN_REASON_OBJECT_ID_CHANGE |
                    Win32Api.USN_REASON_REPARSE_POINT_CHANGE |
                    Win32Api.USN_REASON_STREAM_CHANGE |
                    Win32Api.USN_REASON_CLOSE;

            Win32Api.USN_JOURNAL_DATA newUsnState;
            List<Win32Api.UsnEntry> usnEntries;
            NtfsUsnJournal.UsnJournalReturnCode rtnCode = _usnJournal.GetUsnJournalEntries(_usnCurrentJournalState, reasonMask, out usnEntries, out newUsnState);
            Dispatcher.Invoke(new FillListBoxDelegate(FillListBoxWithUsnEntries), rtnCode, usnEntries, newUsnState);
        }

        private void FillListBoxWithUsnEntries(NtfsUsnJournal.UsnJournalReturnCode rtnCode, List<Win32Api.UsnEntry> usnEntries, Win32Api.USN_JOURNAL_DATA newUsnState)
        {
            //FunctionElapsedTime.Content = string.Format("'View Changes'->{0} elapsed time {1}(ms)",
            //    "GetUsnJournalEntries()", NtfsUsnJournal.ElapsedTime.Milliseconds.ToString());

            if (rtnCode == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS)
            {
                if (usnEntries.Count > 0)
                {
                    _entryDetail = EntryDetail.UsnEntry;
                    resultsLb.ItemsSource = usnEntries;

                    _usnCurrentJournalState = newUsnState;
                }
                else
                {
                    ListBoxItem lbItem = new ListBoxItem();
                    lbItem.Content = string.Format("");//'View Changes'-> No Journal entries found
                    lbItem.Foreground = Brushes.Red;
                    resultsLb.Items.Add(lbItem);
                }
            }
            else
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = string.Format("");//'View Changes'->{0} returned error code: {1}", "GetUsnJournalEntries()", rtnCode.ToString());
                lbItem.Foreground = Brushes.Red;
                resultsLb.Items.Add(lbItem);
            }
            Cursor = Cursors.Arrow;
        }
                
        private void resultsLb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedItem != null)
            {
                if (lb.SelectedItem.GetType() == typeof(Win32Api.UsnEntry))
                {
                    Win32Api.UsnEntry item = (Win32Api.UsnEntry)lb.SelectedItem;
                    //_usnEntryDetail.ChangeDisplay(_lbItemY, _lbItemX, item, _entryDetail);
                    
                    MainWindow mainWin = (MainWindow)Application.Current.MainWindow;
                    NtfsUsnJournal usnJournal = mainWin.Journal;
                    StringBuilder sb = new StringBuilder();
                    if (item.IsFolder)
                    {
                        sb.AppendFormat("Katalog: {0}", item.Name);
                    }
                    else if (item.IsFile)
                    {
                        sb.AppendFormat("Plik: {0}", item.Name);
                    }
                    label3.Content = sb.ToString();
                    sb = new StringBuilder();
                    string path;
                    NtfsUsnJournal.UsnJournalReturnCode usnRtnCode = usnJournal.GetPathFromFileReference(item.ParentFileReferenceNumber, out path);
                    if (usnRtnCode == NtfsUsnJournal.UsnJournalReturnCode.USN_JOURNAL_SUCCESS && 0 != string.Compare(path, "Unavailable", true))
                    {
                        sb.AppendFormat("  Ścieżka:    {0}{1}\\", usnJournal.VolumeName.TrimEnd('\\'), path);
                    }
                    else
                    {
                        sb.AppendFormat("  Ścieżka:    {0}", path);
                    }
                    label1.Content = sb.ToString();
                    sb = new StringBuilder();
                    sb.AppendFormat("   Id pliku: {0}", item.FileReferenceNumber);
                    sb.AppendFormat("\n   Id Rodzica: {0}", item.ParentFileReferenceNumber);
                    
                    if ( _entryDetail == EntryDetail.UsnEntry)
                    {
                        sb.AppendFormat("\n  Długość: {0}", item.RecordLength);
                        sb.AppendFormat("\n  USN:     {0}", item.USN);
                        AddReasonData(sb, item);
                    }
                    if (item.IsFile)
                    {
                        string fullPath = System.IO.Path.Combine(path, item.Name);
                        if (File.Exists(fullPath))
                        {
                            FileInfo fi = new FileInfo(fullPath);
                            sb.AppendFormat("\n  Długość pl.:   {0} (bytes)", fi.Length);
                            sb.AppendFormat("\n  Czas utworz.:  {0} - {1}", fi.CreationTime.ToShortDateString(), fi.CreationTime.ToShortTimeString());
                            sb.AppendFormat("\n  Ost. modyf.:   {0} - {1}", fi.LastWriteTime.ToShortDateString(), fi.LastWriteTime.ToShortTimeString());
                            sb.AppendFormat("\n  Ost. dost.:    {0} - {1}", fi.LastAccessTime.ToShortDateString(), fi.LastAccessTime.ToShortTimeString());
                        }
                    }
                    label2.Content = sb.ToString();
                    Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_usnEntryDetail = new UsnEntryDetail(this);
        }

        #endregion

        private void AddReasonData(StringBuilder sb, Win32Api.UsnEntry usnEntry)
        {
            sb.AppendFormat("\n  Powody zmian:");
            uint value = usnEntry.Reason & Win32Api.USN_REASON_DATA_OVERWRITE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -DATA OVERWRITE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_DATA_EXTEND;
            if (0 != value)
            {
                sb.AppendFormat("\n     -DATA EXTEND");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_DATA_TRUNCATION;
            if (0 != value)
            {
                sb.AppendFormat("\n     -DATA TRUNCATION");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_NAMED_DATA_OVERWRITE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -NAMED DATA OVERWRITE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_NAMED_DATA_EXTEND;
            if (0 != value)
            {
                sb.AppendFormat("\n     -NAMED DATA EXTEND");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_NAMED_DATA_TRUNCATION;
            if (0 != value)
            {
                sb.AppendFormat("\n     -NAMED DATA TRUNCATION");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_FILE_CREATE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -FILE CREATE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_FILE_DELETE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -FILE DELETE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_EA_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -EA CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_SECURITY_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -SECURITY CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_RENAME_OLD_NAME;
            if (0 != value)
            {
                sb.AppendFormat("\n     -RENAME OLD NAME");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_RENAME_NEW_NAME;
            if (0 != value)
            {
                sb.AppendFormat("\n     -RENAME NEW NAME");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_INDEXABLE_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -INDEXABLE CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_BASIC_INFO_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -BASIC INFO CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_HARD_LINK_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -HARD LINK CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_COMPRESSION_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -COMPRESSION CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_ENCRYPTION_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -ENCRYPTION CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_OBJECT_ID_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -OBJECT ID CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_REPARSE_POINT_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -REPARSE POINT CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_STREAM_CHANGE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -STREAM CHANGE");
            }
            value = usnEntry.Reason & Win32Api.USN_REASON_CLOSE;
            if (0 != value)
            {
                sb.AppendFormat("\n     -CLOSE");
            }
        }

        #region Formating functions

        private string FormatUsnJournalState(Win32Api.USN_JOURNAL_DATA _usnCurrentJournalState)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Zmiany zostały zachowane. Kliknij na 'Zobacz zmiany'.");
            return sb.ToString();
        }

        #endregion
    }
}
