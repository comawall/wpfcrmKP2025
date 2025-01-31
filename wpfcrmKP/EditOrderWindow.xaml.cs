using System.Windows;

namespace wpfcrmKP
{
    public partial class EditOrderWindow : Window
    {
        private Order _order; 

        public EditOrderWindow(Order order)
        {
            InitializeComponent();
            _order = order;

            OrderNumberBox.Text = _order.OrderNumber;
            ItemCountBox.Text = _order.ItemCount;
            TimeBox.Text = _order.Time;
            DishCodeBox.Text = _order.DishCode;
            PickupMethodBox.Text = _order.PickupMethod;
        }

        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(OrderNumberBox.Text) || string.IsNullOrEmpty(ItemCountBox.Text) ||
                string.IsNullOrEmpty(TimeBox.Text) || string.IsNullOrEmpty(DishCodeBox.Text) ||
                string.IsNullOrEmpty(PickupMethodBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            _order.OrderNumber = OrderNumberBox.Text;
            _order.ItemCount = ItemCountBox.Text;
            _order.Time = TimeBox.Text;
            _order.DishCode = DishCodeBox.Text;
            _order.PickupMethod = PickupMethodBox.Text;

            this.DialogResult = true;
            this.Close();
        }
    }
}
