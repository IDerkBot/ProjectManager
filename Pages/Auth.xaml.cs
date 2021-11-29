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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectManager.Entities;
using ProjectManager.Classes;

namespace ProjectManager.Pages
{
	/// <summary>
	/// Interaction logic for Auth.xaml
	/// </summary>
	public partial class Auth : Page
	{
		public Auth()
		{
			InitializeComponent();
		}
		void Login_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();
			if (!string.IsNullOrWhiteSpace(Login.Text))
			{
				if (!string.IsNullOrWhiteSpace(Password.Password))
				{
					if (ProjectManagerEntities.GetContext().Users.Where(user => user.Login == Login.Text).Any())
					{
						string passHash = Crypt.ToSHA256(Password.Password);
						if (ProjectManagerEntities.GetContext().Users.Where(user => user.Login == Login.Text && user.Password == passHash).Any())
						{
							Data.User = ProjectManagerEntities.GetContext().Users.Where(user => user.Login == Login.Text && user.Password == passHash).First();
							PageManager.Page.Navigate(new Home());
						}
						else errors.Append("Вы ввели не верный пароль");
					}
					else errors.Append("Такого пользователя не существует");
				}
				else errors.Append("Вы не ввели пароль");
			}
			else errors.Append("Вы не ввели логин");

			if (errors.Length > 0) MessageBox.Show(errors.ToString());
		}
	}
}