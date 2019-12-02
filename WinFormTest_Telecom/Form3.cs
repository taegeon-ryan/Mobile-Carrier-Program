using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest_Telecom
{
    public partial class Form3 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter plDataAdapter;
        DataSet plDataSet;

        int selectedRowIndex;
        Form1 mainForm;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(MySqlConnection conn)
        {
            InitializeComponent();

            this.conn = conn;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            plDataAdapter = new MySqlDataAdapter("SELECT plan_id, telecom, network, CONCAT(class, ' ', name), price, call_text, data, min_speed, feature FROM telecom.plan", conn);
            plDataSet = new DataSet();

            plDataAdapter.Fill(plDataSet, "telecom.plan");
            dataGridView1.DataSource = plDataSet.Tables["telecom.plan"];

            SetSearchPlanComboBox();

            if (Owner != null)
            {
                mainForm = Owner as Form1;
            }
        }

        #region 콤보박스 초기화
        private void SetSearchPlanComboBox()
        {
            string[] telecom = new string[3] { "SKT", "KT", "LG U+" };
            cbTelecom.Items.AddRange(telecom);

            string[] network = new string[2] { "5G", "4G" };
            cbNetwork.Items.AddRange(network);

            /* 요금제명, 요금, 음성/문자, 데이터, 속도제한 콤보박스 채우기 */
            string sql = "SELECT class, price, call_text, data, min_speed FROM telecom.plan GROUP BY ";
            ComboBox[] cbItems = new ComboBox[5] { cbPlanClass, cbPrice, cbCallText, cbData, cbMinSpeed };
            string[] cbItemNames = new string[5] { "class", "price", "call_text", "data", "min_speed" };
            string[] conditions = new string[5] { "class", "price ORDER BY price DESC", "call_text ORDER BY call_text DESC", "data ORDER BY data DESC", "min_speed ORDER BY min_speed DESC" };

            MySqlCommand cmd;
            MySqlDataReader reader;

            try
            {
                conn.Open();

                for (int i = 0; i < conditions.Length; i++)
                {
                    string conSql = sql + conditions[i];

                    cmd = new MySqlCommand(conSql, conn);

                    reader = cmd.ExecuteReader();
                    while (reader.Read())  // 다음 레코드가 있으면 true
                    {
                        cbItems[i].Items.Add(reader.GetString(cbItemNames[i]));
                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        /* Telecom 변경 시 Class 변경 */
        private void cbTelecom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT distinct class FROM telecom.plan WHERE telecom=@telecom";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@telecom", cbTelecom.Text);

            cbPlanClass.Items.Clear();        // ComboBox 데이터 초기화

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbPlanClass.Items.Add(reader.GetString("class"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /* Network 변경 시 Class 변경 */
        private void cbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            MySqlCommand cmd;
            if (cbTelecom.Text == "")
            {
                sql = "SELECT distinct class FROM telecom.plan WHERE network=@network";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@network", cbNetwork.Text);
            }
            else
            {
                sql = "SELECT distinct class FROM telecom.plan WHERE telecom=@telecom AND network=@network";
                cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@telecom", cbTelecom.Text);
                cmd.Parameters.AddWithValue("@network", cbNetwork.Text);
            }

            cbPlanClass.Items.Clear();        // ComboBox 데이터 초기화

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbPlanClass.Items.Add(reader.GetString("class"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /* Plan Class 변경 시 Name 변경 */
        private void cbPlanClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT distinct name FROM telecom.plan WHERE class=@class";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@class", cbPlanClass.Text);

            cbPlanName.Items.Clear();        // ComboBox 데이터 초기화

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    cbPlanName.Items.Add(reader.GetString("name"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /* Plan Name 변경 시 나머지 콤보 박스 텍스트 변경 */
        private void cbPlanName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT price, call_text, data, min_speed, feature FROM telecom.plan WHERE class=@class AND name=@name";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@class", cbPlanClass.Text);
            cmd.Parameters.AddWithValue("@name", cbPlanName.Text);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  // 레코드가 있으면 true
                {
                    cbPrice.Text = reader.GetString("price");
                    cbCallText.Text = reader.GetString("call_text");
                    cbData.Text = reader.GetString("data");
                    cbMinSpeed.Text = reader.GetString("min_speed");
                    tbFeature.Text = reader.GetString("feature");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /* 표 열 제목 초기화 */
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = " ";
            dataGridView1.Columns[1].HeaderText = "통신사";
            dataGridView1.Columns[2].HeaderText = "통신망";
            dataGridView1.Columns[3].HeaderText = "요금제명";
            dataGridView1.Columns[4].HeaderText = "요금";
            dataGridView1.Columns[5].HeaderText = "음성/문자";
            dataGridView1.Columns[6].HeaderText = "데이터";
            dataGridView1.Columns[7].HeaderText = "속도제한";
            dataGridView1.Columns[8].HeaderText = "특징";
        }

        /* 셀 더블클릭 */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

            cbTelecom.Text = row.Cells[1].Value.ToString();
            cbNetwork.Text = row.Cells[2].Value.ToString();
            cbPlanClass.Text = row.Cells[3].Value.ToString().Split(' ')[0];
            char[] planClass = row.Cells[3].Value.ToString().Split(' ')[0].ToCharArray();
            cbPlanName.Text = row.Cells[3].Value.ToString().TrimStart(planClass).Trim();
            cbPrice.Text = row.Cells[4].Value.ToString();
            cbCallText.Text = row.Cells[5].Value.ToString();
            cbData.Text = row.Cells[6].Value.ToString();
            cbMinSpeed.Text = row.Cells[7].Value.ToString();
            tbFeature.Text = row.Cells[8].Value.ToString();

            btnPlanUpdate.Visible = true;
            btnPlanDelete.Visible = true;
            btnPlanApply.Visible = true;
            btnPlanCancel.Visible = true;
        }

        /* 검색 버튼 클릭 */
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchQueryCommand();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }

            btnPlanUpdate.Visible = false;
            btnPlanDelete.Visible = false;
            btnPlanApply.Visible = false;
            btnPlanCancel.Visible = false;
        }

        /* 지우기 버튼 클릭 */
        private void btnClear_Click(object sender, EventArgs e)
        {
            cbTelecom.Text = "";
            cbNetwork.Text = "";
            cbPlanClass.Text = "";
            cbPlanName.Text = "";
            cbPrice.Text = "";
            cbCallText.Text = "";
            cbData.Text = "";
            cbMinSpeed.Text = "";
            tbFeature.Text = "";

            btnPlanUpdate.Visible = false;
            btnPlanDelete.Visible = false;
            btnPlanApply.Visible = false;
            btnPlanCancel.Visible = false;

            cbTelecom.Focus();
        }

        /* 수정 버튼 클릭 시 텍스트 박스의 내용으로 수정한다고 메시지 박스를 띄우고 
         * 확인 누르면 수정한 후 해당 내용으로 검색 및 수정, 삭제 버튼 비활성화 */
        private void btnPlanUpdate_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string telecom = cbTelecom.Text;
            string network = cbNetwork.Text;
            string planClass = cbPlanClass.Text;
            string planName = cbPlanName.Text;
            string price = cbPrice.Text;
            string callText = cbCallText.Text;
            string data = cbData.Text;
            string minSpeed = cbMinSpeed.Text;
            string feature = tbFeature.Text;

            if (telecom == "" || network == "" || planClass == "" ||
                            planName == "" || price == "" || callText == "" ||
                            data == "" || minSpeed == "" || feature == "")
            {
                MessageBox.Show("일부 값이 비어있어 데이터 수정이 불가능합니다.");
            }

            string askUpdate = $"통신사: {telecom}\n통신망: {network}\n요금제명: {planClass + " " + planName}\n" +
                $"요금: {price}\n음성/문자: {callText}\n데이터: {data}\n" +
                $"속도제한: {minSpeed}\n특징: {feature}\n\n으로 수정할까요?";
            var result = MessageBox.Show(askUpdate, "데이터 수정", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                UpdateSqlCommand(id, telecom, network, planClass, planName, price, callText, data, minSpeed, feature);
                SearchQueryCommand();

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                btnPlanUpdate.Visible = false;
                btnPlanDelete.Visible = false;
                btnPlanApply.Visible = false;
                btnPlanCancel.Visible = false;

                cbTelecom.Focus();
            }
        }

        /* 삭제 버튼 클릭 */
        private void btnPlanDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string telecom = cbTelecom.Text;
            string network = cbNetwork.Text;
            string planClass = cbPlanClass.Text;
            string planName = cbPlanName.Text;
            string price = cbPrice.Text;
            string callText = cbCallText.Text;
            string data = cbData.Text;
            string minSpeed = cbMinSpeed.Text;
            string feature = tbFeature.Text;

            string askDelete = $"통신사: {telecom}\n통신망: {network}\n요금제명: {planClass + " " + planName}\n" +
                $"요금: {price}\n음성/문자: {callText}\n데이터: {data}\n" +
                $"속도제한: {minSpeed}\n특징: {feature}\n\n데이터를 삭제할까요?";
            var result = MessageBox.Show(askDelete, "데이터 삭제", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                DeleteSqlCommand(id);
                string queryStr = "SELECT plan_id, telecom, network, CONCAT(class, ' ', name), price, call_text, data, min_speed, feature FROM telecom.plan";
                plDataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
                try
                {
                    conn.Open();
                    plDataSet.Clear();
                    if (plDataAdapter.Fill(plDataSet, "telecom.plan") > 0)
                        dataGridView1.DataSource = plDataSet.Tables["telecom.plan"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    conn.Close();
                }

                cbTelecom.Text = "";
                cbNetwork.Text = "";
                cbPlanClass.Text = "";
                cbPlanName.Text = "";
                cbPrice.Text = "";
                cbCallText.Text = "";
                cbData.Text = "";
                cbMinSpeed.Text = "";
                tbFeature.Text = "";

                cbTelecom.Focus();

                btnPlanUpdate.Visible = false;
                btnPlanDelete.Visible = false;
                btnPlanApply.Visible = false;
                btnPlanCancel.Visible = false;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }
            }
        }

        #region SELECT 쿼리문 생성 및 실행
        private void SearchQueryCommand()
        {
            string queryStr;

            string telecom = cbTelecom.Text;
            string network = cbNetwork.Text;
            string planClass = cbPlanClass.Text;
            string planName = cbPlanName.Text;
            string price = cbPrice.Text;
            string callText = cbCallText.Text;
            string data = cbData.Text;
            string minSpeed = cbMinSpeed.Text;
            string feature = tbFeature.Text;

            /* Select QueryString 만들기 */
            string[] conditions = new string[9];

            conditions[0] = (telecom != "") ? "telecom=@telecom" : null;
            conditions[1] = (network != "") ? "network=@network" : null;
            conditions[2] = (planClass != "") ? "class=@class" : null;
            conditions[3] = (planName != "") ? "name=@name" : null;
            conditions[4] = (price != "") ? "price=@price" : null;
            conditions[5] = (callText != "") ? "call_text=@call_text" : null;
            conditions[6] = (data != "") ? "data=@data" : null;
            conditions[7] = (minSpeed != "") ? "min_speed=@min_speed" : null;
            conditions[8] = (feature != "") ? "feature=@feature" : null;

            if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null || conditions[4] != null || conditions[5] != null
                || conditions[6] != null || conditions[7] != null || conditions[8] != null)
            {
                queryStr = $"SELECT plan_id, telecom, network, CONCAT(class, ' ', name), price, call_text, data, min_speed, feature FROM telecom.plan WHERE ";
                bool firstCondition = true;
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (conditions[i] != null)
                        if (firstCondition)
                        {
                            queryStr += conditions[i];
                            firstCondition = false;
                        }
                        else
                        {
                            queryStr += " AND " + conditions[i];
                        }
                }
            }
            else
            {
                queryStr = "SELECT plan_id, telecom, network, CONCAT(class, ' ', name), price, call_text, data, min_speed, feature FROM telecom.plan";
            }

            /* SelectCommand 객체 생성 및 Parameters 설정 */
            plDataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@telecom", telecom);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@network", network);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@class", planClass);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@name", planName);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@price", price);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@call_text", callText);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@data", data);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@min_speed", minSpeed);
            plDataAdapter.SelectCommand.Parameters.AddWithValue("@feature", feature);

            /* 실행 */
            try
            {
                conn.Open();
                plDataSet.Clear();
                if (plDataAdapter.Fill(plDataSet, "telecom.plan") > 0)
                    dataGridView1.DataSource = plDataSet.Tables["telecom.plan"];
                else
                {
                    var result = MessageBox.Show("찾는 데이터가 없습니다. 요금제 데이터를 추가할까요?", "데이터 없음", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (telecom == "" || network == "" || planClass == "" ||
                            planName == "" || price == "" || callText == "" ||
                            data == "" || minSpeed == "" || feature == "")
                        {
                            MessageBox.Show("일부 값이 비어있어 데이터 추가가 불가능합니다.");
                        }
                        else
                        {
                            InsertSqlCommand(telecom, network, planClass, planName, price, callText, data, minSpeed, feature);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region INSERT SQL문 생성 및 실행
        private void InsertSqlCommand(string telecom, string network, string planClass, string planName, string price, string callText, string data, string minSpeed, string feature)
        {
            string sql = "INSERT INTO telecom.plan (telecom, network, class, name, price, call_text, data, min_speed, feature) VALUES (@telecom, @network, @class, @name, @price, @call_text, @data, @min_speed, @feature)";

            /* InsertCommand 객체 생성 및 Parameters 설정 */
            plDataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@telecom", telecom);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@network", network);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@class", planClass);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@name", planName);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@price", price);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@call_text", callText);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@data", data);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@min_speed", minSpeed);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@feature", feature);

            /* 실행 */
            try
            {
                plDataAdapter.InsertCommand.ExecuteNonQuery();

                plDataSet.Clear();
                plDataAdapter.Fill(plDataSet, "telecom.plan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region UPDATE SQL문 생성 및 실행
        private void UpdateSqlCommand(string id, string telecom, string network, string planClass,
            string planName, string price, string callText, string data, string minSpeed, string feature)
        {
            string sql = "UPDATE telecom.plan SET telecom=@telecom, network=@network, class=@class, name=@name, price=@price, call_text=@call_text, data=@data, min_speed=@min_speed, feature=@feature WHERE plan_id=@id";

            /* InsertCommand 객체 생성 및 Parameters 설정 */
            plDataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@id", id);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@telecom", telecom);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@network", network);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@class", planClass);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@name", planName);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@price", price);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@call_text", callText);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@data", data);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@min_speed", minSpeed);
            plDataAdapter.InsertCommand.Parameters.AddWithValue("@feature", feature);

            /* 실행 */
            try
            {
                conn.Open();
                plDataAdapter.InsertCommand.ExecuteNonQuery();

                plDataSet.Clear();
                plDataAdapter.Fill(plDataSet, "telecom.plan");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region DELETE SQL문 생성 및 실행
        private void DeleteSqlCommand(string id)
        {
            string sql = "DELETE FROM telecom.plan WHERE plan_id=@id";
            plDataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            plDataAdapter.DeleteCommand.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                plDataAdapter.DeleteCommand.ExecuteNonQuery();

                plDataSet.Clear();
                plDataAdapter.Fill(plDataSet, "telecom.plan");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"개통이력이 존재하는 요금제는 삭제가 불가능합니다.\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        private void btnPlanCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPlanApply_Click(object sender, EventArgs e)
        {
            if(cbTelecom.Text != "SKT")
            {
                MessageBox.Show("타사 요금제는 선택할 수 없습니다.");
                return;
            }

            int id = int.Parse(dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
            mainForm.selectedPlanId = id;

            //TODO: 요금제명 유효성 검사
            mainForm.ChangePlanName(cbPlanClass.Text + " " + cbPlanName.Text);

            Close();
        }
    }
}
