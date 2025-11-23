namespace OrderPipeline
{
    public partial class Form1 : Form
    {
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler OrderRejected;
        public event EventHandler<OrderEventArgs> OrderConfirmed;
        public event EventHandler<ShipEventArgs> OrderShipped;
        public Form1()
        {
            InitializeComponent();
            OrderCreated += ValidateOrder;
            OrderCreated += DisplayOrderInfo;
            OrderRejected += ShowRejection;
            OrderConfirmed += ShowConfirmation;
            OrderShipped += ShowDispatch;
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
            btnShipOrder.Enabled = true;
        }

        private void ShowDispatch(object sender, ShipEventArgs e)
        {
            lblStatus.Text = $"Product dispatched: {e.Product}";
        }

        private void NotifyCourier(object sender, ShipEventArgs e)
        {
            if (e.Express)
            {
                MessageBox.Show("Express delivery initiated!");
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private void btnShipOrder_Click(object sender, EventArgs e)
        {
            // 1. DYNAMIC SUBSCRIPTION
            // First, remove NotifyCourier to ensure we don't subscribe it twice
            OrderShipped -= NotifyCourier;

            // If the checkbox is checked, add the subscriber
            if (chkExpress.Checked)
            {
                OrderShipped += NotifyCourier;
            }

            // 2. PREPARE DATA
            // Get the current product from the UI
            string product = cmbProduct.SelectedItem?.ToString() ?? "Unknown";
            bool isExpress = chkExpress.Checked;

            ShipEventArgs args = new ShipEventArgs(product, isExpress);

            // 3. RAISE EVENT
            OrderShipped?.Invoke(this, args);
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

    public class ShipEventArgs : EventArgs
    {
        public string Product { get; }
        public bool Express { get; }

        public ShipEventArgs(string p, bool ex)
        {
            Product = p;
            Express = ex;
        }
    }
}
