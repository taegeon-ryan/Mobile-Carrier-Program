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
    public partial class Form2 : Form
    {
        private string name;
        private string birth;
        private string phoneNum;
        private bool isJustName;

        MySqlConnection conn;
        MySqlDataAdapter accDataAdapter;
        DataSet accDataSet;

        int selectedRowIndex;
        Form1 mainForm;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(MySqlConnection conn, bool isJustName)
        {
            InitializeComponent();
            this.conn = conn;
            this.isJustName = isJustName;
        }

        public Form2(string v1, string v2, string v3, MySqlConnection conn)
        {
            InitializeComponent();
            name = v1;
            birth = v2;
            phoneNum = v3;
            this.conn = conn;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            accDataAdapter = new MySqlDataAdapter("SELECT * FROM telecom.account", conn);
            accDataSet = new DataSet();

            accDataAdapter.Fill(accDataSet, "telecom.account");
            dataGridView1.DataSource = accDataSet.Tables["telecom.account"];

            SetSearchAccountComboBox();

            if (name != null && birth != null && phoneNum != null) 
                SetInitialSearchValue();

            if (dataGridView1.Rows.Count > 0) {
                dataGridView1.Rows[0].Selected = false;
            }

            if (Owner != null)
            {
                mainForm = Owner as Form1;
            }
        }

        #region 콤보박스 초기화
        private void SetSearchAccountComboBox()
        {
            for (int i = 2019; i >= 1930; i--)
            {
                cbYear.Items.Add(i);
            }
            for (int i = 1; i <= 12; i++)
            {
                cbMonth.Items.Add(string.Format("{0:0#}", i));
            }
            for (int i = 1; i <= 31; i++)
            {
                cbDay.Items.Add(string.Format("{0:0#}", i));
            }
            string[] phoneNumStart = new string[5] { "010", "011", "016", "017", "019" };
            cbPhoneNum.Items.AddRange(phoneNumStart);
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbMonth.Text))
            {
                ChangeDayComboBox();
            }
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDayComboBox();
        }

        private void ChangeDayComboBox()
        {
            int daysInMonth = DateTime.DaysInMonth(int.Parse(cbYear.Text), int.Parse(cbMonth.Text));
            if (cbDay.Items.Count != daysInMonth)
            {
                cbDay.Items.Clear();
                for (int i = 1; i <= daysInMonth; i++)
                {
                    cbDay.Items.Add(string.Format("{0:0#}", i));
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 폼 최초 실행 시 칸 텍스트 채우기 및 검색 시도
        private void SetInitialSearchValue()
        {
            tbName.Text = name;

            cbYear.Text = birth.Split('-')[0];
            cbMonth.Text = birth.Split('-')[1];
            cbDay.Text = birth.Split('-')[2];

            cbPhoneNum.Text = phoneNum.Split('-')[0];
            tbPhoneNumMid.Text = phoneNum.Split('-')[1];
            tbPhoneNumEnd.Text = phoneNum.Split('-')[2];

            SearchQueryCommand();
        }
        #endregion

        /* 표 열 제목 초기화 */
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = " ";
            dataGridView1.Columns[1].HeaderText = "성명";
            dataGridView1.Columns[2].HeaderText = "생년월일";
            dataGridView1.Columns[3].HeaderText = "회선번호";
        }

        /* 검색 버튼 클릭 시 검색 실행 */
        private void btnAccSearch_Click(object sender, EventArgs e)
        {
            SearchQueryCommand();

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnApply.Visible = false;
            btnCancel.Visible = false;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }
        }

        /* 지우기 버튼 클릭 */
        private void btnAccClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            cbYear.Text = "";
            cbMonth.Text = "";
            cbDay.Text = "";
            cbPhoneNum.Text = "";
            tbPhoneNumMid.Text = "";
            tbPhoneNumEnd.Text = "";

            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnApply.Visible = false;
            btnCancel.Visible = false;

            tbName.Focus();
        }

        /* 셀 더블 클릭 시 셀 내용 텍스트 박스로 옮기고 수정, 삭제 버튼 활성화 */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            if (selectedRowIndex < 0)
                return;
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

            tbName.Text = row.Cells[1].Value.ToString();
            cbYear.Text = row.Cells[2].Value.ToString().Split('-')[0];
            cbMonth.Text = row.Cells[2].Value.ToString().Split('-')[1];
            cbDay.Text = row.Cells[2].Value.ToString().Split('-')[2];
            cbPhoneNum.Text = row.Cells[3].Value.ToString().Split('-')[0];
            tbPhoneNumMid.Text = row.Cells[3].Value.ToString().Split('-')[1];
            tbPhoneNumEnd.Text = row.Cells[3].Value.ToString().Split('-')[2];

            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnApply.Visible = true;
            btnCancel.Visible = true;
        }

        /* 수정 버튼 클릭 시 텍스트 박스의 내용으로 수정한다고 메시지 박스를 띄우고 
         * 확인 누르면 수정한 후 해당 내용으로 검색 및 수정, 삭제 버튼 비활성화 */
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string changeName = tbName.Text.Trim();
            string changeBirth = $"{cbYear.Text}-{int.Parse(cbMonth.Text).ToString("D2")}-{int.Parse(cbDay.Text).ToString("D2")}";
            string changePhoneNum = $"{cbPhoneNum.Text}-{tbPhoneNumMid.Text}-{tbPhoneNumEnd.Text}";

            bool isNotFilled = CheckAccTextBox(name, birth, phoneNum);
            if (isNotFilled) return;

            string askUpdate = $"성명: {changeName}\n생년월일: {changeBirth}\n회선번호: {changePhoneNum}\n으로 수정할까요?";
            var result = MessageBox.Show(askUpdate, "정보 수정", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                UpdateSqlCommand(id, changeName, changeBirth, changePhoneNum);
                SearchQueryCommand();

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnCancel.Visible = false;

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }
            }
        }

        #region 고객 수정 텍스트 유효성 검사
        private bool CheckAccTextBox(string name, string birth, string phoneNum)
        {
            if (name.Length < 2)
            {
                MessageBox.Show("성명을 바르게 입력해 주시기 바랍니다.");
                return true;
            }
            else if (birth.Length != 10)
            {
                MessageBox.Show($"생년월일을 바르게 채워 주시기 바랍니다.");
                return true;
            }
            else if (phoneNum.Length != 13)
            {
                MessageBox.Show($"회선번호를 바르게 채워 주시기 바랍니다.");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /* 삭제 버튼 클릭 시 텍스트 박스의 내용으로 삭제한다고 메시지 박스를 띄우고
         확인 누르면 삭제한 뒤 텍스트 박스 지우기, 전체 검색 실행*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            string changeName = tbName.Text.Trim();
            string changeBirth = $"{cbYear.Text}-{int.Parse(cbMonth.Text).ToString("D2")}-{int.Parse(cbDay.Text).ToString("D2")}";
            string changePhoneNum = $"{cbPhoneNum.Text}-{tbPhoneNumMid.Text}-{tbPhoneNumEnd.Text}";

            string askDelete = $"성명: {changeName}\n생년월일: {changeBirth}\n회선번호: {changePhoneNum}\n계정을 삭제할까요?";
            var result = MessageBox.Show(askDelete, "정보 삭제", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                DeleteSqlCommand(id);

                tbName.Text = "";
                cbYear.Text = "";
                cbMonth.Text = "";
                cbDay.Text = "";
                cbPhoneNum.Text = "";
                tbPhoneNumMid.Text = "";
                tbPhoneNumEnd.Text = "";

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnApply.Visible = false;
                btnCancel.Visible = false;

                tbName.Focus();

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

            /* Select QueryString 만들기 */
            string[] conditions = new string[3];

            if (tbName.Text != "")
                conditions[0] = "name=@name";
            else
                conditions[0] = null;
            if ((cbYear.Text != "") && (cbMonth.Text != "") && (cbDay.Text != ""))
                conditions[1] = "birth=@birth";
            else
                conditions[1] = null;
            if ((cbPhoneNum.Text != "") && (tbPhoneNumMid.Text != "") && (tbPhoneNumEnd.Text != ""))
                conditions[2] = "phone_num=@phone_num";
            else
                conditions[2] = null;

            if (conditions[0] != null || conditions[1] != null || conditions[2] != null)
            {
                queryStr = $"SELECT * FROM telecom.account WHERE ";
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
                            queryStr += " and " + conditions[i];
                        }
                }
            }
            else
            {
                queryStr = "SELECT * FROM telecom.account";
            }

            /* SelectCommand 객체 생성 및 Parameters 설정 */

            string name = tbName.Text.Trim();
            string birth = $"{cbYear.Text}-{cbMonth.Text}-{cbDay.Text}";
            string phone_num = $"{cbPhoneNum.Text}-{tbPhoneNumMid.Text}-{tbPhoneNumEnd.Text}";

            accDataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            accDataAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
            accDataAdapter.SelectCommand.Parameters.AddWithValue("@birth", birth);
            accDataAdapter.SelectCommand.Parameters.AddWithValue("@phone_num", phone_num);

            /* 실행 */
            try
            {
                conn.Open();
                accDataSet.Clear();
                if (accDataAdapter.Fill(accDataSet, "telecom.account") > 0)
                    dataGridView1.DataSource = accDataSet.Tables["telecom.account"];
                else
                {
                    var result = MessageBox.Show("찾는 데이터가 없습니다. 고객 데이터를 추가할까요?", "데이터 없음", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        InsertSqlCommand(name, birth, phone_num);
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
        private void InsertSqlCommand(string name, string birth, string phone_num)
        {
            string sql = "INSERT INTO telecom.account (name, birth, phone_num) VALUES (@name, @birth, @phone_num)";

            /* InsertCommand 객체 생성 및 Parameters 설정 */
            accDataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            accDataAdapter.InsertCommand.Parameters.AddWithValue("@name", name);
            accDataAdapter.InsertCommand.Parameters.AddWithValue("@birth", birth);
            accDataAdapter.InsertCommand.Parameters.AddWithValue("@phone_num", phone_num);

            /* 실행 */
            try
            {
                accDataAdapter.InsertCommand.ExecuteNonQuery();

                accDataSet.Clear();
                accDataAdapter.Fill(accDataSet, "telecom.account");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region UPDATE SQL문 생성 및 실행
        private void UpdateSqlCommand(string id, string name, string birth, string phone_num)
        {
            string sql = "UPDATE telecom.account SET name=@name, birth=@birth, phone_num=@phone_num WHERE acc_id=@id";

            /* UpdateCommand 객체 생성 및 Parameters 설정 */
            accDataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            accDataAdapter.UpdateCommand.Parameters.AddWithValue("@id", id);
            accDataAdapter.UpdateCommand.Parameters.AddWithValue("@name", name);
            accDataAdapter.UpdateCommand.Parameters.AddWithValue("@birth", birth);
            accDataAdapter.UpdateCommand.Parameters.AddWithValue("@phone_num", phone_num);

            /* 실행 */
            try
            {
                conn.Open();
                accDataAdapter.UpdateCommand.ExecuteNonQuery();

                accDataSet.Clear();
                accDataAdapter.Fill(accDataSet, "telecom.account");
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
            string sql = "DELETE FROM telecom.account WHERE acc_id=@id";
            accDataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            accDataAdapter.DeleteCommand.Parameters.AddWithValue("@id", id);

            try
            {
                conn.Open();
                accDataAdapter.DeleteCommand.ExecuteNonQuery();

                accDataSet.Clear();
                accDataAdapter.Fill(accDataSet, "telecom.account");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"개통이력이 존재하는 계정은 삭제가 불가능합니다.\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
            mainForm.selectedAccId = int.Parse(id);
            if (isJustName != true)
            {
                mainForm.OrderSearchQueryCommand(id);
            }
            else
            {
                mainForm.ChangeAccName(tbName.Text);
            }
            
            Close();
        }
    }
}
