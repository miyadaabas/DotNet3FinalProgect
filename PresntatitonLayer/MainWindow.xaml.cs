using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ILogicLayer;
using LogicLayer;
using DataObjectsLayer;

namespace PresntatitonLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEmployeeManager _employeeManager;
        private List<Employee> employees = null;
        private List<Bike> bikes = null;
        private IBikeManager bikeManager;
        private IClientManager clientManager;
        public MainWindow()
        {
            InitializeComponent();
            _employeeManager = new EmployeeManager();
            bikeManager = new BikeManager();
            clientManager = new ClientManager();
            HideAllTabs();
        }

        private void HideAllTabs()
        {
            tcAdmin.Visibility = Visibility.Hidden;
            tcManager.Visibility = Visibility.Hidden;
            tcProcess.Visibility = Visibility.Hidden;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "Login")
            {
                string email = txtEmail.Text;
                string password = txtPassword.Password.ToString();
                bool isEmailValid = validateEmail(email);
                if (isEmailValid)
                {
                    lblErrorLogin.Content = "email is valid";
                }
                else
                {
                    lblErrorLogin.Content = "email not valid";
                    return;
                }
                bool isPasswordValid = validatePassword(password);
                if (isPasswordValid)
                {
                    int employeeId = _employeeManager.verifyUser(email, password);
                    if (employeeId != 0)
                    {
                        string role = _employeeManager.getEmployeeRole(employeeId);
                        lblErrorLogin.Content = role;
                        showTab(role);
                        hidLoginElement();
                    }
                    else
                    {
                        lblErrorLogin.Content = "data is valid but use is not verify";
                        return;
                    }
                }
                else
                {
                    lblErrorLogin.Content = "password not valid";
                    return;
                }
            }
            else
            {
                showLoginElements();
            }
            
            


        }

        private void showLoginElements()
        {
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;
            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            btnLogin.Content = "Login";
            tcAdmin.Visibility = Visibility.Hidden;
            tcManager.Visibility = Visibility.Hidden;
            tcProcess.Visibility = Visibility.Hidden;
            lblErrorLogin.Content = "";
        }

        private void hidLoginElement()
        {
            lblEmail.Visibility = Visibility.Hidden; 
            lblPassword.Visibility = Visibility.Hidden;
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            txtEmail.Text = "";
            txtPassword.Password = "";
            btnLogin.Content = "Logout";

        }

        private void showTab(string role)
        {
           if (role == "Admin")
            {
                tcAdmin.Visibility = Visibility.Visible;
                tcManager.Visibility = Visibility.Hidden;
                tcProcess.Visibility = Visibility.Hidden;
                employees = new List<Employee>();
                employees = _employeeManager.getAllEmployees();
                dataGridEmployees.ItemsSource = employees;
            }
            else if (role == "Manager")
            {
                tcAdmin.Visibility = Visibility.Hidden;
                tcManager.Visibility = Visibility.Visible;
                tcProcess.Visibility = Visibility.Hidden;
                bikes = new List<Bike>();
                bikes = bikeManager.getAllBikes();
                dataGridManager.ItemsSource = bikes;
            }
            else if (role == "process")
            {
                tcAdmin.Visibility = Visibility.Hidden;
                tcManager.Visibility = Visibility.Hidden;
                tcProcess.Visibility = Visibility.Visible;
                showAllClients();
            }
        }

        private bool validatePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return false;
            return true;
        }

        private bool validateEmail(string email)
        {
            if (!email.Contains('@') || !email.Contains('.'))
            {
                return false;
            }
            return true;
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            FrmEmployee frmEmployee = new FrmEmployee();
            frmEmployee.ShowDialog();
            employees = new List<Employee>();
            employees = _employeeManager.getAllEmployees();
            dataGridEmployees.ItemsSource = employees;
        }

        private void dataGridEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)dataGridEmployees.SelectedItem;
            FrmEmployee frmEmployee = new FrmEmployee(employee);
            frmEmployee.ShowDialog();
            employees = new List<Employee>();
            employees = _employeeManager.getAllEmployees();
            dataGridEmployees.ItemsSource = employees;

        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridEmployees.SelectedItem == null)
            {
                lblEmployeeMessage.Content = "select the employee first";
            }
            else
            {
                lblEmployeeMessage.Content = "";
                Employee employee = (Employee)dataGridEmployees.SelectedItem;
                int result = _employeeManager.deleteEmployee(employee);
                if (result == 0)
                {
                    lblEmployeeMessage.Content = "delete did not goes well, try again";
                    return;
                }
                lblEmployeeMessage.Content = "";
                employees = new List<Employee>();
                employees = _employeeManager.getAllEmployees();
                dataGridEmployees.ItemsSource = employees;
            }
        }

        private void btnAddBike_Click(object sender, RoutedEventArgs e)
        {
            FrmBike frmBike = new FrmBike();
            frmBike.ShowDialog();
            bikes = new List<Bike>();
            bikes = bikeManager.getAllBikes();
            dataGridManager.ItemsSource = bikes;
        }

        private void dataGridManager_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bike bike = new Bike();
            bike = (Bike) dataGridManager.SelectedItem;
            FrmBike frmBike = new FrmBike(bike);
            frmBike.ShowDialog();
            bikes = new List<Bike>();
            bikes = bikeManager.getAllBikes();
            dataGridManager.ItemsSource = bikes;
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            FrmClient frmClient = new FrmClient();
            frmClient.ShowDialog();
            showAllClients();
        }

        private void showAllClients()
        {
            List<Client> clients = new List<Client>();
            clients = clientManager.getAllClients();
            dataGridProcess.ItemsSource = clients;
        }

        private void dataGridProcess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Client client = new Client();
            client = (Client)dataGridProcess.SelectedItem;
            FrmClient frmClient = new FrmClient(client);
            frmClient.ShowDialog();
            showAllClients();
        }
    }
}
