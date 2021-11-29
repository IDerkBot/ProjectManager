using System.Windows;
using System.Windows.Input;

namespace ProjectManager
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			PageManager.Page = MainFrame;
			PageManager.Page.Navigate(new Pages.Auth());
		}
		void Close_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
		Point mouseStartPosition;
		Point mousePosition;
		bool isPressed = false;
		void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			isPressed = true;
			mouseStartPosition = e.GetPosition(this);
		}
		void TopBar_MouseUp(object sender, MouseButtonEventArgs e)
		{
			isPressed &= !isPressed;
		}
		void Window_MouseMove(object sender, MouseEventArgs e)
		{
			if (isPressed)
			{
				mousePosition = e.GetPosition(this);
				Left = Left + mousePosition.X - mouseStartPosition.X;
				Top = Top + mousePosition.Y - mouseStartPosition.Y;
			}
		}
	}
}