using MySql.Data.MySqlClient;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormTest_Telecom
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet, printDataSet;

        int selectedRowIndex;

        public int selectedAccId;
        public int selectedPlanId;
        public int selectedModelId;

        int rebatetype;
        int bondmonth;
        int ordertype;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;port=3306;database=telecom;uid=root;pwd=6929";
            conn = new MySqlConnection(connStr);
            dataAdapter = new MySqlDataAdapter("SELECT * FROM telecom.order", conn);
            dataSet = new DataSet();
            printDataSet = new DataSet();

            SetSearchAccountComboBox();
        }

        #region 고객 조회 콤보박스 설정
        private void SetSearchAccountComboBox()
        {
            for (int i=2019; i>=1930; i--)
            {
                cbYear.Items.Add(i);
            }
            for (int i=1; i<=12; i++)
            {
                cbMonth.Items.Add(string.Format("{0:0#}", i));
            }

            string[] phoneNumStart = new string[5] { "010", "011", "016", "017", "019" };
            cbPhoneNumStart.Items.AddRange(phoneNumStart);
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDayComboBox();     
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cbMonth.Text))
            {
                ChangeDayComboBox();
            }
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

        /* 고객 조회 검색 버튼 클릭 */
        private void btnAccSearch_Click(object sender, EventArgs e)
        {
            btnSelectOrder.Visible = false;
            lblOrderInfo.Visible = false;
            tbBalance.Text = "";
            tbCurrentAccount.Text = "";
            tbCurrentPlan.Text = "";
            tbOrderStart.Text = "";

            string name, birth, phoneNum;
            if (tbName.Text.Length > 0)
                name = tbName.Text.Trim();
            else
                name = "";
            if (cbYear.Text.Length > 0 || cbMonth.Text.Length > 0 || cbDay.Text.Length > 0)
                birth = $"{cbYear.Text}-{int.Parse(cbMonth.Text).ToString("D2")}-{int.Parse(cbDay.Text).ToString("D2")}";
            else
                birth = "";
            if (cbPhoneNumStart.Text.Length > 0 || tbPhoneNumMid.Text.Length > 0 || tbPhoneNumEnd.Text.Length > 0)
                phoneNum = $"{cbPhoneNumStart.Text}-{tbPhoneNumMid.Text}-{tbPhoneNumEnd.Text}";
            else
                phoneNum = "";

            bool isNotFilled = CheckAccTextBox(name, birth, phoneNum);
            if (isNotFilled) return;

            // 새로운 폼을 입력값과 함께 생성함
            Form2 AccSearch = new Form2(name, birth, phoneNum, conn);

            AccSearch.Owner = this;               // 새로운 폼의 부모가 Form1 인스턴스임을 지정
            AccSearch.ShowDialog();               // 폼 띄우기(Modal)
            AccSearch.Dispose();                  // 새로운 폼을 닫으면 해제함
        }

        #region 고객 조회 텍스트 유효성 검사
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

        /* 고객 조회 폼 디버깅 */
        private void btnAccDebug_Click(object sender, EventArgs e)
        {
            Form2 AccSearch = new Form2(conn, false);

            AccSearch.Owner = this;
            AccSearch.ShowDialog();               // 폼 띄우기(Modal)
            AccSearch.Dispose();
        }

        #region 개통이력 order 테이블 SELECT 문 쿼리 생성 및 실행
        public void OrderSearchQueryCommand(string id)
        {
            string queryStr = "SELECT o.order_id, a.name, o.line_num, p.telecom, CONCAT(p.class, ' ', p.name) TOTAL, CONCAT(m.manufacturer, ' ', m.petname, ' ', m.storage, 'GB ', m.color) TOTAL, o.orderdate, o.ordertype, o.rebatetype, o.bondmonth, CONCAT(o.buyprice, '원'), o.enddate, CONCAT(o.balance, '원') TOTAL " +
                "FROM telecom.order o, telecom.account a, telecom.model m, telecom.plan p " +
                "WHERE a.acc_id = o.acc_id " +
                "AND m.model_id = o.model_id " +
                "AND p.plan_id = o.plan_id " +
                "AND o.terminate = 0 " +
                "AND a.acc_id = @id ";
            // [0] 일련번호 [1] 명의자 [2] 회선번호 [3] 통신사 [4] 요금제명 [5] 기종명 [6] 개통일 [7] 가입유형 [8] 할인유형 [9] 할부개월 [10] 단말기할부금 [11] 만기일 [12] 미납금

            /* SelectCommand 객체 생성 및 Parameters 설정 */
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@id", id);

            /* 실행 */
            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "telecom.order") > 0)
                {
                    dataGridView1.DataSource = dataSet.Tables["telecom.order"];
                    dataGridView1.Rows[0].Selected = false;
                }
                else
                    MessageBox.Show("개통이력이 존재하지 않습니다.");
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

        /* 개통이력 표 열 제목 초기화 */
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = " ";
            dataGridView1.Columns[1].HeaderText = "명의자";
            dataGridView1.Columns[2].HeaderText = "회선번호";
            dataGridView1.Columns[3].HeaderText = "통신사";
            dataGridView1.Columns[4].HeaderText = "요금제";
            dataGridView1.Columns[5].HeaderText = "기종";
            dataGridView1.Columns[6].HeaderText = "개통일";
            dataGridView1.Columns[7].HeaderText = "가입유형";
            dataGridView1.Columns[8].HeaderText = "할인유형";
            dataGridView1.Columns[9].HeaderText = "할부개월";
            dataGridView1.Columns[10].HeaderText = "단말기할부금";
            dataGridView1.Columns[11].HeaderText = "만기일";
            dataGridView1.Columns[12].HeaderText = "미납금";
        }

        /* 개통이력 표 셀 더블 클릭 시 선택 버튼 보이게 함 */
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            btnSelectOrder.Visible = true;
        }

        /* 선택 버튼 클릭 시 서비스 옆 레이블과 회선 선택 콤보 박스 4개 텍스트 변경*/
        private void btnSelectOrder_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];

            string orderName = row.Cells[1].Value.ToString();
            string lineNum = row.Cells[2].Value.ToString();

            lblOrderInfo.Text = $"{orderName}({lineNum}) 고객님";
            lblOrderInfo.Visible = true;

            btnSelectPlan.Enabled = true;
            btnSelectModel.Enabled = true;
            btnApplyOrder.Enabled = true;

            if (row.Cells[3].Value.ToString() == "SKT")
            {
                tbOrderStart.Text = row.Cells[6].Value.ToString(); // 개통일
                tbBalance.Text = string.Format("{0: #,##0}원", int.Parse(row.Cells[12].Value.ToString().Replace(",", "").Replace("원", ""))); // 미납금
                DateTime today = DateTime.Today;
                DateTime endDate = DateTime.Parse(row.Cells[11].Value.ToString());
                tbMonthLeft.Text = string.Format("{0}개월", ((endDate.Year - today.Year) * 12) + endDate.Month - today.Month); // 잔여 개월
                tbPlanPay.Text = string.Format("{0: #,##0}원", getPlanPay());
                tbModelPay.Text = string.Format("{0: #,##0}원", getModelPay());
                tbCurrentPlan.Text = row.Cells[4].Value.ToString(); // 요금제
                tbCurrentAccount.Text = row.Cells[1].Value.ToString(); // 명의자

                ToggleTextBoxAndButtons(true);

                rdbType1.Enabled = false;
                rdbType2.Enabled = true;
            }
            else
            {
                tbOrderStart.Text = "타 통신사 가입 회선";
                tbBalance.Text = "타 통신사 가입 회선";
                tbCurrentPlan.Text = "타 통신사 가입 회선";
                tbCurrentAccount.Text = "타 통신사 가입 회선";

                rdbType1.Enabled = true;
                rdbType2.Enabled = false;
            }
        }

        #region 해지 위약금 계산
        private int getPlanPay()
        {
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
            int planPay = 0;

            string rebateType = row.Cells[8].Value.ToString(); // 할인유형 (공시/요금할인 12개월, 24개월)
            DateTime orderStart = Convert.ToDateTime(row.Cells[6].Value.ToString()); // 개통일
            DateTime orderEnd = Convert.ToDateTime(row.Cells[11].Value.ToString());  // 만기일

            // 지원금 금액 구하기
            int modelId = 0, modelSubsidy = 0;

            string queryStr = "SELECT model_id FROM telecom.order WHERE order_id=@id";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", row.Cells[0].Value.ToString());

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  // 레코드가 있으면 true
                {
                    modelId = reader.GetInt32("model_id");
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

            queryStr = "SELECT subsidy FROM telecom.model WHERE model_id=@id";
            cmd = new MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", modelId);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  // 레코드가 있으면 true
                {
                    modelSubsidy = reader.GetInt32("subsidy");
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


            // 공시지원금인 경우 (18개월 미만 : 전액, 18개월 이상 : 지원금 * (잔여기간 / (약정기간-180일)) )
            if (rebateType == "단말할인")
            {
                DateTime today = DateTime.Today;
                DateTime startDate = orderStart;
                DateTime endDate = orderEnd;
                int monthLeft = (endDate.Year - today.Year) * 12 + endDate.Month - today.Month;
                int useMonth = (today.Year - startDate.Year) * 12 + today.Month - startDate.Month;
                if (useMonth < 18) // 18개월 미만
                {
                    planPay = modelSubsidy;
                }
                else
                {
                    double dayLeft = Convert.ToInt32(endDate - today);
                    double totalDay = Convert.ToInt32(endDate - startDate);
                    planPay = (int)(modelSubsidy * (dayLeft / totalDay));
                }
                return planPay;
            }
            else if (rebateType == "12개월 요금할인") // 12개월 요금할인인 경우 3개월 이내 : 100%, 이후는 누적할인액 * (잔여기간 / (약정기간-90일))
            {
                DateTime today = DateTime.Today;
                DateTime startDate = orderStart;
                DateTime endDate = startDate.AddMonths(12);

                // 요금제명으로 요금제 가격 검색
                string plan = row.Cells[4].Value.ToString();
                string planClass = plan.Split(' ')[0];
                char[] planClassArray = planClass.ToCharArray();
                string planName = plan.TrimStart(planClassArray);
                int planPrice = 0;

                queryStr = "SELECT price FROM telecom.plan WHERE class=@class AND name=@name";
                cmd = new MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@class", planClass);
                cmd.Parameters.AddWithValue("@name", planName);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())  // 레코드가 있으면 true
                    {
                        planPrice = reader.GetInt32("price");
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

                int monthLeft = (endDate.Year - today.Year) * 12 + endDate.Month - today.Month;
                int useMonth = (today.Year - startDate.Year) * 12 + today.Month - startDate.Month;
                if (useMonth < 3) // 3개월 미만
                {
                    planPay = (int)(planPrice * 0.25 * useMonth);
                }
                else
                {
                    double dayLeft = (endDate - today).Days; // 잔여기간
                    double totalDay = (endDate - startDate).Days; // 약정기간
                    planPay = (int)(planPrice * 0.25 * useMonth * (dayLeft / (totalDay - 90)));
                }
                return planPay;
            }
            else if (rebateType == "24개월 요금할인") // 24개월 요금할인인 경우 6개월 이내 : 100%, 이후는 누적할인액 * (잔여기간 / (약정기간-180일))
            {
                DateTime today = DateTime.Today;
                DateTime startDate = DateTime.Parse(row.Cells[6].Value.ToString());
                DateTime endDate = startDate.AddMonths(24);

                // 요금제명으로 요금제 가격 검색
                string plan = row.Cells[4].Value.ToString();
                string planClass = plan.Split(' ')[0];
                char[] planClassArray = planClass.ToCharArray();
                string planName = plan.TrimStart(planClassArray);
                int planPrice = 0;

                queryStr = "SELECT price FROM telecom.plan WHERE class=@class AND name=@name";
                cmd = new MySqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@class", planClass);
                cmd.Parameters.AddWithValue("@name", planName);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())  // 레코드가 있으면 true
                    {
                        planPrice = reader.GetInt32("price");
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

                int useMonth = (today.Year - startDate.Year) * 12 + today.Month - startDate.Month;
                if (useMonth < 6) // 6개월 미만
                {
                    planPay = (int)(planPrice * 0.25 * useMonth);
                }
                else
                {
                    double dayLeft = (endDate - today).Days; // 잔여기간
                    double totalDay = (endDate - startDate).Days; // 약정기간
                    planPay = (int)(planPrice * 0.25 * useMonth * (dayLeft / (totalDay - 180)));
                }
                return planPay;
            }
            else 
                return 0;
        }
        #endregion

        #region 잔여 단말기 할부금 계산
        private int getModelPay()
        {
            DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
            int modelPay = 0;
            DateTime today = DateTime.Today;
            DateTime endDate = Convert.ToDateTime(row.Cells[11].Value.ToString());
            string bondMonth = row.Cells[9].Value.ToString(); // 할부개월
            int modelTotalPay = int.Parse(row.Cells[10].Value.ToString().Replace("원", "")); // 단말기할부금
            int bondMonthToInt;
            var result = int.TryParse(bondMonth.Replace("개월", ""), out bondMonthToInt);
            if (result) // 일시불이 아닌 경우
            {
                double monthLeft = (endDate.Year - today.Year) * 12 + endDate.Month - today.Month;
                modelPay = (int)(modelTotalPay * (monthLeft / bondMonthToInt));
                return modelPay;
            }
            else // 일시불
            {
                return 0;
            }
        }
        #endregion

        #region 텍스트 박스의 색깔을 바꾸고 활성화함
        private void ToggleTextBoxAndButtons(bool enabled)
        {
            List<TextBox> textBoxColor = new List<TextBox> {
                    tbCurrentPlan,
                    tbChangePlan,
                    tbCurrentAccount,
                    tbChangeAccount,
                    tbOrderStart,
                    tbMonthLeft,
                    tbPlanPay,
                    tbMonthLeft,
                    tbBalance
                };

            List<Button> buttons = new List<Button> { 
                btnSearchPlan, btnSearchAccount, btnTerminate, btnBalance, btnApplyPlanChange, btnApplyAccountChange
            };

            if (enabled)
            {
                foreach (var item in textBoxColor)
                {
                    item.BackColor = SystemColors.ControlLightLight;
                }
                foreach (var item in buttons)
                {
                    item.Enabled = true;
                }
            } 
            else
            {
                foreach (var item in textBoxColor)
                {
                    item.BackColor = SystemColors.Control;
                }
                foreach (var item in buttons)
                {
                    item.Enabled = false;
                }
            }
        }
        #endregion

        /* 요금제 선택 버튼 클릭 */
        private void btnSelectPlan_Click(object sender, EventArgs e)
        {
            Form3 PlanSearch = new Form3(conn);

            PlanSearch.Owner = this;
            PlanSearch.ShowDialog();               // 폼 띄우기(Modal)
            PlanSearch.Dispose();
        }

        public void ChangePlanName(string name)
        {
            tbSelectPlan.Text = name;
            tbChangePlan.Text = name;
        }

        /* 기종 선택 버튼 클릭 */
        private void btnSelectModel_Click(object sender, EventArgs e)
        {
            Form4 ModelSearch = new Form4(conn);

            ModelSearch.Owner = this;
            ModelSearch.ShowDialog();
            ModelSearch.Dispose();
        }

        public void ChangeModelName(string name)
        {
            tbSelectModel.Text = name;
        }

        private void tbSelectPlan_TextChanged(object sender, EventArgs e)
        {
            if (rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked ||
                rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked || rdbBond4.Checked ||
                rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                RadioButton[] rdbItems = new RadioButton[10] { rdbRebate1, rdbRebate2, rdbRebate3, rdbBond1, rdbBond2, 
                    rdbBond3, rdbBond4, rdbType1, rdbType2, rdbType3 };
                foreach (var item in rdbItems)
                {
                    item.Checked = false;
                }
                Label[] lblItems = { lblPlanPrice, lblDiscountExists, lblMonthlyDiscount, lblOrderMonthly };
                foreach (var item in lblItems)
                {
                    item.Visible = false;
                }
            }

                lblPlanPrice.Visible = true;
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT price FROM telecom.plan WHERE plan_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedPlanId);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  // 레코드가 있으면 true
                {
                    lblPlanPrice.Text = string.Format("{0:#,###}원",reader.GetInt32("price"));
                    lblMonthlyDiscount.Text = string.Format("{0:#,###}원", int.Parse(lblPlanPrice.Text.Replace(",", "").Replace("원", "")) / 4);
                }
                reader.Close();
                
                if (tbSelectModel.Text != "")
                {
                    gbRebateType.Enabled = true;
                    gbBondMonth.Enabled = true;
                    gbOrderType.Enabled = true;
                    rdbBond1.Enabled = true;
                    rdbBond2.Enabled = true;
                    rdbBond3.Enabled = true;
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

        private void tbSelectModel_TextChanged(object sender, EventArgs e)
        {
            if (rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked ||
                rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked || rdbBond4.Checked ||
                rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                RadioButton[] rdbItems = new RadioButton[10] { rdbRebate1, rdbRebate2, rdbRebate3, rdbBond1, rdbBond2,
                    rdbBond3, rdbBond4, rdbType1, rdbType2, rdbType3 };
                foreach (var item in rdbItems)
                {
                    item.Checked = false;
                }
                Label[] lblItems = { lblModelPrice, lblSubsidyExists, lblModelSubsidy, lblModelPurchase, lblFeeExists, lblModelFee, lblModelFee, lblModelMonthly, lblOrderMonthly };
                foreach (var item in lblItems)
                {
                    item.Visible = false;
                }
            }

            lblModelPrice.Visible = true;
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT price, subsidy FROM telecom.model WHERE model_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedModelId);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())  // 레코드가 있으면 true
                {
                    lblModelPrice.Text = string.Format("{0:#,###}원", reader.GetInt32("price"));
                    lblModelSubsidy.Text = string.Format("{0:-#,###}원", reader.GetInt32("subsidy"));
                }
                reader.Close();

                if (tbSelectPlan.Text != "")
                {
                    gbRebateType.Enabled = true;
                    gbBondMonth.Enabled = true;
                    gbOrderType.Enabled = true;
                    rdbBond1.Enabled = true;
                    rdbBond2.Enabled = true;
                    rdbBond3.Enabled = true;
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

        #region 할인방법 라디오버튼 클릭
        private void rdbRebate1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRebate1.Checked)
            {
                lblSubsidyExists.Visible = true;
                lblModelSubsidy.Visible = true;
                int price = int.Parse(lblModelPrice.Text.Replace(",", "").Replace("원", ""));
                int subsidy = int.Parse(lblModelSubsidy.Text.Replace(",", "").Replace("원", ""));
                lblModelPurchase.Text = string.Format("{0:#,###}원", price + subsidy);
                lblModelPurchase.Visible = true;
                rebatetype = 1;
            }
            else
            {
                lblSubsidyExists.Visible = false;
                lblModelSubsidy.Visible = false;
            }

            if (rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked) // 일시불이 아닌 경우
            {
                whenBondMonthChanges();
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }

        private void rdbRebate2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRebate2.Checked || rdbRebate3.Checked)
            {
                lblDiscountExists.Visible = true;
                lblMonthlyDiscount.Visible = true;
                lblModelPurchase.Text = lblModelPrice.Text;
                lblModelPurchase.Visible = true;
                rebatetype = 2;
            }
            else
            {
                lblDiscountExists.Visible = false;
                lblMonthlyDiscount.Visible = false;
            }

            if (rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked) // 일시불이 아닌 경우
            {
                whenBondMonthChanges();
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }

        private void rdbRebate3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRebate2.Checked || rdbRebate3.Checked)
            {
                lblDiscountExists.Visible = true;
                lblMonthlyDiscount.Visible = true;
                lblModelPurchase.Text = lblModelPrice.Text;
                lblModelPurchase.Visible = true;
                rebatetype = 3;
            }
            else
            {
                lblDiscountExists.Visible = false;
                lblMonthlyDiscount.Visible = false;
            }

            if (rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked) // 일시불이 아닌 경우
            {
                whenBondMonthChanges();
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }
        #endregion

        #region 할부개월 라디오버튼 클릭
        private void rdbBond1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBond1.Checked)
            {
                bondmonth = 24;

                if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked)) return;
                whenBondMonthChanges();
            }
            else
            {
                lblModelMonthly.Visible = false;
                lblFeeExists.Visible = false;
                lblModelFee.Visible = false;
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }

        private void rdbBond2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBond2.Checked)
            {
                bondmonth = 30;

                if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked)) return;
                whenBondMonthChanges();
            }
            else
            {
                lblModelMonthly.Visible = false;
                lblFeeExists.Visible = false;
                lblModelFee.Visible = false;
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }

        private void rdbBond3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBond3.Checked)
            {
                bondmonth = 36;

                if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked)) return;
                whenBondMonthChanges();
            }
            else
            {
                lblModelMonthly.Visible = false;
                lblFeeExists.Visible = false;
                lblModelFee.Visible = false;
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }

        private void rdbBond4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBond4.Checked)
            {
                bondmonth = 1;

                if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked)) return;
                whenBondMonthChanges();
                lblFeeExists.Visible = false;
                lblModelFee.Visible = false;
                lblModelMonthly.Text = "0원";
                lblModelFee.Text = "0원";
            }
            if (rdbType1.Checked || rdbType2.Checked || rdbType3.Checked)
            {
                whenOrderTypeChanges();
            }
        }
        #endregion

        #region 분할상환수수료 계산
        private void whenBondMonthChanges()
        {
            int price = int.Parse(lblModelPurchase.Text.Replace(",", "").Replace("원", "")); // 단말기할부금
            double monthlyFeeRate = 0.059 / 12; // 0.004916666666... 월 이율
            int totalMonthlyPrice = Convert.ToInt32(price * monthlyFeeRate * Math.Pow(1 + monthlyFeeRate, bondmonth) / (Math.Pow(1 + monthlyFeeRate, bondmonth) - 1)); // 월 할부금
            int totalPrice = totalMonthlyPrice * bondmonth; // 총 할부금
            int fee = (totalPrice - price) / bondmonth; // 분할상환수수료


            lblModelMonthly.Text = string.Format("{0:#,###}원", totalMonthlyPrice);
            lblModelFee.Text = string.Format("{0:#,###}원", fee);

            lblFeeExists.Visible = true;
            lblModelMonthly.Visible = true;
            lblModelFee.Visible = true;
        }
        #endregion

        #region 가입유형 라디오버튼 클릭
        private void rdbType1_CheckedChanged(object sender, EventArgs e)
        {
            if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked) &&
                !(rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked || rdbBond4.Checked)) return;

            ordertype = 1;
            whenOrderTypeChanges();

            rdbBond1.Enabled = true;
            rdbBond2.Enabled = true;
            rdbBond3.Enabled = true;
        }

        private void rdbType2_CheckedChanged(object sender, EventArgs e)
        {
            if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked) &&
                !(rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked || rdbBond4.Checked)) return;

            ordertype = 2;
            whenOrderTypeChanges();

            rdbBond1.Enabled = true;
            rdbBond2.Enabled = true;
            rdbBond3.Enabled = true;
        }

        private void rdbType3_CheckedChanged(object sender, EventArgs e)
        {
            if (!(rdbRebate1.Checked || rdbRebate2.Checked || rdbRebate3.Checked) &&
                !(rdbBond1.Checked || rdbBond2.Checked || rdbBond3.Checked || rdbBond4.Checked)) return;

            ordertype = 3;

            rdbBond4.Checked = true;
            rdbBond1.Enabled = false;
            rdbBond2.Enabled = false;
            rdbBond3.Enabled = false;

            whenOrderTypeChanges();
        }
        #endregion

        private void whenOrderTypeChanges()
        {
            int plan = int.Parse(lblPlanPrice.Text.Replace(",", "").Replace("원", ""));
            int model = int.Parse(lblModelMonthly.Text.Replace(",", "").Replace("원", ""));
            lblOrderMonthly.Text = string.Format("{0:#,###}원", plan + model);
            lblOrderMonthly.Visible = true;
        }

        private void btnApplyOrder_Click(object sender, EventArgs e)
        {
            string askInsert = $"요금제: {tbSelectPlan.Text}\n기종: {tbSelectModel.Text}\n\n회선을 개통할까요?";
            var result = MessageBox.Show(askInsert, "개통 신청", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRowIndex];
                string phoneNum;
                int bondMonth = 0; // 가입개월
                string rebateTypeToString = "";
                string bondModelMonthToString = "";
                string orderTypeToString;

                if (rebatetype == 1)
                {
                    if (bondmonth == 24) bondMonth = 24;
                    if (bondmonth == 30) bondMonth = 30;
                    if (bondmonth == 36) bondMonth = 36;
                    if (bondmonth == 1) bondMonth = 0;
                    rebateTypeToString = "단말할인";
                }
                else if (rebatetype == 2)
                {
                    bondMonth = 12;
                    rebateTypeToString = "12개월 요금할인";
                }
                else if (rebatetype == 3)
                {
                    bondMonth = 24;
                    rebateTypeToString = "24개월 요금할인";
                }

                if (bondmonth == 24)
                    bondModelMonthToString = "24개월";
                else if (bondmonth == 30)
                    bondModelMonthToString = "30개월";
                else if (bondmonth == 36)
                    bondModelMonthToString = "36개월";
                else if (bondmonth == 1)
                    bondModelMonthToString = "일시불";

                if (ordertype == 1) // 번이
                {
                    phoneNum = row.Cells[2].Value.ToString();
                    orderTypeToString = "번호이동";
                }
                else if (ordertype == 2) // 기변
                {
                    phoneNum = row.Cells[2].Value.ToString();
                    orderTypeToString = "기기변경";
                }
                else if (ordertype == 3) // 신규
                {
                    string phoneNumStart = "010";
                    string phoneNumMid = "", phoneNumEnd = "";

                    Random r = new Random();
                    for (int i = 0; i < 4; i++)
                    {
                        phoneNumMid += r.Next(0, 9).ToString();
                        phoneNumEnd += r.Next(0, 9).ToString();
                    }

                    phoneNum = phoneNumStart + "-" + phoneNumMid + "-" + phoneNumEnd;
                    orderTypeToString = "신규가입";
                }
                else
                    return;

                /* 개통 */
                int acc_id = selectedAccId;
                int plan_id = selectedPlanId;
                int model_id = selectedModelId;
                int balance = 0;

                string today = string.Format("{0:yyyy-MM-dd}", DateTime.Today);
                string endDate = string.Format("{0:yyyy-MM-dd}", DateTime.Today.AddMonths(bondMonth));
                int buyPrice = int.Parse(lblModelPurchase.Text.Replace(",", "").Replace("원", ""));

                string sql = "INSERT INTO telecom.order (acc_id, plan_id, model_id, line_num, balance, orderdate, enddate, buyprice, rebatetype, bondmonth, ordertype, terminate) VALUES (@aid, @pid, @mid, @line_num, @balance, @orderdate, @enddate, @buyprice, @rebatetype, @bondmonth, @ordertype, @terminate)";
                dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@aid", acc_id);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@pid", plan_id);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@mid", model_id);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@line_num", phoneNum);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@balance", balance);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@orderdate", today);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@enddate", endDate);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@buyprice", buyPrice);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@rebatetype", rebateTypeToString);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@bondmonth", bondModelMonthToString);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@ordertype", orderTypeToString);
                dataAdapter.InsertCommand.Parameters.AddWithValue("@terminate", 0);

                try
                {
                    conn.Open();
                    dataAdapter.InsertCommand.ExecuteNonQuery();

                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "telecom.order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    conn.Close();
                }

                /* 기존 회선 해지 */
                if (ordertype != 3)
                {
                    sql = "UPDATE telecom.order SET terminate=1 WHERE order_id=@id";
                    dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
                    dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());

                    try
                    {
                        conn.Open();
                        dataAdapter.UpdateCommand.ExecuteNonQuery();

                        dataSet.Clear();
                        dataAdapter.Fill(dataSet, "telecom.order");
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

                tbSelectPlan.Text = "";
                tbSelectModel.Text = "";
                gbRebateType.Enabled = false;
                gbBondMonth.Enabled = false;
                gbOrderType.Enabled = false;
                btnApplyOrder.Enabled = false;
                lblPlanPrice.Text = "";
                lblDiscountExists.Visible = false;
                lblMonthlyDiscount.Visible = false;
                lblMonthlyDiscount.Text = "";
                lblModelPrice.Text = "";
                lblSubsidyExists.Visible = false;
                lblModelSubsidy.Visible = false;
                lblModelSubsidy.Text = "";
                lblModelPurchase.Visible = false;
                lblModelPurchase.Text = "";
                lblFeeExists.Visible = false;
                lblModelFee.Visible = false;
                lblModelFee.Text = "";
                lblModelMonthly.Visible = false;
                lblModelMonthly.Text = "";
                lblOrderMonthly.Visible = false;
                lblOrderMonthly.Text = "";

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                ToggleTextBoxAndButtons(false);

                btnApplyOrder.Focus();
            }
        }

        /* 변경 요금제 조회 */
        private void btnSearchPlan_Click(object sender, EventArgs e)
        {
            Form3 PlanSearch = new Form3(conn);

            PlanSearch.Owner = this;
            PlanSearch.ShowDialog();               // 폼 띄우기(Modal)
            PlanSearch.Dispose();
        }

        /* 변경 요금제 채워지면 신청 버튼 활성화 */
        private void tbChangePlan_TextChanged(object sender, EventArgs e)
        {
            btnApplyPlanChange.Enabled = true;
        }

        /* 요금제 변경 신청 */
        private void btnApplyPlanChange_Click(object sender, EventArgs e)
        {
            string currentPlanName = tbCurrentPlan.Text;
            string changePlanName = tbChangePlan.Text;
            int currentPlanPrice = 0, changePlanPrice = 0;

            // 현재 요금제 가격 검색
            string queryStr = "SELECT price FROM telecom.plan WHERE class=@class AND name=@name";
            MySqlCommand cmd = new MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@class", currentPlanName.Split(' ')[0]);
            char[] currentPlanClass = currentPlanName.Split(' ')[0].ToCharArray();
            cmd.Parameters.AddWithValue("@name", currentPlanName.TrimStart(currentPlanClass).Trim());

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentPlanPrice = reader.GetInt32("price");
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

            // 변경 요금제 가격 검색
            queryStr = "SELECT price FROM telecom.plan WHERE plan_id=@id";
            cmd = new MySqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@id", selectedPlanId);

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    changePlanPrice = reader.GetInt32("price");
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

            string askUpdate = $"변경 전 요금제: {currentPlanName}\n변경 후 요금제: {changePlanName}\n" +
                $"월 통신요금: {currentPlanPrice} -> {changePlanPrice}\n\n요금제를 변경할까요?";
            var result = MessageBox.Show(askUpdate, "요금제 변경", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql = "UPDATE telecom.order SET plan_id=@plan_id WHERE order_id=@id";
                dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@plan_id", selectedPlanId);
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                
                try
                {
                    conn.Open();
                    dataAdapter.UpdateCommand.ExecuteNonQuery();

                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "telecom.order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                tbCurrentPlan.Text = "";
                tbChangePlan.Text = "";

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                ToggleTextBoxAndButtons(false);

                btnApplyPlanChange.Focus();
            }
        }

        /* 변경 명의 조회 */
        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            Form2 AccSearch = new Form2(conn, true);

            AccSearch.Owner = this;
            AccSearch.ShowDialog();               // 폼 띄우기(Modal)
            AccSearch.Dispose();
        }

        public void ChangeAccName(string name)
        {
            tbChangeAccount.Text = name;
        }

        /* 변경 명의 채워지면 신청 버튼 활성화 */
        private void tbChangeAccount_TextChanged(object sender, EventArgs e)
        {
            btnApplyAccountChange.Enabled = true;
        }

        /* 명의 변경 신청 */
        private void btnApplyAccountChange_Click(object sender, EventArgs e)
        {
            string currentAccName = tbCurrentAccount.Text;
            string changeAccName = tbChangeAccount.Text;
            string phoneNum = dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString();

            string askUpdate = $"회선번호: {phoneNum}\n" +
                $"명의자: {currentAccName} -> {changeAccName}\n\n명의를 변경할까요?";
            var result = MessageBox.Show(askUpdate, "명의 변경", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql = "UPDATE telecom.order SET acc_id=@acc_id WHERE order_id=@id";
                dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@acc_id", selectedAccId);
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());

                try
                {
                    conn.Open();
                    dataAdapter.UpdateCommand.ExecuteNonQuery();

                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "telecom.order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                tbCurrentAccount.Text = "";
                tbChangeAccount.Text = "";

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                ToggleTextBoxAndButtons(false);

                btnApplyAccountChange.Focus();
            }
        }

        /* 요금 납부 버튼 활성화 */
        private void tbBalance_TextChanged(object sender, EventArgs e)
        {
            int currentBalance;
            var isNumber = Int32.TryParse(tbBalance.Text.Replace(",", "").Replace("원", ""), out currentBalance);
            if (isNumber)
            {
                btnBalance.Enabled = true;
            }
        }

        /* 요금 납부 신청 */
        private void btnBalance_Click(object sender, EventArgs e)
        {
            int balance = int.Parse(tbBalance.Text.Replace(",", "").Replace("원", ""));
            string askUpdate = $"미납액 {tbBalance.Text}을 납부합니다.";
            var result = MessageBox.Show(askUpdate, "요금 납부", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql = "UPDATE telecom.order SET balance=0 WHERE order_id=@id";
                dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());

                try
                {
                    conn.Open();
                    dataAdapter.UpdateCommand.ExecuteNonQuery();

                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "telecom.order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                tbBalance.Text = "";

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                ToggleTextBoxAndButtons(false);

                btnBalance.Focus();
            }
        }

        /* 해지 신청 */
        private void btnTerminate_Click(object sender, EventArgs e)
        {
            string askUpdate = $"회선을 해지할까요?\n위약금 및 잔여 단말기 할부금 {getPlanPay()+getModelPay()}원이 익월 청구됩니다.";
            var result = MessageBox.Show(askUpdate, "해지 신청", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql = "UPDATE telecom.order SET terminate=1 WHERE order_id=@id";
                dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());

                try
                {
                    conn.Open();
                    dataAdapter.UpdateCommand.ExecuteNonQuery();

                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "telecom.order");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                tbOrderStart.Text = "";
                tbMonthLeft.Text = "";
                tbPlanPay.Text = "";
                tbModelPay.Text = "";

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = false;
                }

                ToggleTextBoxAndButtons(false);

                btnTerminate.Focus();
            }
        }

        /* 엑셀 데이터 내보내기 */
        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application ap = new Excel.Application();
            Excel.Workbook excelWorkBook = ap.Workbooks.Add();

            string queryStr = "SELECT o.order_id 일련번호, a.name 명의자, o.line_num 회선번호, p.telecom 통신사, CONCAT(p.class, ' ', p.name) 요금제명, CONCAT(m.manufacturer, ' ', m.petname, ' ', m.storage, 'GB ', m.color) 기종명, o.orderdate 개통일, o.ordertype 가입유형, o.rebatetype 할인유형, o.bondmonth 할부개월, CONCAT(o.buyprice, '원') 단말기할부금, o.enddate 만기일, CONCAT(o.balance, '원') 미납금 " +
                "FROM telecom.order o, telecom.account a, telecom.model m, telecom.plan p " +
                "WHERE a.acc_id = o.acc_id " +
                "AND m.model_id = o.model_id " +
                "AND p.plan_id = o.plan_id " +
                "AND o.terminate = 0 ";
            // [0] 일련번호 [1] 명의자 [2] 회선번호 [3] 통신사 [4] 요금제명 [5] 기종명 [6] 개통일 [7] 가입유형 [8] 할인유형 [9] 할부개월 [10] 단말기할부금 [11] 만기일 [12] 미납금

            /* SelectCommand 객체 생성 및 Parameters 설정 */
            dataAdapter.SelectCommand = new MySqlCommand(queryStr, conn);

            /* 실행 */
            try
            {
                conn.Open();
                printDataSet.Clear();
                dataAdapter.Fill(printDataSet, "telecom.order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            foreach (DataTable dt in printDataSet.Tables)
            {
                Excel.Worksheet ws = excelWorkBook.Sheets.Add();
                ws.Name = dt.TableName;

                for (int columnHeaderIndex = 1; columnHeaderIndex <= dt.Columns.Count; columnHeaderIndex++)
                {
                    ws.Cells[1, columnHeaderIndex] = dt.Columns[columnHeaderIndex - 1].ColumnName;
                    ws.Cells[1, columnHeaderIndex].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                }

                for (int rowIndex = 0; rowIndex < dt.Rows.Count; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < dt.Columns.Count; columnIndex++)
                    {
                        ws.Cells[rowIndex + 2, columnIndex + 1] = dt.Rows[rowIndex].ItemArray[columnIndex].ToString();
                    }
                }

                ws.Columns.AutoFit();
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            saveFile.Title = "Excel 저장위치 지정";
            saveFile.DefaultExt = "xlsx";
            saveFile.Filter = "Xlsx files(*.xlsx)|*.xlsx|Xls files(*.xls)|*.xls";
            saveFile.ShowDialog();

            if (saveFile.FileNames.Length > 0)
            {
                foreach (string filename in saveFile.FileNames)
                {
                    string savePath = filename;
                    if (Path.GetExtension(savePath) == ".xls")
                    {
                        excelWorkBook.SaveAs(savePath, Excel.XlFileFormat.xlWorkbookNormal);
                    }
                    else if (Path.GetExtension(savePath) == ".xlsx")
                    {
                        excelWorkBook.SaveAs(savePath, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    }
                    excelWorkBook.Close(true);
                    ap.Quit();
                }
            }
        }
    }
}
