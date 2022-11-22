using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TakeFood
{
    public partial class FrmMain : Form
    {
        //历史记录
        private List<Record> _History = new List<Record>();

        private Dictionary<string, int> _Today = new Dictionary<string, int>();
        
        //总个数
        private int _Total = 0;

        // 倍数
        private const int _ratio = 1000;

        private List<string> _RandomPool = new List<string>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            lbList.Items.Clear();
            tbResult.Text = "";
            CountToday();
        }

        private void CountToday()
        {
            ReadJson();
            List<string> persons = new List<string>();
            for (int i = 0; i < cbPerson.Items.Count; i++)
            {
                if (cbPerson.GetItemChecked(i))
                {
                    persons.Add(cbPerson.Items[i].ToString());
                }
            }            
            persons = RandomSortList(persons);

            _Today.Clear();
            _Total = 0;
            foreach (var person in persons)
            {
                var his = _History.FirstOrDefault(p => p.Name == person);
                int value = Convert.ToInt16((his.Join - his.Win) * _ratio / his.Join);
                _Today.Add(person, value);
                _Total += value;
            }

            for (int i = 0; i < _Today.Count; i++)
            {
                var a = _Today.ElementAt(i);
                string name = a.Key;
                if (a.Key.Length == 2)
                {
                    name += "  ";
                }
                lbList.Items.Add(name + " | " + _Today[a.Key]*100/ _Total + "%");
            }

            // 添加随机池
            _RandomPool.Clear();
            foreach (var today in _Today)
            {
                for (int i = 0; i < today.Value; i++)
                {
                    _RandomPool.Add(today.Key);
                }
            }
            _RandomPool = RandomSortList(_RandomPool);

            var boy = GetBoy();

            tbResult.AppendText("             " + 
                DateTime.Now.ToString("yyyy-MM-dd") + " Lucky Boy: " + boy);

            WriteJson(boy);
        }

        private string GetBoy()
        {
            double min = _Today.Min(kvp => kvp.Value);
            var minKey = _Today.Where(kvp => kvp.Value == min).Select(kvp => kvp.Key).First();

            string boy = minKey;
            while (boy == minKey)
            {
                Random rom = new Random();
                int random = rom.Next(0, _RandomPool.Count);
                boy = _RandomPool[random];
            }
            return boy;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ReadJson();
            LoadPerson();
        }

        private void ReadJson()
        {
            string path = Environment.CurrentDirectory + "\\记录.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                _History = JsonToObject <List<Record>>(json);
            }
        }

        private void WriteJson(string name)
        {
            string path = Environment.CurrentDirectory + "\\记录.json";
            for (int i = 0; i < cbPerson.Items.Count; i++)
            {
                if (cbPerson.GetItemChecked(i))
                {
                    var his = _History.FirstOrDefault(p => p.Name == cbPerson.Items[i].ToString());
                    his.Join++;
                    if (his.Name == name)
                        his.Win++;
                }
            }
            string json = ObjectToJson(_History);
            File.WriteAllText(path, json);
        }

        private void LoadPerson()
        {
            cbPerson.Items.Clear();
            foreach (var his in _History)
            {
                cbPerson.Items.Add(his.Name, true);
            }
        }

        public static string ObjectToJson(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 随机排序
        /// </summary>
        public List<T> RandomSortList<T>(List<T> list)
        {
            System.Random random = new System.Random();
            List<T> nList = new List<T>();
            foreach (T temp in list)
            {
                nList.Insert(random.Next(nList.Count + 1), temp);
            }
            return nList;            
        }
    }
}
