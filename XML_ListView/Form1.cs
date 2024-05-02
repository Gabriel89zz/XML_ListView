using System.Xml;

namespace XML_ListView
{
    public partial class Form1 : Form
    {
        String URLString;
        XmlTextReader reader;

        public Form1()
        {
            InitializeComponent();
            URLString = "https://www.w3schools.com/xml/cd_catalog.xml";
            reader = new XmlTextReader(URLString);

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Title", 150);
            listView1.Columns.Add("Artist", 150);
            listView1.Columns.Add("Country", 100);
            listView1.Columns.Add("Company", 100);
            listView1.Columns.Add("Price", 100);
            listView1.Columns.Add("Year", 100);


            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "CD")
                {
                    string title = "", artist = "", country = "", company = "", price = "", year = "";

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "TITLE":
                                    title = reader.ReadString();
                                    break;
                                case "ARTIST":
                                    artist = reader.ReadString();
                                    break;
                                case "COUNTRY":
                                    country = reader.ReadString();
                                    break;
                                case "COMPANY":
                                    company = reader.ReadString();
                                    break;
                                case "PRICE":
                                    price = reader.ReadString();
                                    break;
                                case "YEAR":
                                    year = reader.ReadString();
                                    break;
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "CD")
                        {
                            ListViewItem item = new ListViewItem(new[] { title, artist, country, company, price, year });
                            listView1.Items.Add(item);
                            break;
                        }
                    }
                }
            }
        }
    }
}
