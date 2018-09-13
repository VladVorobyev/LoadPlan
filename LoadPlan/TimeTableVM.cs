using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Runtime.CompilerServices;

namespace LoadPlan
{
    class TimeTableVM:INotifyPropertyChanged
    {
        TimeTableModel _model = new TimeTableModel();
        IDialogService _dialogService=new DefaultDialogService();
        ExcelFileService _fileService = new ExcelFileService();
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (_dialogService.SaveFileDialog() == true)
                          {
                              _fileService.Save(_dialogService.FilePath, _model.OperationCollection.ToList());
                              _dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        public ObservableCollection<Operation> Operations
        {
            get
            {
                return _model.OperationCollection;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public void SaveData(object sender, RoutedEventArgs e)
        {

        }
    }
}
