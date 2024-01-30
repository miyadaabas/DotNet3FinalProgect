using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataObjectsLayer;
using LogicLayer;
using ILogicLayer;

namespace PresntatitonLayer
{
    /// <summary>
    /// Interaction logic for FrmBike.xaml
    /// </summary>
    public partial class FrmBike : Window
    {
        private Bike bike;
        private IBikeManager bikeManager;
        private bool isEdit = false;
        public FrmBike()
        {
            InitializeComponent();
            bike = new Bike();
            bikeManager = new BikeManager();
            isEdit = false;
        }

        public FrmBike(Bike bike)
        {
            InitializeComponent();
            this.bike = bike;
            bikeManager = new BikeManager();
            fillForm();
            isEdit = true;
        }

        private void fillForm()
        {
            txtName.Text = bike.Name;
            txtType.Text = bike.Type;
            txtPrice.Text = bike.Price;
            txtQuality.Text = bike.Quality;
            txtModel.Text = bike.Model;
            txtTotal.Text = bike.Total.ToString();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validateFormData())
            {
                return;
            }
            int result = 0;
            bike.Name = txtName.Text;
            bike.Type = txtType.Text;
            bike.Price = txtPrice.Text;
            bike.Quality = txtQuality.Text;
            bike.Model = txtModel.Text;
            bike.Total = Convert.ToInt32(txtTotal.Text);
            if (isEdit) {
                result = bikeManager.edit(bike);
            }
            else
            {
                result = bikeManager.addBike(bike);
            }
           
            if (result == 0)
            {
                lblFormError.Content = "bike did not added";
                return;
            }
            lblFormError.Content = "bike added";
            clearForm();
        }

        private void clearForm()
        {
            txtName.Text = "";
            txtType.Text = "";
            txtPrice.Text = "";
            txtQuality.Text = "";
            txtModel.Text = "";
            txtTotal.Text = "";
        }

        private bool validateFormData()
        {
            if (txtName.Text.Length == 0)
            {
                lblFormError.Content = "Name is require";
                return false;
            }
            if (txtType.Text.Length == 0)
            {
                lblFormError.Content = "Type is require";
                return false;
            }
            if (txtPrice.Text.Length == 0)
            {
                lblFormError.Content = "Price is require";
                return false;
            }
            if (txtQuality.Text.Length == 0)
            {
                lblFormError.Content = "Quality is require";
                return false;
            }
            if (txtModel.Text.Length == 0)
            {
                lblFormError.Content = "Model is require";
                return false;
            }
            if (txtTotal.Text.Length == 0)
            {
                lblFormError.Content = "Total is require";
                return false;
            }
            lblFormError.Content = "";
            return true;
        }
    }
}
