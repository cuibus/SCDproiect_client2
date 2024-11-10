namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        PostService postService;
        List<Post> postList;
        public Form1()
        {
            InitializeComponent();
            postService = new PostService();
            postService.createConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var usersList = postService.GetActiveUsers();

            comboBox1.DataSource= usersList;
            comboBox1.DisplayMember= "name";
        }
    }
}