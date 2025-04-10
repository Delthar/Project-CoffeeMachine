using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Project_CoffeeMachine
{
    [Serializable]
    internal class CoffeeMachineViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Int32> fillAmounts = new ObservableCollection<Int32>(new Amounts().FillAmounts);
        private CoffeeMachine coffeeMachine = new CoffeeMachine();

        private Int32 selectedAmount;

        public int CurrentWaterAmount
        {
            get => coffeeMachine.currentWaterAmount;
            set
            {
                coffeeMachine.currentWaterAmount = value;
                UpdateStatus();
            }
        }

        public int CurrentCoffeeAmount
        {
            get => coffeeMachine.currentCoffeeAmount;
            set
            {
                coffeeMachine.currentCoffeeAmount = value;
                UpdateStatus();
            }
        }

        public int CupsBrewed
        {
            get => coffeeMachine.cupsBrewed;
            set
            {
                coffeeMachine.cupsBrewed = value;
                UpdateStatus();
            }
        }

        public String Status
        {
            get => coffeeMachine.status;
            set
            {
                coffeeMachine.status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public String Message
        {
            get => coffeeMachine.message;
            set
            {
                coffeeMachine.message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public Int32 SelectedAmount
        {
            get => selectedAmount;
            set
            {
                selectedAmount = value;
                OnPropertyChanged(nameof(SelectedAmount));
            }
        }

        public ObservableCollection<Int32> FillAmounts
        {
            get => fillAmounts;
            set
            {
                fillAmounts = value;
                OnPropertyChanged(nameof(FillAmounts));
            }
        }

        public CoffeeMachineViewModel()
        {
            UpdateStatus();
            Message = $"The machine is ready to use.";
        }

        private void OnPropertyChanged(String propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void BrewCoffee(object sender, RoutedEventArgs e)
        {
            if (CupsBrewed >= CoffeeMachine.maximumCupsBeforeCleaning)
            {
                Message = $"The machine needs to be cleaned!";
            }
            else if (CurrentWaterAmount >= CoffeeMachine.waterPerCup && CurrentCoffeeAmount >= CoffeeMachine.coffeePerCup)
            {
                CurrentWaterAmount -= CoffeeMachine.waterPerCup;
                CurrentCoffeeAmount -= CoffeeMachine.coffeePerCup;
                CupsBrewed++;

                Message = $"Coffee has been successfully brewed.";
            }
            else
            {
                Message = $"The machine needs to be refilled!";
            }
        }

        public void FillWater(object sender, RoutedEventArgs e, int fillAmount)
        {
            if (CurrentWaterAmount + fillAmount >= CoffeeMachine.maximumWaterCapacity)
            {
                CurrentWaterAmount = CoffeeMachine.maximumWaterCapacity;
            }
            else
            {
                CurrentWaterAmount += fillAmount;
            }

            Message = $"Water has been refilled.";
        }

        public void FillCoffee(object sender, RoutedEventArgs e, int fillAmount)
        {
            if (CurrentCoffeeAmount + fillAmount >= CoffeeMachine.maximumCoffeeCapacity)
            {
                CurrentCoffeeAmount = CoffeeMachine.maximumCoffeeCapacity;
            }
            else
            {
                CurrentCoffeeAmount += fillAmount;
            }

            Message = $"Coffee has been refilled.";
        }

        public void Clean(object sender, RoutedEventArgs e)
        {
            if (CoffeeMachine.maximumCupsBeforeCleaning - CupsBrewed >= 12)
            {
                Message = $"The machine is already clean";
            }
            else
            {
                CupsBrewed = 0;
                Message = $"The machine has been cleaned";
            }
        }

        public void Exit(object sender, RoutedEventArgs e)
        {
            
        }

        public void UpdateStatus()
        {
            Status = $"Informationen\n" +
                     $"----------------------------------\n" +
                     $"Water Amount: {coffeeMachine.currentWaterAmount}/{CoffeeMachine.maximumWaterCapacity} ml\n" +
                     $"Coffee Amount: {coffeeMachine.currentCoffeeAmount} / {CoffeeMachine.maximumCoffeeCapacity} g\n" +
                     $"Cups brewed: {coffeeMachine.cupsBrewed}\n" +
                     $"Cups until cleaning: {CoffeeMachine.maximumCupsBeforeCleaning - coffeeMachine.cupsBrewed}";
        }

        /*
        public void SaveDataToFile(object data)
        {
            using (StreamWriter file = File.CreateText("CoffeeMachineData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }
        */

        /*
        private void LoadData()
        {
            using (StreamReader file = File.OpenText("CoffeeMachineData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                CoffeeMachineViewModel viewModel = (CoffeeMachineViewModel)serializer.Deserialize(file, typeof(CoffeeMachineViewModel));


                CurrentWaterAmount = viewModel.CurrentWaterAmount;
                CurrentCoffeeAmount = viewModel.CurrentCoffeeAmount;
                CupsBrewed = viewModel.CupsBrewed;

                Message = "Data loaded successfully.";
            }
        }
        */
    }
}
