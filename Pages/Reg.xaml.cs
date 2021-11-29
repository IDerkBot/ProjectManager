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
using ProjectManager.Classes;
using ProjectManager.Pages;
using ProjectManager.Entities;

namespace ProjectManager.Pages
{
	/// <summary>
	/// Interaction logic for Reg.xaml
	/// </summary>
	public partial class Reg : Page
	{
		public Reg() => InitializeComponent();

		void Regin_Click(object sender, RoutedEventArgs e)
		{
			StringBuilder errors = new StringBuilder();
			if (!string.IsNullOrWhiteSpace(Login.Text))
			{
				if (!string.IsNullOrWhiteSpace(Password.Password))
				{
					if (!string.IsNullOrWhiteSpace(Confrim_Password.Password))
					{
						if(!ProjectManagerEntities.GetContext().Users.Where(user => user.Login == Login.Text).Any())
						{
							if(Password.Password == Confrim_Password.Password)
							{
								if (PasswordChecker.PasswordValidete(Password.Password))
								{
									User user = new User
									{
										Login = Login.Text,
										Password = Crypt.ToSHA256(Password.Password),
										Access = 0
									};
									ProjectManagerEntities.GetContext().Users.Add(user);
									ProjectManagerEntities.GetContext().SaveChanges();
									User loadUser = ProjectManagerEntities.GetContext().Users.Where(u => u.Login == Login.Text).First();
									UserInfo userInfo = new UserInfo
									{
										User = loadUser
									};
									ProjectManagerEntities.GetContext().UserInfoes.Add(userInfo);
									ProjectManagerEntities.GetContext().SaveChanges();
								}
							}
							else errors.Append("Пароли не совпадают");
						}
						else errors.Append("Такой пользователь уже существует");
					}
					else errors.Append("Вы не повторный пароль");
				}
				else errors.Append("Вы не ввели пароль");
			}
			else errors.Append("Вы не ввели логин");

			if (errors.Length > 0) MessageBox.Show(errors.ToString());
		}
	}
}