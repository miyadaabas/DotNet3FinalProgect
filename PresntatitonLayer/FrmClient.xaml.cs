using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using LogicLayer;
using ILogicLayer;
using DataObjectsLayer;

namespace PresntatitonLayer
{
    /// <summary>
    /// Interaction logic for FrmClient.xaml
    /// </summary>
    public partial class FrmClient : Window
    {
        private IClientManager _clientManager;
        private Client client;
        private bool isUpdate;
        private List<Bike> bikes = new List<Bike>();
        private IBikeManager bikeManager;
        public FrmClient()
        {
            InitializeComponent();
            _clientManager = new ClientManager();
            client = new Client();
            isUpdate = false;
            bikeManager = new BikeManager();
            bikes = bikeManager.getAllBikes();
            fillBikeCombo();
        }

        public FrmClient(Client client)
        {
            InitializeComponent();
            _clientManager = new ClientManager();
            this.client = client;
            fillFormByClientData();
            isUpdate = true;
            bikeManager = new BikeManager();
            bikes = bikeManager.getAllBikes();
            fillBikeCombo();
        }

        private void fillBikeCombo()
        {
            List<string> bikesIDs = new List<string>();
            foreach (Bike bike in bikes)
            {
                bikesIDs.Add(bike.ID.ToString());
            }
            comboBikeID.ItemsSource = bikesIDs;
            comboBikeID.SelectedIndex = 0;
        }

        private void fillFormByClientData()
        {
            txtFirstName.Text = client.client_first_name;
            txtLastName.Text = client.client_last_name;
            txtEmail.Text = client.email;
            txtPhone.Text = client.phone_number;
            txtLine1.Text = client.line1;
            txtLine2.Text = client.line2;
            txtCity.Text = client.city;
            txtState.Text = client.state;
            txtCounty.Text = client.county;
            txtZipcode.Text = client.zipcode;
            txtCountry.Text = client.country;
            txtRoutingNumber.Text = client.routing_number;
            txtAccountNumber.Text = client.account_number;
            txtBankName.Text = client.bank_name;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!validData())
            {
                return;
            }
            int result = 0;
            client.client_first_name = txtFirstName.Text;
            client.client_last_name = txtLastName.Text;
            client.email = txtEmail.Text;
            client.phone_number = txtPhone.Text;
            client.line1 = txtLine1.Text;
            client.line2 = txtLine2.Text;
            client.city = txtCity.Text;
            client.state = txtState.Text;
            client.county =txtCounty.Text;
            client.zipcode = txtZipcode.Text;
            client.country = txtCountry.Text;
            client.routing_number = txtRoutingNumber.Text;
            client.account_number = txtAccountNumber.Text;
            client.bank_name = txtBankName.Text;
            if (isUpdate == false)
            {
                result = _clientManager.add(client);
                clearForm();
            }
            else
            {
                result = _clientManager.update(client);
            }
            
            if (result == 0)
            {
                lblFormNote.Content = "Data did not goes right :(";
                return;
            }
            lblFormNote.Content = "Data goes right :)";
        }

        private void clearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtLine1.Text = "";
            txtLine2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtCounty.Text = "";
            txtZipcode.Text = "";
            txtCountry.Text = "";
            txtRoutingNumber.Text = "";
            txtAccountNumber.Text = "";
            txtBankName.Text = "";
        }

        private bool validData()
        {
            if (txtFirstName.Text.Length == 0)
            {
                lblFormNote.Content = "first name is require";
                return false;
            }
            if (txtLastName.Text.Length == 0)
            {
                lblFormNote.Content = "Last name is require";
                return false;
            }
            if (txtEmail.Text.Length == 0)
            {
                lblFormNote.Content = "Email is require";
                return false;
            }
            if (txtPhone.Text.Length == 0)
            {
                lblFormNote.Content = "Phone is require";
                return false;
            }
            if (txtLine1.Text.Length == 0)
            {
                lblFormNote.Content = "Line 1 is require";
                return false;
            }
            if (txtLine2.Text.Length == 0)
            {
                //lblFormNote.Content = "first name is require";
                //return false;
            }
            if (txtCity.Text.Length == 0)
            {
                lblFormNote.Content = "City is require";
                return false;
            }
            if (txtState.Text.Length == 0)
            {
                lblFormNote.Content = "State is require";
                return false;
            }
            if (txtCounty.Text.Length == 0)
            {
                lblFormNote.Content = "County is require";
                return false;
            }
            if (txtZipcode.Text.Length == 0)
            {
                lblFormNote.Content = "Zipcode is require";
                return false;
            }
            if (txtCountry.Text.Length == 0)
            {
                lblFormNote.Content = "Country is require";
                return false;
            }
            if (txtRoutingNumber.Text.Length == 0)
            {
                lblFormNote.Content = "Routing Number is require";
                return false;
            }
            if (txtAccountNumber.Text.Length == 0)
            {
                lblFormNote.Content = "Account Number is require";
                return false;
            }
            if (txtBankName.Text.Length == 0)
            {
                lblFormNote.Content = "Bank name is require";
                return false;
            }
            
            lblFormNote.Content = "";
            return true;
        }

        private void btnBuyBike_Click(object sender, RoutedEventArgs e)
        {
            if (txtPrice.Text.Length == 0)
            {
                lblBuyBikeMessage.Content = "Price require";
                return;
            }
            lblBuyBikeMessage.Content = "";
            int result = 0;
            Bike bike = new Bike();
            bike.ID = Convert.ToInt32(comboBikeID.SelectedItem);
            bike.Price = txtPrice.Text;
            if (this.client == null || this.client.client_id <= 0)
            {
                lblBuyBikeMessage.Content = "please click submit first";
                return;
            }
            result = _clientManager.buyBike(bike, this.client);
            if (result == 0) {
                lblBuyBikeMessage.Content = "Did not goes will";
                return;
            }
            lblBuyBikeMessage.Content = "Bike is buy";

        }
    }
}
