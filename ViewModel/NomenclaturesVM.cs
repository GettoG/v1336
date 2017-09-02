using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using v1336.Rep;
using v1336.Model;

namespace v1336.ViewModel
{
    class NomenclaturesVM : ViewModelBase
    {
        private NomenclatureRep rep;
        public NomenclaturesVM()
        {
            rep = new NomenclatureRep();
        }

        Nomenclature _currentNomenclature;
        public Nomenclature CurrentNomenclature
        {
            get
            {
                if (_currentNomenclature == null)
                    _currentNomenclature = new Nomenclature();
                return _currentNomenclature;
            }
            set
            {
                _currentNomenclature = value;
                RaisePropertyChanged("CurrentNomenclature");
            }
        }

        private ObservableCollection<Nomenclature> _nomenclatures;
        public ObservableCollection<Nomenclature> Nomenclatures
        {
            get
            {
                if (_nomenclatures == null)
                {
                   // _nomenclatures = new ObservableCollection<Nomenclature>(rep.GetAll());
                    _nomenclatures.CollectionChanged += UpdateNomenclature;
                }
                return _nomenclatures;
            }

        }

        private void UpdateNomenclature(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Nomenclatures");
        }

        private RelayCommand _addNomenclatureCommand;
        public RelayCommand AddNomenclature
        {
            get
            {
                if (_addNomenclatureCommand == null)
                    _addNomenclatureCommand = new RelayCommand(ExecuteAddNomenclatureCommand, CanExecuteAddNomenclatureCommand);
                return _addNomenclatureCommand;
            }
        }
        public void ExecuteAddNomenclatureCommand()
        {
            rep.Add(CurrentNomenclature);
            CurrentNomenclature = null;
        }
        public bool CanExecuteAddNomenclatureCommand()
        {
            return !string.IsNullOrEmpty(CurrentNomenclature.Name);
            /*if (string.IsNullOrEmpty(CurrentNomenclature.Name))
                return false;
            return true;*/
        }

        private RelayCommand _deleteNomenclatureCommand;
        public RelayCommand DeleteNomenclature
        {
            get
            {
                if (_deleteNomenclatureCommand == null)
                    _deleteNomenclatureCommand = new RelayCommand(ExecuteDeleteNomenclatureCommand);
                return _deleteNomenclatureCommand;
            }
        }



        public void ExecuteDeleteNomenclatureCommand()
        {
            if (SelectedNomenclature == null || SelectedNomenclature.Id == 0) return;
            rep.Delete(SelectedNomenclature);
            CurrentNomenclature = null;
        }

        public Nomenclature SelectedNomenclature
        {
            get { return _currentNomenclature; }
            set
            {
                _currentNomenclature = value;
                RaisePropertyChanged("selectedNomenclature");
            }
        }

    }
}
