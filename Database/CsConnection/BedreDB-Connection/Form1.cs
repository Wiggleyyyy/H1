using System.Data.SqlClient;

namespace BedreDB_Connection
{
    public partial class Form1 : Form
    {
        //Variables for connection string
        public string dbname = "KundeOrdreDB";
        public string dbDataSource = "localhost";
        public string dbUserID = "AppConnection";
        public string dbPassword = "AppConn!";

        //Variables for connection
        public string ConnectionString;
        public SqlConnection cnn;

        public Form1()
        {
            InitializeComponent();

            listOrder.Columns.Add("Order ID", 100);
            listOrder.Columns.Add("Customer ID", 100);
            listOrder.Columns.Add("Item ID", 100);
            listOrder.Columns.Add("Order date", 100);
            listOrder.Columns.Add("Forwarder ID", 100);

            listOrder.View = View.Details;
            listOrder.FullRowSelect = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                //Connection string to login to database
                ConnectionString = $@"Data Source={dbDataSource},1434;Initial Catalog={dbname};User ID={dbUserID};Password={dbPassword};Integrated Security=True";

                //Make and open connection
                cnn = new SqlConnection(ConnectionString);
                cnn.Open();

                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    btnStart.Visible = false;
                    lblConnection.Text = "Connection: Open";

                    lblOrder.Visible = true;
                    btnViewOrder.Visible = true;
                    btnCreateOrder.Visible = true;
                    btnDeleteOrder.Visible = true;

                    lblCustomer.Visible = true;
                    btnViewCustomer.Visible = true;
                    btnCreateCustomer.Visible = true;
                    btnDeleteCustomer.Visible = true;
                }
                else
                {
                    MessageBox.Show("Something went wrong", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblConnection.Text = "Connection: Failed";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                cnn.Close();
                this.Close();
            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            listOrder.Visible = true;

            string sqlSelectOrders = "SELECT * FROM Orders";

            using (SqlCommand command = new SqlCommand(sqlSelectOrders, cnn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<OrderData> orders = new List<OrderData>();

                    while (reader.Read())
                    {
                        int orderId = (int)reader.GetInt32(0);
                        int customerId = (int)reader.GetInt32(1);
                        int itemId = (int)reader.GetInt32(2);
                        DateTime tempOrderDate = reader.GetDateTime(3);
                        string orderDate = tempOrderDate.ToString("yyyy-MM-dd");
                        int forwarderId = (int)reader.GetInt32(4);

                        OrderData Order = new OrderData
                        {
                            id = orderId,
                            customerId = customerId,
                            itemId = itemId,
                            orderDate = orderDate,
                            forwarderId = forwarderId,
                        };

                        orders.Add(Order);
                    }

                    if (orders.Count > 0)
                    {
                        foreach (var order in orders)
                        {
                            ListViewItem orderListItem = new ListViewItem(order.id.ToString());
                            orderListItem.SubItems.Add(order.customerId.ToString());
                            orderListItem.SubItems.Add(order.itemId.ToString());
                            orderListItem.SubItems.Add(order.orderDate.ToString());
                            orderListItem.SubItems.Add(order.forwarderId.ToString());

                            listOrder.Items.Add(orderListItem);
                        }
                    }
                }
            }
        }
    }
}