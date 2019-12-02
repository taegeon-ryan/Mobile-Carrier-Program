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
    public partial class Form4 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter mdlDataAdapter;
        DataSet mdlDataSet;

        int selectedRowIndex;
        Form1 mainForm;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(MySqlConnection conn)
        {
            InitializeComponent();
            
            this.conn = conn;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            mdlDataAdapter = new MySqlDataAdapter("SELECT * FROM telecom.model", conn);
            mdlDataSet = new DataSet();

            mdlDataAdapter.Fill(mdlDataSet, "telecom.model");
            dataGridView1.DataSource = mdlDataSet.Tables["telecom.model"];

            SetSearchModelComboBox();

            if (Owner != null)
            {
                mainForm = Owner as Form1;
            }
        }

        #region 콤보박스 초기화
        private void SetSearchModelComboBox()
        {
            string[] network = new string[2] { "5G", "4G" };
            cbNetwork.Items.AddRange(network);

            /* 제조사, 기종명, 모델명, 용량, 색상 채우기 */
            string sql = "SELECT distinct manufacturer, petname, modelname, storage, color FROM telecom.model GROUP BY ";
            ComboBox[] cbItems = new ComboBox[5] { cbManufacturer, cbPetname, cbModelname, cbStorage, cbColor };
            string[] cbItemNames = new string[5] { "manufacturer", "petname", "modelname", "storage", "color" };
            string[] conditions = new string[5] { "manufacturer ORDER BY manufacturer", "petname ORDER BY petname", "modelname ORDER BY modelname", "storage ORDER BY storage", "color ORDER BY color" };

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

        /* 제조사 변경 시 다른 콤보박스 변경 */
        private void cbManufacturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT petname, storage FROM telecom.model WHERE manufacturer=@manufacturer GROUP BY ";
            ComboBox[] cbItems = new ComboBox[2] { cbPetname, cbStorage };
            string[] cbItemNames = new string[2] { "petname", "storage" };
            string[] conditions = new string[2] { "petname ORDER BY petname", "storage ORDER BY storage" };

            MySqlCommand cmd;
            MySqlDataReader reader;

            cbPetname.Items.Clear();
            cbStorage.Items.Clear();

            try
            {
                conn.Open();

                for (int i = 0; i < conditions.Length; i++)
                {
                    string conSql = sql + conditions[i];

                    cmd = new MySqlCommand(conSql, conn);
                    cmd.Parameters.AddWithValue("@manufacturer", cbManufacturer.Text);

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

        /* 통신망 변경 시 다른 콤보박스 변경 */
        private void cbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataReader reader;

            ComboBox[] cbItems = new ComboBox[2] { cbPetname, cbStorage };
            string[] cbItemNames = new string[2] { "petname", "storage" };
            string[] conditions = new string[2] { "petname ORDER BY petname", "storage ORDER BY storage" };

            cbPetname.Items.Clear();
            cbStorage.Items.Clear();

            try
            {
                conn.Open();
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (cbManufacturer.Text == "")
                    {
                        sql = "SELECT distinct petname, storage FROM telecom.model WHERE network=@network GROUP BY ";
                        string conSql = sql + conditions[i];
                        cmd = new MySqlCommand(conSql, conn);
                        cmd.Parameters.AddWithValue("@network", cbNetwork.Text);
                    }
                    else
                    {
                        sql = "SELECT distinct petname, storage FROM telecom.model WHERE manufacturer=@manufacturer AND network=@network GROUP BY ";
                        string conSql = sql + conditions[i];
                        cmd = new MySqlCommand(conSql, conn);
                        cmd.Parameters.AddWithValue("@manufacturer", cbManufacturer.Text);
                        cmd.Parameters.AddWithValue("@network", cbNetwork.Text);
                    }
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

        /* 기종명 변경 시 다른 콤보박스 변경 */
        private void cbPetname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataReader reader;

            ComboBox[] cbItems = new ComboBox[3] { cbModelname, cbStorage, cbColor };
            string[] cbItemNames = new string[3] { "modelname", "storage", "color" };
            string[] conditions = new string[3] { "modelname ORDER BY modelname", "storage ORDER BY storage", "color ORDER BY color" };

            cbModelname.Items.Clear();
            cbStorage.Items.Clear();
            cbColor.Items.Clear();

            sql = "SELECT distinct modelname, storage, color FROM telecom.model WHERE petname=@petname GROUP BY ";

            try
            {
                conn.Open();
                for (int i = 0; i < conditions.Length; i++)
                {
                    string conSql = sql + conditions[i];
                    cmd = new MySqlCommand(conSql, conn);
                    cmd.Parameters.AddWithValue("@petname", cbPetname.Text);
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

        /* 용량 변경 시 출고가, 지원금 변경 */
        private void cbStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            MySqlCommand cmd;
            MySqlDataReader reader;

            TextBox[] tbItems = new TextBox[2] { tbPrice, tbSubsidy };
            string[] tbItemNames = new string[2] { "price", "subsidy" };
            string[] conditions = new string[2] { "price ORDER BY price", "subsidy ORDER BY subsidy" };

            sql = "SELECT distinct price, subsidy FROM telecom.model WHERE petname=@petname AND storage=@storage GROUP BY ";

            try
            {
                conn.Open();
                for (int i = 0; i < conditions.Length; i++)
                {
                    if (cbPetname.Text == "") return;
                    else
                    {
                        string conSql = sql + conditions[i];
                        cmd = new MySqlCommand(conSql, conn);
                        cmd.Parameters.AddWithValue("@petname", cbPetname.Text);
                        cmd.Parameters.AddWithValue("@storage", cbStorage.Text);
                    }
                    reader = cmd.ExecuteReader();
                    if (reader.Read())  // 다음 레코드가 있으면 true
                    {
                        tbItems[i].Text = reader.GetString(tbItemNames[i]);
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

        /* 표 열 제목 초기화 */
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = " ";
            dataGridView1.Columns[1].HeaderText = "제조사";
            dataGridView1.Columns[2].HeaderText = "기종명";
            dataGridView1.Columns[3].HeaderText = "모델명";
            dataGridView1.Columns[4].HeaderText = "통신망";
            dataGridView1.Columns[5].HeaderText = "용량";
            dataGridView1.Columns[6].HeaderText = "색상";
            dataGridView1.Columns[7].HeaderText = "출고가";
            dataGridView1.Columns[8].HeaderText = "지원금";
        }

        /* 셀 더블클릭 */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

            cbManufacturer.Text = row.Cells[1].Value.ToString();
            cbPetname.Text = row.Cells[2].Value.ToString();
            cbModelname.Text = row.Cells[3].Value.ToString();
            cbNetwork.Text = row.Cells[4].Value.ToString();
            cbStorage.Text = row.Cells[5].Value.ToString();
            cbColor.Text = row.Cells[6].Value.ToString();
            tbPrice.Text = row.Cells[7].Value.ToString();
            tbSubsidy.Text = row.Cells[8].Value.ToString();

            btnMdlUpdate.Visible = true;
            btnMdlDelete.Visible = true;
            btnMdlApply.Visible = true;
            btnMdlCancel.Visible = true;
        }

        /* 검색 버튼 */
        private void btnMdlSearch_Click(object sender, EventArgs e)
        {
            SearchQueryCommand();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }

            btnMdlUpdate.Visible = false;
            btnMdlDelete.Visible = false;
            btnMdlApply.Visible = false;
            btnMdlCancel.Visible = false;
        }

        /* 지우기 버튼 */
        private void btnMdlClear_Click(object sender, EventArgs e)
        {
            cbManufacturer.Text = "";
            cbNetwork.Text = "";
            cbPetname.Text = "";
            cbModelname.Text = "";
            cbStorage.Text = "";
            cbColor.Text = "";
            tbPrice.Text = "";
            tbSubsidy.Text = "";

            btnMdlUpdate.Visible = false;
            btnMdlDelete.Visible = false;
            btnMdlApply.Visible = false;
            btnMdlCancel.Visible = false;

            cbManufacturer.Focus();
        }

        /* 수정 버튼 */
        private void btnMdlUpdate_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string manufacturer = cbManufacturer.Text;
            string network = cbNetwork.Text;
            string petname = cbPetname.Text;
            string modelname = cbModelname.Text;
            string storage = cbStorage.Text;
            string color = cbColor.Text;
            string price = tbPrice.Text;
            string subsidy = tbSubsidy.Text;

            if (manufacturer == "" || network == "" || petname == "" ||
                            modelname == "" || storage == "" || color == "" ||
                            price == "" || subsidy == "")
            {
                MessageBox.Show("일부 값이 비어있어 데이터 수정이 불가능합니다.");
            }

            string askUpdate = $"제조사: {manufacturer}\n통신망: {network}\n기종명: {petname}\n" +
                $"모델명: {modelname}\n용량: {storage}\n색상: {color}\n" +
                $"출고가: {price}\n지원금: {subsidy}\n\n으로 수정할까요?";
            var result = MessageBox.Show(askUpdate, "데이터 수정", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                UpdateSqlCommand(id, manufacturer, network, petname, modelname, storage, color, price, subsidy);
                SearchQueryCommand();

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                btnMdlUpdate.Visible = false;
                btnMdlDelete.Visible = false;
                btnMdlApply.Visible = false;
                btnMdlCancel.Visible = false;

                cbManufacturer.Focus();
            }
        }

        /* 삭제 버튼 */
        private void btnMdlDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string manufacturer = cbManufacturer.Text;
            string network = cbNetwork.Text;
            string petname = cbPetname.Text;
            string modelname = cbModelname.Text;
            string storage = cbStorage.Text;
            string color = cbColor.Text;
            string price = tbPrice.Text;
            string subsidy = tbSubsidy.Text;

            string askDelete = $"제조사: {manufacturer}\n통신망: {network}\n기종명: {petname}\n" +
                $"모델명: {modelname}\n용량: {storage}\n색상: {color}\n" +
                $"출고가: {price}\n지원금: {subsidy}\n\n데이터를 삭제할까요?";
            var result = MessageBox.Show(askDelete, "데이터 삭제", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                DeleteSqlCommand(id);
                string queryStr = "SELECT * FROM telecom.model";
                mdlDataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
                try
                {
                    conn.Open();
                    mdlDataSet.Clear();
                    if (mdlDataAdapter.Fill(mdlDataSet, "telecom.model") > 0)
                        dataGridView1.DataSource = mdlDataSet.Tables["telecom.model"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    conn.Close();
                }

                cbManufacturer.Text = "";
                cbNetwork.Text = "";
                cbPetname.Text = "";
                cbModelname.Text = "";
                cbStorage.Text = "";
                cbColor.Text = "";
                tbPrice.Text = "";
                tbSubsidy.Text = "";

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                btnMdlUpdate.Visible = false;
                btnMdlDelete.Visible = false;
                btnMdlApply.Visible = false;
                btnMdlCancel.Visible = false;

                cbManufacturer.Focus();
            }
        }

        #region SELECT 쿼리문 생성 및 실행
        private void SearchQueryCommand()
        {
            string queryStr;

            string manufacturer = cbManufacturer.Text;
            string network = cbNetwork.Text;
            string petname = cbPetname.Text;
            string modelname = cbModelname.Text;
            string storage = cbStorage.Text;
            string color = cbColor.Text;
            string price = tbPrice.Text;
            string subsidy = tbSubsidy.Text;

            /* Select QueryString 만들기 */
            string[] conditions = new string[8];

            conditions[0] = (manufacturer != "") ? "manufacturer=@manufacturer" : null;
            conditions[1] = (network != "") ? "network=@network" : null;
            conditions[2] = (petname != "") ? "petname=@petname" : null;
            conditions[3] = (modelname != "") ? "modelname=@modelname" : null;
            conditions[4] = (storage != "") ? "storage=@storage" : null;
            conditions[5] = (color != "") ? "color=@color" : null;
            conditions[6] = (price != "") ? "price=@price" : null;
            conditions[7] = (subsidy != "") ? "subsidy=@subsidy" : null;

            if (conditions[0] != null || conditions[1] != null || conditions[2] != null || conditions[3] != null || conditions[4] != null || conditions[5] != null
                || conditions[6] != null || conditions[7] != null)
            {
                queryStr = $"SELECT * FROM telecom.model WHERE ";
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
                queryStr = "SELECT * FROM telecom.model";
            }

            /* SelectCommand 객체 생성 및 Parameters 설정 */
            mdlDataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@manufacturer", manufacturer);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@network", network);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@petname", petname);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@modelname", modelname);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@storage", storage);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@color", color);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@price", price);
            mdlDataAdapter.SelectCommand.Parameters.AddWithValue("@subsidy", subsidy);

            /* 실행 */
            try
            {
                conn.Open();
                mdlDataSet.Clear();
                if (mdlDataAdapter.Fill(mdlDataSet, "telecom.model") > 0)
                    dataGridView1.DataSource = mdlDataSet.Tables["telecom.model"];
                else
                {
                    var result = MessageBox.Show("찾는 데이터가 없습니다. 기종 데이터를 추가할까요?", "데이터 없음", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        if (manufacturer == "" || network == "" || petname == "" ||
                            modelname == "" || storage == "" || color == "" ||
                            price == "" || subsidy == "")
                        {
                            MessageBox.Show("일부 값이 비어있어 데이터 추가가 불가능합니다.");
                        }
                        else
                        {
                            InsertSqlCommand(manufacturer, network, petname, modelname, storage, color, price, subsidy);
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
        private void InsertSqlCommand(string manufacturer, string network, string petname, string modelname, string storage, string color, string price, string subsidy)
        {
            string sql = "INSERT INTO telecom.model (manufacturer, network, petname, modelname, storage, color, price, subsidy) VALUES (@manufacturer, @network, @petname, @modelname, @storage, @color, @price, @subsidy)";

            /* InsertCommand 객체 생성 및 Parameters 설정 */
            mdlDataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@manufacturer", manufacturer);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@network", network);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@petname", petname);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@modelname", modelname);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@storage", storage);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@color", color);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@price", price);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@subsidy", subsidy);

            /* 실행 */
            try
            {
                mdlDataAdapter.InsertCommand.ExecuteNonQuery();

                mdlDataSet.Clear();
                mdlDataAdapter.Fill(mdlDataSet, "telecom.model");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region UPDATE SQL문 생성 및 실행
        private void UpdateSqlCommand(string id, string manufacturer, string network, string petname, string modelname, string storage, string color, string price, string subsidy)
        {
            string sql = "UPDATE telecom.model SET manufacturer=@manufacturer, network=@network, petname=@petname, modelname=@modelname, storage=@storage, color=@color, price=@price, subsidy=@subsidy WHERE model_id=@id";

            /* InsertCommand 객체 생성 및 Parameters 설정 */
            mdlDataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@id", id);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@manufacturer", manufacturer);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@network", network);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@petname", petname);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@modelname", modelname);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@storage", storage);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@color", color);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@price", price);
            mdlDataAdapter.InsertCommand.Parameters.AddWithValue("@subsidy", subsidy);

            /* 실행 */
            try
            {
                conn.Open();
                mdlDataAdapter.InsertCommand.ExecuteNonQuery();

                mdlDataSet.Clear();
                mdlDataAdapter.Fill(mdlDataSet, "telecom.model");
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
            string sql = "DELETE FROM telecom.model WHERE model_id=@id";
            mdlDataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            mdlDataAdapter.DeleteCommand.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                mdlDataAdapter.DeleteCommand.ExecuteNonQuery();

                mdlDataSet.Clear();
                mdlDataAdapter.Fill(mdlDataSet, "telecom.model");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"개통이력이 존재하는 기종은 삭제가 불가능합니다.\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        private void btnMdlCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMdlApply_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
            mainForm.selectedModelId = id;

            //TODO: 기종명 유효성 검사
            mainForm.ChangeModelName(cbPetname.Text.Replace(" ", "") + " " + cbStorage.Text + " " + cbColor.Text.Replace(" ", ""));

            Close();
        }
    }
}
