using LogicLayer;
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
using IDataAccessLayer;
using ILogicLayer;

namespace PresntatitonLayer
{
    /// <summary>
    /// Interaction logic for FrmEmployee.xaml
    /// </summary>
    public partial class FrmEmployee : Window
    {
        private IEmployeeManager employeeManager = new EmployeeManager();
        private Employee employee = null;
        private string title = "";

        public FrmEmployee()
        {
            InitializeComponent();
            employee = new Employee();
            title = "New";
        }

        public FrmEmployee(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            fillForm();
            title = "Update";
        }

        private void fillForm()
        {
            txtFirstName.Text = employee.Firstname;
            txtLastName.Text = employee.Lastname;
            txtSSN.Text = employee.SSN;
            txtLine1.Text = employee.Line1;
            txtLine2.Text = employee.Line2;
            txtCity.Text = employee.City;
            txtState.Text = employee.State;
            txtState.Text = employee.State;
            txtCounty.Text = employee.County;
            txtZipcode.Text = employee.Zipcode;
            txtRole.Text = employee.Role_id;
            txtAccountNumber.Text = employee.AccountNumber;
            txtRountinNumber.Text = employee.RoutinNumber;
            txtBankName.Text = employee.bankName;
            txtSalaryAmount.Text = employee.salaryAmount;
            txtSalaryType.Text = employee.salaryType;
            txtEmail.Text = employee.email;
            txtPassword.Text = employee.passwordHash;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!formValid())
            {
                return;
            }
            int result = 0;
            employee.Firstname = txtFirstName.Text;
            employee.Lastname = txtLastName.Text;
            employee.SSN = txtSSN.Text;
            employee.Line1 = txtLine1.Text;
            employee.Line2 = txtLine2.Text;
            employee.City = txtCity.Text;
            employee.State = txtState.Text;
            employee.County = txtCounty.Text;
            employee.Zipcode = txtZipcode.Text;
            employee.Role_id = txtRole.Text;
            employee.AccountNumber = txtAccountNumber.Text;
            employee.RoutinNumber = txtRountinNumber.Text;
            employee.bankName = txtBankName.Text;
            employee.salaryType = txtSalaryType.Text;
            employee.salaryAmount = txtSalaryAmount.Text;
            employee.email = txtEmail.Text;
            employee.passwordHash = txtPassword.Text;
            if (title == "New")
            {
                result = employeeManager.addEmployee(employee);
            }
            else
            {
                result = employeeManager.editEmployee(employee);
            }
            
            if (result == 0)
            {
                lblFormMessage.Content = "There is an error, please try again";
                return;
            }
            else {
                lblFormMessage.Content = "new employee added correctly";
            }
        }

        private bool formValid()
        {
            if (txtFirstName.Text.Length == 0)
            {
                lblFormMessage.Content = "first name is require";
                return false;
            }
            if (txtLastName.Text.Length == 0)
            {
                lblFormMessage.Content = "last name is require";
                return false;
            }
            if (txtSSN.Text.Length == 0)
            {
                lblFormMessage.Content = "social number is require";
                return false;
            }
            if (txtLine1.Text.Length == 0)
            {
                lblFormMessage.Content = "line 1 is require";
                return false;
            }
            if (txtCity.Text.Length == 0)
            {
                lblFormMessage.Content = "city is require";
                return false;
            }
            if (txtState.Text.Length == 0)
            {
                lblFormMessage.Content = "state is require";
                return false;
            }
            if (txtCounty.Text.Length == 0)
            {
                lblFormMessage.Content = "county is require";
                return false;
            }
            if (txtZipcode.Text.Length == 0)
            {
                lblFormMessage.Content = "Zipcode is require";
                return false;
            }
            if (txtRole.Text.Length == 0)
            {
                lblFormMessage.Content = "role require";
                return false;
            }
            if (txtAccountNumber.Text.Length == 0) {
                lblFormMessage.Content = "account number is require";
                return false;
            }
            if (txtRountinNumber.Text.Length == 0)
            {
                lblFormMessage.Content = "routing number is require";
                return false;
            }
            if (txtBankName.Text.Length == 0)
            {
                lblFormMessage.Content = "bank number is require";
                return false;
            }
            if (txtSalaryType.Text.Length == 0)
            {
                lblFormMessage.Content = "salary type is require";
                return false;
            }
            if (txtSalaryAmount.Text.Length == 0)
            {
                lblFormMessage.Content = "What is the salary amount";
                return false;
            }
            if (txtEmail.Text.Length == 0)
            {
                lblFormMessage.Content = "please enter your email";
                return false;
            }
            if (txtPassword.Text.Length == 0)
            {
                lblFormMessage.Content = "password require";
                return false;
            }
            lblFormMessage.Content = "";
            return true;
        }
    }
}
