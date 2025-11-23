namespace OrderPipeline
{
    public partial class Form1 : Form
    {
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler OrderRejected;
        public event EventHandler<OrderEventArgs> OrderConfirmed;
        public Form1()
        {
            InitializeComponent();
            OrderCreated += ValidateOrder;
            OrderCreated += DisplayOrderInfo;
            OrderRejected += ShowRejection;
            OrderConfirmed += ShowConfirmation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ValidateOrder(object sender, OrderEventArgs e)
        {
            if (e.Quantity > 0)
            {
                lblStatus.Text = "Validated";
                // Chain the OrderConfirmed event
                OrderConfirmed?.Invoke(this, e);
            }
            else
            {
                // Chain the OrderRejected event
                OrderRejected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DisplayOrderInfo(object sender, OrderEventArgs e)
        {
            MessageBox.Show($"Order Summary:\nCustomer: {e.Customer}\nProduct: {e.Product}\nQuantity: {e.Quantity}");
        }

        private void ShowRejection(object sender, EventArgs e)
        {
            lblStatus.Text = "Order Invalid - Please retry";
        }

        private void ShowConfirmation(object sender, OrderEventArgs e)
        {
            lblStatus.Text = $"Order Processed Successfully for {e.Customer}";
        }

        private void btnProcessOrder_Click(object sender, EventArgs e)
        {
            // 1. Get data from the UI controls
            string customer = txtName.Text;
            string product = cmbProduct.SelectedItem?.ToString() ?? "None"; // Get selected item
            int quantity = (int)numQuantity.Value;

            // 2. Create the event args "payload"
            OrderEventArgs args = new OrderEventArgs(customer, product, quantity);

            // 3. Raise the OrderCreated event
            // This will notify all subscribers (ValidateOrder and DisplayOrderInfo)
            OrderCreated?.Invoke(this, args); //
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string Customer { get; }
        public string Product { get; }
        public int Quantity { get; }

        public OrderEventArgs(string customer, string product, int quantity)
        {
            Customer = customer;
            Product = product;
            Quantity = quantity;
        }
    }
}
