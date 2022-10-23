using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;  
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace GymManager
{
    public partial class GymManager : Form
    {
        MySqlConnection connection =
        new MySqlConnection("Server=localhost;Port=3306;Database=c_project;Uid=root;Pwd=qwer;");

        int check = 0;

        public int DBCount(string tableName)    // 저장되어 있는 열 개수 반환
        {
            int myCount = 0;
            string query = "";

            switch (tableName)
            {
                case "MEMBER":
                    query = "SELECT COUNT(m_num) FROM MEMBER;";
                    break;
                case "TRAINER":
                    query = "SELECT COUNT(t_num) FROM TRAINER;";
                    break;
                case "GX":
                    query = "SELECT COUNT(g_num) FROM GX;";
                    break;
                case "SCHEDULE":
                    query = "SELECT COUNT(s_num) FROM SCHEDULE;";
                    break;
                case "REGISTER":
                    query = "SELECT COUNT(r_num) FROM REGISTER;";
                    break;
                case "ATTEND":
                    query = "SELECT COUNT(a_num) FROM ATTEND;";
                    break;
            }
            try
            {

                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);

                myCount = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
                return myCount;
            }
            catch
            {
                return -1;
            }
        }

        public int[] getDBNum(string tableName)     // NUM 값 배열로 반환
        {
            int[] result;

            if (tableName == "REGISTER")
                result = new int[6];
            else
                result = new int[7];

            int cnt = DBCount(tableName);
            string selectQuery = "";

            switch (tableName)
            {
                case "MEMBER":
                    selectQuery = "SELECT * FROM MEMBER;";
                    break;
                case "TRAINER":
                    selectQuery = "SELECT * FROM TRAINER;";
                    break;
                case "GX":
                    selectQuery = "SELECT * FROM GX;";
                    break;
                case "SCHEDULE":
                    selectQuery = "SELECT * FROM SCHEDULE;";
                    break;
                case "REGISTER":
                    selectQuery = "SELECT * FROM REGISTER;";
                    break;
            }

            int i = 0;
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result[i] = int.Parse(reader.GetString(0));
                    i++;
                }
                connection.Close();
                return result;
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            return result;
        }

        public void memberDataList()    // memberListView 출력
        {
            memberList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("MEMBER");
                string selectQuery = "SELECT * FROM MEMBER;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] memberInfo = new String[cnt, 7];

                while (reader.Read())
                {
                    info = new ListViewItem(reader.GetString(0));
                    for (int j = 1; j < 7; j++)
                    {
                        memberInfo[i, j] = reader.GetString(j);
                        info.SubItems.Add(memberInfo[i, j]);
                    }
                    memberList.Items.Add(info);
                    i++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void trainerDataList()    // trainerListView 출력
        {
            trainerList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("TRAINER");
                string selectQuery = "SELECT * FROM TRAINER;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] trainerInfo = new String[cnt, 7];

                while (reader.Read())
                {
                    info = new ListViewItem(reader.GetString(0));
                    for (int j = 1; j < 7; j++)
                    {
                        trainerInfo[i, j] = reader.GetString(j);
                        info.SubItems.Add(trainerInfo[i, j]);
                    }
                    trainerList.Items.Add(info);
                    i++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void GXDataList()    // trainerListView 출력
        {
            GXList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("GX");
                string selectQuery = "SELECT * FROM GX;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] GXInfo = new string[cnt, 7];

                while (reader.Read())
                {
                    info = new ListViewItem(reader.GetString(0));
                    for (int j = 1; j < 7; j++)
                    {
                        GXInfo[i, j] = reader.GetString(j);
                        info.SubItems.Add(GXInfo[i, j]);
                    }
                    GXList.Items.Add(info);
                    i++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void timeTrainerDataList()
        {
            timeTrainerList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("TRAINER");
                string selectQuery = "SELECT * FROM TRAINER;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] trainerInfo = new String[cnt, 7];

                while (reader.Read())
                {
                    info = new ListViewItem(reader.GetString(0));
                    for (int j = 1; j < 7; j++)
                    {
                        trainerInfo[i, j] = reader.GetString(j);
                        info.SubItems.Add(trainerInfo[i, j]);
                    }
                    timeTrainerList.Items.Add(info);
                    i++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void timeGXDateList()
        {
            timeGXList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("GX");
                string selectQuery = "SELECT * FROM GX;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] GXInfo = new string[cnt, 7];

                while (reader.Read())
                {
                    info = new ListViewItem(reader.GetString(0));
                    for (int j = 1; j < 7; j++)
                    {
                        GXInfo[i, j] = reader.GetString(j);
                        info.SubItems.Add(GXInfo[i, j]);
                    }
                    timeGXList.Items.Add(info);
                    i++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void registerMemberDataList()
        {
            registerMemberList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("MEMBER");
                string selectQuery = "SELECT * FROM MEMBER;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] memberInfo = new String[cnt, 7];

                while (reader.Read())
                {
                    info = new ListViewItem(reader.GetString(0));
                    for (int j = 1; j < 7; j++)
                    {
                        memberInfo[i, j] = reader.GetString(j);
                        info.SubItems.Add(memberInfo[i, j]);
                    }
                    registerMemberList.Items.Add(info);
                    i++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void scheduleDataList()
        {
            timeList.Items.Clear();
            try
            {
                int cnt = DBCount("SCHEDULE");

                ListViewItem info;

                string selectQuery = "SELECT s.s_num, s.s_g_name, gx.g_day, s.s_start_time, s.s_end_time, gx.g_start_day, gx.g_end_day, t.t_name, gx.g_cash, gx.g_max_member "
                    + "FROM schedule s, gx, trainer t "
                    + "WHERE s.g_num = gx.g_num AND s.t_num = t.t_num;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] scheduleInfo = new String[cnt, 9];

                while (reader.Read())
                {
                    scheduleInfo[i, 0] = reader.GetString(0);

                    for (int j = 1; j < 10; j++)
                    {
                        if (j == 4)
                        {
                            scheduleInfo[i, j - 1] += " ~ " + reader.GetString(j);
                            continue;
                        }
                        if (j < 4)
                        {
                            scheduleInfo[i, j] = reader.GetString(j);
                            if (j == 3)
                                continue;
                        }
                        if (j > 4)
                        {
                            scheduleInfo[i, j - 1] = reader.GetString(j);
                        }
                    }
                    i++;
                }

                int temp;

                for (i = 0; i < cnt - 1; i++)
                {
                    for (int j = 0; j < (cnt - i) - 1; j++)
                    {
                        if (int.Parse(scheduleInfo[j, 0]) > int.Parse(scheduleInfo[j + 1, 0]))
                        {
                            temp = int.Parse(scheduleInfo[j, 0]);
                            scheduleInfo[j, 0] = scheduleInfo[j + 1, 0];
                            scheduleInfo[j + 1, 0] = temp.ToString();
                        }
                    }
                }

                for (i = 0; i < cnt; i++)
                {
                    info = new ListViewItem(scheduleInfo[i, 0]);
                    for (int j = 1; j < 9; j++)
                    {
                        info.SubItems.Add(scheduleInfo[i, j]);
                    }
                    timeList.Items.Add(info);
                }


                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void registerTimeDataList()
        {
            registerTimeList.Items.Clear();
            try
            {
                int cnt = DBCount("SCHEDULE");

                ListViewItem info;

                string selectQuery = "SELECT s.s_num, s.s_g_name, gx.g_day, s.s_start_time, s.s_end_time, gx.g_start_day, gx.g_end_day, t.t_name, gx.g_cash, gx.g_max_member "
                    + "FROM schedule s, gx, trainer t "
                    + "WHERE s.g_num = gx.g_num AND s.t_num = t.t_num;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] scheduleInfo = new String[cnt, 9];

                while (reader.Read())
                {
                    scheduleInfo[i, 0] = reader.GetString(0);

                    for (int j = 1; j < 10; j++)
                    {
                        if (j == 4)
                        {
                            scheduleInfo[i, j - 1] += " ~ " + reader.GetString(j);
                            continue;
                        }
                        if (j < 4)
                        {
                            scheduleInfo[i, j] = reader.GetString(j);
                            if (j == 3)
                                continue;
                        }
                        if (j > 4)
                        {
                            scheduleInfo[i, j - 1] = reader.GetString(j);
                        }
                    }
                    i++;
                }

                int temp;

                for (i = 0; i < cnt - 1; i++)
                {
                    for (int j = 0; j < (cnt - i) - 1; j++)
                    {
                        if (int.Parse(scheduleInfo[j, 0]) > int.Parse(scheduleInfo[j + 1, 0]))
                        {
                            temp = int.Parse(scheduleInfo[j, 0]);
                            scheduleInfo[j, 0] = scheduleInfo[j + 1, 0];
                            scheduleInfo[j + 1, 0] = temp.ToString();
                        }
                    }
                }

                for (i = 0; i < cnt; i++)
                {
                    info = new ListViewItem(scheduleInfo[i, 0]);
                    for (int j = 1; j < 9; j++)
                    {
                        info.SubItems.Add(scheduleInfo[i, j]);
                    }
                    registerTimeList.Items.Add(info);
                }


                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void registerDataList()
        {
            registerList.Items.Clear();
            try
            {
                ListViewItem info;

                int cnt = DBCount("REGISTER");
                string selectQuery = "SELECT r.r_num, m.m_name, m.m_phone, s.s_g_name, g.g_day, g.g_start_day, g.g_end_day, s.s_t_name, g.g_cash, r.r_register_day"
                    + " FROM register r, gx g, schedule s, member m "
                    + "WHERE m.m_num = r.m_num AND r.s_num = s.s_num AND g.g_num = s.g_num;";

                int i = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                string[,] registerInfo = new String[cnt, 10];

                while (reader.Read())
                {
                    registerInfo[i, 0] = reader.GetString(0);
                    for (int j = 1; j < 10; j++)
                    {
                        registerInfo[i, j] = reader.GetString(j);
                    }
                    i++;
                }

                string temp;
                for (i = 0; i < cnt - 1; i++)
                {
                    for (int j = 0; j < (cnt - i) - 1; j++)
                    {
                        if (int.Parse(registerInfo[j, 0]) > int.Parse(registerInfo[j + 1, 0]))
                        {
                            for (int z = 0; z < 10; z++)
                            {
                                temp = registerInfo[j, z];
                                registerInfo[j, z] = registerInfo[j + 1, z];
                                registerInfo[j + 1, z] = temp;
                            }
                        }
                    }
                }

                for (i = 0; i < cnt; i++)
                {
                    info = new ListViewItem(registerInfo[i, 0]);
                    for (int j = 1; j < 10; j++)
                    {
                        info.SubItems.Add(registerInfo[i, j]);
                    }
                    registerList.Items.Add(info);
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        public void checkMemberDataList(string name)
        {          
            ListView.ListViewItemCollection memberItems = memberList.Items;
            ListViewItem memberListItem = new ListViewItem();

            ListView.ListViewItemCollection attendItems = attendMemberList.Items;
            ListViewItem attendListItem = new ListViewItem();

            int cnt = DBCount("MEMBER");
            string[] info = new string[7];

            for (int i = 0; i < cnt; i++)
            {
                memberListItem = memberItems[i];

                if (memberListItem.SubItems[1].Text.ToString().Equals(name))
                {
                    for (int j = 0; j < 7; j++)
                    {
                        info[j] = memberListItem.SubItems[j].Text.ToString();
                        attendListItem.SubItems.Add(info[j]);
                    }
                    attendMemberList.Items.Add(attendListItem);
                    return;
                }
            }
        }

        public void checkStatusMemberDataList(string memberName, string name, string GXName, string startTime, string endTime)
        {
            int mNum = 0;
            int mNumCount = 0;
            string attend = "";

            try
            {
                string selectQuery = "SELECT a_m_num FROM ATTEND WHERE "
                    + "a_m_name = '" + memberName + "' AND "
                    + "a_g_name = '" + GXName + "' AND "
                    + "a_start_time = '" + startTime + "' AND "
                    + "a_end_time = '" + endTime + "';";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();

                mNum = int.Parse(reader.GetString(0));

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            try
            {
                string selectQuery = "SELECT a_m_num, a_attend, a_g_name FROM ATTEND WHERE "
                    + "a_m_num = " + mNum.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (int.Parse(reader.GetString(0)) == mNum && reader.GetString(1).Equals("출석") && reader.GetString(2).Equals(StatusGXName.Text.ToString()))
                        mNumCount++;
                }

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            try
            {
                string selectQuery = "SELECT a_attend FROM ATTEND WHERE "
                    + "a_m_num = " + mNum.ToString() + " AND "
                    + "a_g_name = '" + GXName + "' AND "
                    + "a_day = '" + StatusDtp.Text.ToString() + "' AND "
                    + "a_start_time = '" + startTime + "' AND "
                    + "a_end_time = '" + endTime + "';";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                reader.Read();

                attend = reader.GetString(0);

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            ListView.ListViewItemCollection memberItems = memberList.Items;
            ListViewItem memberListItem = new ListViewItem();

            ListView.ListViewItemCollection attendItems = StatusMemberList.Items;
            ListViewItem attendListItem = new ListViewItem(attend);

            int cnt = DBCount("MEMBER");
            string[] info = new string[8];

            for (int i = 0; i < cnt; i++)
            {
                memberListItem = memberItems[i];

                if (memberListItem.SubItems[1].Text.ToString().Equals(name))
                {
                    for (int j = 0; j < 7; j++)
                    {
                        info[j] = memberListItem.SubItems[j].Text.ToString();
                        attendListItem.SubItems.Add(info[j]);
                        if(j == 6)
                        {
                            info[j + 1] = mNumCount.ToString() + "일";
                            attendListItem.SubItems.Add(info[j + 1]);
                        }
                    }
                    StatusMemberList.Items.Add(attendListItem);
                    return;
                }
            }
        }

        public void attendCbbInit()
        {
            attendGXName.Items.Clear();
            StatusGXName.Items.Clear();
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = GXList.Items;

                ListViewItem listItem = new ListViewItem();

                for (int i = 0; i < int.Parse(GXList.Items.Count.ToString()); i++)
                {
                    listItem = items[i];

                    attendGXName.Items.Add(listItem.SubItems[1].Text);
                    StatusGXName.Items.Add(listItem.SubItems[1].Text);
                }
            }
        }

        public void numSort(string tableName)
        {
            string num = "";
            try
            {
                int cnt = DBCount(tableName);

                int[] array = getDBNum(tableName);

                string updateQuery;
                string aiQuery = "ALTER TABLE " + tableName + " AUTO_INCREMENT=" + (cnt + 1) + ";";

                switch (tableName)
                {
                    case "MEMBER":
                        num = "m_num";
                        break;
                    case "TRAINER":
                        num = "t_num";
                        break;
                    case "GX":
                        num = "g_num";
                        break;
                    case "SCHEDULE":
                        num = "s_num";
                        break;
                    case "REGISTER":
                        num = "r_num";
                        break;
                }
                connection.Open();

                for (int i = 1; i <= cnt; i++)
                {
                    if (array[i - 1] != i)
                    {
                        updateQuery = "UPDATE " + tableName + " SET " + num + "="
                            + num + "-1" + " WHERE " + num + "= " + array[i - 1] + ";";
                        MySqlCommand command2 = new MySqlCommand(updateQuery, connection);
                        command2.ExecuteNonQuery();
                    }
                }

                MySqlCommand command = new MySqlCommand(aiQuery, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }   // 삭제한 뒤부터 번호 -1씩 수정

        public void showInfo()
        {
            memberDataList();
            trainerDataList();
            GXDataList();
            timeTrainerDataList();
            timeGXDateList();
            registerMemberDataList();
            registerTimeDataList();
            scheduleDataList();
            registerDataList();
            attendCbbInit();
        }

        public GymManager()
        {
            InitializeComponent();

            showInfo();

            timeGXDay.SelectedIndex = 0;
            timeStartCbb.SelectedIndex = 0;
            timeEndCbb.SelectedIndex = 0;
            attendStartDtp.SelectedIndex = 0;
            attendEndDtp.SelectedIndex = 0;
            StatusStartDtp.SelectedIndex = 0;
            StatusEndDtp.SelectedIndex = 0;


        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void listView8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void memberResetBtn_Click(object sender, EventArgs e)
        {
            memberNum.Text = "";
            memberName.Text = "";
            mRadoiBtn.Checked = false;
            fRadoiBtn.Checked = false;
            memberAge.Text = "";
            memberPhone.Text = "";
            memberEmail.Text = "";
            memberAddress.Text = "";
        }

        private void trainerResetBtn_Click(object sender, EventArgs e)
        {
            trainerNum.Text = "";
            trainerName.Text = "";
            trainerFRadioBtn.Checked = false;
            trainerMRadioBtn.Checked = false;
            trainerAge.Text = "";
            trainerPhone.Text = "";
            trainerEmail.Text = "";
            trainerAddress.Text = "";
        }

        private void GXResetBtn_Click(object sender, EventArgs e)
        {
            GXNum.Text = "";
            GXName.Text = "";
            GXCash.Text = "";
            GXMaxMember.Text = "";
            GXMon.Checked = false;
            GXTue.Checked = false;
            GXWen.Checked = false;
            GXTur.Checked = false;
            GXFri.Checked = false;
        }

        private void payResetBtn_Click(object sender, EventArgs e)
        {
            reserveCash.Text = "";

            rMemberNum.Text = "";
            registerMemberName.Text = "";
            registerMemberPhone.Text = "";
            registerMemberEmail.Text = "";

            rTimeNum.Text = "";
            registerTimeGXName.Text = "";
            registerTimeDay.Text = "";
            registerTimeMember.Text = "";
            registerTimeCash.Text = "";
            registerTimeTrainer.Text = "";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void trainerFRadioBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void memberInfoGroup_Enter(object sender, EventArgs e)
        {

        }

        private void memberGender_Enter(object sender, EventArgs e)
        {

        }

        private void mRadoiBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void memberRegisterBtn_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (mRadoiBtn.Checked == true)
                gender = mRadoiBtn.Text.ToString();
            else if (fRadoiBtn.Checked == true)
                gender = fRadoiBtn.Text.ToString();

            if (gender == "")
            {
                MessageBox.Show("성별을 선택 하십시오.");
                return;
            }
            if (memberPhone.Text.ToString() == "")
            {
                MessageBox.Show("전화번호를 입력 하십시오.");
                return;
            }
            if (memberName.Text.ToString() == "")
            {
                MessageBox.Show("이름을 입력 하십시오.");
                return;
            }
            if (memberAge.Text.ToString() == "")
            {
                MessageBox.Show("나이를 입력 하십시오.");
                return;
            }

            string insertQuery = "INSERT INTO MEMBER(m_name, m_gender, m_age, m_phone, m_email, m_address) VALUES('"
                + memberName.Text.ToString() + "', "
                + "'" + gender + "', "
                + "'" + memberAge.Text.ToString() + "', "
                + "'" + memberPhone.Text.ToString() + "', "
                + "'" + memberEmail.Text.ToString() + "', "
                + "'" + memberAddress.Text.ToString() + "');";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("등록 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            memberNum.Text = "";
            memberName.Text = "";
            mRadoiBtn.Checked = false;
            fRadoiBtn.Checked = false;
            memberAge.Text = "";
            memberPhone.Text = "";
            memberEmail.Text = "";
            memberAddress.Text = "";
            showInfo();
        }

        private void fRadoiBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void memberList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void memberModifyBtn_Click(object sender, EventArgs e)
        {
            if (memberNum.Text == "")
            {
                MessageBox.Show("리스트에서 수정할 데이터를 클릭하세요.");
                return;
            }
            string gender = "";
            if (mRadoiBtn.Checked == true)
                gender = mRadoiBtn.Text.ToString();
            else if (fRadoiBtn.Checked == true)
                gender = fRadoiBtn.Text.ToString();

            string updateQuery = "UPDATE MEMBER SET "
                + "m_name = '" + memberName.Text.ToString() + "', "
                + "m_gender = '" + gender + "', "
                + "m_age = '" + memberAge.Text.ToString() + "', "
                + "m_phone = '" + memberPhone.Text.ToString() + "', "
                + "m_email = '" + memberEmail.Text.ToString() + "', "
                + "m_address = '" + memberAddress.Text.ToString() + "' WHERE "
                + "m_num = " + memberNum.Text.ToString() + ";";

            string updateInfo = "수정사항이 맞습니까?" + "\n"
                + "회원이름: " + memberName.Text.ToString() + "\n"
                + "성별: " + gender + "\n"
                + "나이: " + memberAge.Text.ToString() + "\n"
                + "전화번호: " + memberPhone.Text.ToString() + "\n"
                + "이메일: " + memberEmail.Text.ToString() + "\n"
                + "주소: " + memberAddress.Text.ToString();

            if (MessageBox.Show(updateInfo, "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(updateQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("수정 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            memberNum.Text = "";
            memberName.Text = "";
            mRadoiBtn.Checked = false;
            fRadoiBtn.Checked = false;
            memberAge.Text = "";
            memberPhone.Text = "";
            memberEmail.Text = "";
            memberAddress.Text = "";
            showInfo();
        }


        private void memberDeleteBtn_Click(object sender, EventArgs e)
        {
            string gender = ""; // 문자열을 받는 gender란 변수명을 가진 변수 선언 초기화 ""
            if (mRadoiBtn.Checked == true)
                gender = mRadoiBtn.Text.ToString(); // 만약에 남성 버튼이 클릭돼 있으면 gender를 남성으로 바꾸겠다
            else if (fRadoiBtn.Checked == true)
                gender = fRadoiBtn.Text.ToString();

            if(memberNum.Text.ToString() == "")
            {
                MessageBox.Show("삭제할 데이터를 선택하세요.");
                return;
            }
            if (MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                string selectQuery = "SELECT COUNT(m_num) FROM REGISTER WHERE "
                    + "m_num = " + memberNum.Text.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);   

                int cnt = Convert.ToInt32(command.ExecuteScalar()); 

                if (cnt != 0)
                {
                    MessageBox.Show("현재 등록되어 있는 회원이라 삭제가 불가합니다.");
                    connection.Close();
                    return;                                         // 등록되어있는 m_num이 삭제하려는 m_num과 하나라도 일치하면 메세지박스를 띄우고 종료
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            string deleteQuery = "DELETE FROM MEMBER WHERE "
                + "m_name = '" + memberName.Text.ToString() + "' AND "
                + "m_gender = '" + gender + "' AND "
                + "m_phone = '" + memberPhone.Text.ToString() + "';";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);   //C#에서 작성한 쿼리를 디비로 보낼 수 있게 도와주는 명령문

                if (command.ExecuteNonQuery() == 1)                                 //메소드를 실행했을때 정상적으로 실행이되면 반환값이1
                    MessageBox.Show("삭제 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            memberNum.Text = "";
            memberName.Text = "";
            mRadoiBtn.Checked = false;
            fRadoiBtn.Checked = false;
            memberAge.Text = "";
            memberPhone.Text = "";
            memberEmail.Text = "";
            memberAddress.Text = "";
            numSort("MEMBER");
            showInfo();
        }

        private void memberList_MouseClick(object sender, MouseEventArgs e)
        {
            if (memberList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection items = memberList.SelectedItems;
                ListViewItem listItem = items[0];

                memberNum.Text = listItem.SubItems[0].Text;
                memberName.Text = listItem.SubItems[1].Text;

                if (listItem.SubItems[2].Text == "남성")
                    mRadoiBtn.Checked = true;
                else if (listItem.SubItems[2].Text == "여성")
                    fRadoiBtn.Checked = true;

                memberAge.Text = listItem.SubItems[3].Text;
                memberPhone.Text = listItem.SubItems[4].Text;
                memberEmail.Text = listItem.SubItems[5].Text;
                memberAddress.Text = listItem.SubItems[6].Text;
            }

        }

        private void memberList_Double_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void memberListSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM MEMBER;";
                string result = "";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = "";
                    if (reader.GetString(1) == memberListName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 1:
                                    result += "이름: " + reader.GetString(j) + "\n";
                                    break;
                                case 2:
                                    result += "성별: " + reader.GetString(j) + "\n";
                                    break;
                                case 3:
                                    result += "나이: " + reader.GetString(j) + "\n";
                                    break;
                                case 4:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 5:
                                    result += "메일: " + reader.GetString(j) + "\n";
                                    break;
                                case 6:
                                    result += "주소: " + reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                        MessageBox.Show(result, "회원정보");
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void trainerRegisterBtn_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (trainerMRadioBtn.Checked == true)
                gender = trainerMRadioBtn.Text.ToString();
            else if (trainerFRadioBtn.Checked == true)
                gender = trainerFRadioBtn.Text.ToString();

            if (gender == "")
            {
                MessageBox.Show("성별을 선택 하십시오.");
                return;
            }
            if (trainerPhone.Text.ToString() == "")
            {
                MessageBox.Show("전화번호를 입력 하십시오.");
                return;
            }
            if (trainerName.Text.ToString() == "")
            {
                MessageBox.Show("이름을 입력 하십시오.");
                return;
            }
            if (trainerAge.Text.ToString() == "")
            {
                MessageBox.Show("나이를 입력 하십시오.");
                return;
            }

            string insertQuery = "INSERT INTO TRAINER(t_name, t_gender, t_age, t_phone, t_email, t_address) VALUES('"
                + trainerName.Text.ToString() + "', "
                + "'" + gender + "', "
                + "'" + trainerAge.Text.ToString() + "', "
                + "'" + trainerPhone.Text.ToString() + "', "
                + "'" + trainerEmail.Text.ToString() + "', "
                + "'" + trainerAddress.Text.ToString() + "');";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("등록 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            trainerNum.Text = "";
            trainerName.Text = "";
            trainerFRadioBtn.Checked = false;
            trainerMRadioBtn.Checked = false;
            trainerAge.Text = "";
            trainerPhone.Text = "";
            trainerEmail.Text = "";
            trainerAddress.Text = "";
            showInfo();
        }

        private void trainerDeleteBtn_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (trainerMRadioBtn.Checked == true)
                gender = trainerMRadioBtn.Text.ToString();
            else if (trainerFRadioBtn.Checked == true)
                gender = trainerFRadioBtn.Text.ToString();

            if (trainerNum.Text.ToString() == "")
            {
                MessageBox.Show("삭제할 데이터를 선택하세요.");
                return;
            }

            string deleteQuery = "DELETE FROM TRAINER WHERE "
            + "t_num = " + trainerNum.Text.ToString() + ";";        //트레이너 테이블에 입력되어있는 이름,성별,번호가
                                                                                //트레이너 테이블의 정보와 같은지 확인해서 일치하면 삭제시키는 퀴리

            if (MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                string selectQuery = "SELECT COUNT(t_num) FROM SCHEDULE WHERE "
                    + "t_num = " + trainerNum.Text.ToString() + ";";            //스케줄 테이블의 t_num이 트레이너의 번호와 같은 값이 몇개인지 검색을하는 쿼리문

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                int cnt = Convert.ToInt32(command.ExecuteScalar());             //위 쿼리문의 반환값을 정수형으로 바꿔서 cnt에 저장

                if (cnt != 0)
                {
                    MessageBox.Show("현재 등록되어 있는 회원이라 삭제가 불가합니다.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("삭제 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            trainerNum.Text = "";
            trainerName.Text = "";
            trainerFRadioBtn.Checked = false;
            trainerMRadioBtn.Checked = false;
            trainerAge.Text = "";
            trainerPhone.Text = "";
            trainerEmail.Text = "";
            trainerAddress.Text = "";
            numSort("TRAINER");
            showInfo();
        }

        private void trainerListSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM TRAINER;";
                string result = "";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = "";
                    if (reader.GetString(1) == trainerListName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 1:
                                    result += "이름: " + reader.GetString(j) + "\n";
                                    break;
                                case 2:
                                    result += "성별: " + reader.GetString(j) + "\n";
                                    break;
                                case 3:
                                    result += "나이: " + reader.GetString(j) + "\n";
                                    break;
                                case 4:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 5:
                                    result += "메일: " + reader.GetString(j) + "\n";
                                    break;
                                case 6:
                                    result += "주소: " + reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                        MessageBox.Show(result, "트레이너 정보");
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void GXRegisterBtn_Click(object sender, EventArgs e)
        {
            if (GXName.Text.ToString() == "" || GXCash.Text.ToString() == "" || GXMaxMember.Text.ToString() == "")
            {
                MessageBox.Show("정보 입력 하십시오.");
                return;
            }
            if (GXMon.Checked == false && GXTue.Checked == false && GXWen.Checked == false && GXTur.Checked == false && GXFri.Checked == false)
            {
                MessageBox.Show("요일을 선택 하십시오.");
                return;
            }

            string gDay = "";
            int cnt = 0;

            if (GXMon.Checked == true)
            {
                gDay += "월";
                cnt++;
            }
            if (GXTue.Checked == true)
            {
                if (cnt == 0)
                    gDay += "화";
                else
                    gDay += ", 화";
                cnt++;
            }
            if (GXWen.Checked == true)
            {
                if (cnt == 0)
                    gDay += "수";
                else
                    gDay += ", 수";
                cnt++;
            }
            if (GXTur.Checked == true)
            {
                if (cnt == 0)
                    gDay += "목";
                else
                    gDay += ", 목";
                cnt++;
            }
            if (GXFri.Checked == true)
            {
                if (cnt == 0)
                    gDay += "금";
                else
                    gDay += ", 금";
            }

            string insertQuery = "INSERT INTO GX(g_name, g_day, g_cash, g_max_member, g_start_day, g_end_day) VALUES('"
                + GXName.Text.ToString() + "', "
                + "'" + gDay + "', "
                + GXCash.Text.ToString() + ", "
                + GXMaxMember.Text.ToString() + ", "
                + "'" + GXStartDtp.Text.ToString() + "', "
                + "'" + GXEndDtp.Text.ToString() + "');";

            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("등록 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            GXNum.Text = "";
            GXName.Text = "";
            GXCash.Text = "";
            GXMaxMember.Text = "";
            GXMon.Checked = false;
            GXTue.Checked = false;
            GXWen.Checked = false;
            GXTur.Checked = false;
            GXFri.Checked = false;
            showInfo();
        }

        private void GXListSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM GX;";
                string result = "";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = "";
                    if (reader.GetString(1) == GXListName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 1:
                                    result += "프로그램명: " + reader.GetString(j) + "\n";
                                    break;
                                case 2:
                                    result += "요일: " + reader.GetString(j) + "\n";
                                    break;
                                case 3:
                                    result += "금액: " + reader.GetString(j) + "\n";
                                    break;
                                case 4:
                                    result += "최대인원: " + reader.GetString(j) + "\n";
                                    break;
                                case 5:
                                    result += "시작일: " + reader.GetString(j) + "\n";
                                    break;
                                case 6:
                                    result += "종료일: " + reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                        MessageBox.Show(result, "GX정보");
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void GXMaxMember_TextChanged(object sender, EventArgs e)
        {

        }

        private void GXDeleteBtn_Click(object sender, EventArgs e)
        {
            if (GXNum.Text.ToString() == "")
            {
                MessageBox.Show("삭제할 데이터를 선택하세요.");
                return;
            }

            string gDay = "";
            int cnt = 0;

            if (GXMon.Checked == true)
            {
                gDay += "월";
                cnt++;                          //처음 들어온 값인지를 확인하기 위해서
            }
            if (GXTue.Checked == true)
            {
                if (cnt == 0)
                    gDay += "화";
                else
                    gDay += ", 화";
                cnt++;
            }
            if (GXWen.Checked == true)
            {
                if (cnt == 0)
                    gDay += "수";
                else
                    gDay += ", 수";
                cnt++;
            }
            if (GXTur.Checked == true)
            {
                if (cnt == 0)
                    gDay += "목";
                else
                    gDay += ", 목";
                cnt++;
            }
            if (GXFri.Checked == true)
            {
                if (cnt == 0)
                    gDay += "금";
                else
                    gDay += ", 금";
            }

            string deleteQuery = "DELETE FROM GX WHERE "
                + "g_name = '" + GXName.Text.ToString() + "' AND "
                + "g_day = '" + gDay + "';";                                //GX명과 요일을 검색해서 GX테이블의 값이랑 일치하면 삭제하는 쿼리문

            if (MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                string selectQuery = "SELECT COUNT(g_num) FROM SCHEDULE WHERE "
                    + "g_num = " + GXNum.Text.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count != 0)
                {
                    MessageBox.Show("현재 등록되어 있는 프로그램이라 삭제가 불가합니다.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("삭제 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            GXNum.Text = "";
            GXName.Text = "";
            GXCash.Text = "";
            GXMaxMember.Text = "";
            GXMon.Checked = false;
            GXTue.Checked = false;
            GXWen.Checked = false;
            GXTur.Checked = false;
            GXFri.Checked = false;
            numSort("GX");
            showInfo();
        }

        private void timeGXSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM GX;";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(1) == timeGXName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    timeGXNum.Text = reader.GetString(j);
                                    break;
                                case 2:
                                    timeGXDay.Text = reader.GetString(j);
                                    break;
                                case 3:
                                    timeGXCash.Text = reader.GetString(j);
                                    break;
                                case 4:
                                    timeGXMaxMember.Text = reader.GetString(j);
                                    break;
                                case 5:
                                    timeGXStartDtp.Text = reader.GetString(j);
                                    break;
                                case 6:
                                    timeGXEndDtp.Text = reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void timeTrainerSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM TRAINER;";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(1) == timeTrainerName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    timeTrainerNum.Text = reader.GetString(j);
                                    break;
                                case 3:
                                    timeTrainerAge.Text = reader.GetString(j);
                                    break;
                                case 4:
                                    timeTrainerPhone.Text = reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void timeRegisterBtn_Click(object sender, EventArgs e)
        {
            if (timeGXNum.Text.ToString() == "")
            {
                MessageBox.Show("GX정보를 입력하세요.");
                return;
            }
            if (timeTrainerNum.Text.ToString() == "")
            {
                MessageBox.Show("트레이너 정보를 입력하세요.");
                return;
            }
            if (timeStartCbb.Text.ToString() == "시간 선택" || timeEndCbb.Text.ToString() == "시간 선택")
            {
                MessageBox.Show("시간을 선택하세요.");
                return;
            }
            try
            {
                string selectQuery = "SELECT COUNT(s_num) FROM SCHEDULE WHERE "
                    + "g_num = " + timeGXNum.Text.ToString() + " AND "
                    + "t_num = " + timeTrainerNum.Text.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                int cnt = Convert.ToInt32(command.ExecuteScalar());

                if (cnt != 0)
                {
                    MessageBox.Show("이미 등록되어 있습니다.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            try
            {
                string insertQuery = "INSERT INTO SCHEDULE(s_start_time, s_end_time, g_num, t_num, s_g_name, s_t_name) VALUES ("
                    + "'" + Regex.Replace(timeStartCbb.Text.ToString(), @"\s", "") + "', "
                    + "'" + Regex.Replace(timeEndCbb.Text.ToString(), @"\s", "") + "', "
                    + timeGXNum.Text.ToString() + ", "
                    + timeTrainerNum.Text.ToString() + ", "
                    + "'" + timeGXName.Text.ToString() + "', "
                    + "'" + timeTrainerName.Text.ToString() + "');";

                connection.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("등록 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
                showInfo();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            timeGXNum.Text = "";
            timeGXName.Text = "";
            timeGXDay.Text = "";
            timeGXStartDtp.Text = "";
            timeGXEndDtp.Text = "";
            timeGXCash.Text = "";
            timeGXMaxMember.Text = "";

            timeTrainerNum.Text = "";
            timeTrainerName.Text = "";
            timeTrainerAge.Text = "";
            timeTrainerPhone.Text = "";
            timeStartCbb.Text = "";
            timeEndCbb.Text = "";
        }

        private void timeTrainerInfoGroup_Enter(object sender, EventArgs e)
        {

        }

        private void timeDeleteBtn_Click(object sender, EventArgs e)
        {

            if (timeGXNum.Text == "" || timeTrainerNum.Text == "" || timeStartCbb.Text == "시간 선택" || timeEndCbb.Text == "시간 선택")
            {
                MessageBox.Show("삭제할 정보를 입력하세요");
                return;
            }

            string deleteQuery = "DELETE FROM SCHEDULE WHERE "
                + "g_num = " + timeGXNum.Text.ToString() + " AND "
                + "t_num = " + timeTrainerNum.Text.ToString() + " AND "
                + "s_g_name = '" + timeGXName.Text.ToString() + "' AND "
                + "s_t_name = '" + timeTrainerName.Text.ToString() + "';";

            if (MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            int s_num = 0;

            try
            {
                string selectQuery = "SELECT COUNT(s_num) FROM SCHEDULE WHERE "
                    + "g_num = " + timeGXNum.Text.ToString() + " AND "
                    + "t_num = " + timeTrainerNum.Text.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                int cnt = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
                if(cnt == 0)
                {
                    MessageBox.Show("삭제할 데이터가 없습니다.");
                    connection.Close();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            try
            {
                string selectQuery = "SELECT s_num FROM SCHEDULE WHERE "
                    + "g_num = " + timeGXNum.Text.ToString() + " AND "
                    + "t_num = " + timeTrainerNum.Text.ToString() + ";";
  
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();     //쿼리문의 값을 읽을 수 있게 해주는 객체
                reader.Read();  //읽음

                s_num = int.Parse(reader.GetString(0));

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            try
            {
                string selectQuery = "SELECT COUNT(s_num) FROM REGISTER WHERE "
                    + "s_num = " + s_num.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count != 0)
                {
                    MessageBox.Show("현재 등록되어 있는 회원이라 삭제가 불가합니다.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            try
            {

                connection.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("삭제 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            timeGXNum.Text = "";
            timeGXName.Text = "";
            timeGXDay.Text = "";
            timeGXStartDtp.Text = "";
            timeGXEndDtp.Text = "";
            timeGXCash.Text = "";
            timeGXMaxMember.Text = "";

            timeTrainerNum.Text = "";
            timeTrainerName.Text = "";
            timeTrainerAge.Text = "";
            timeTrainerPhone.Text = "";
            timeStartCbb.Text = "";
            timeEndCbb.Text = "";

            numSort("SCHEDULE");
            showInfo();
        }

        private void payRegisterBtn_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                MessageBox.Show("결제를 완료하세요");
                return;
            }
            if (registerMemberName.Text.ToString() == "")
            {
                MessageBox.Show("회원 정보를 입력하세요.");
                return;
            }
            if (registerTimeGXName.Text.ToString() == "")
            {
                MessageBox.Show("프로그램 정보를 입력하세요.");
                return;
            }

            ListView.SelectedListViewItemCollection items = registerTimeList.SelectedItems;
            ListViewItem listItem = items[0];

            if (int.Parse(registerTimeMember.Text.ToString()) >= int.Parse(listItem.SubItems[8].Text.ToString()))
            {
                MessageBox.Show("인원이 초과 되었습니다.");
                return;
            }

            try
            {
                string selectQuery = "SELECT COUNT(r_num) FROM REGISTER WHERE "
                    + "s_num = " + rTimeNum.Text.ToString() + " AND "
                    + "m_num = " + rMemberNum.Text.ToString() + ";";

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                int cnt = Convert.ToInt32(command.ExecuteScalar());

                if(cnt != 0)
                {
                    MessageBox.Show("이미 등록되어 있습니다.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            try
            {
                string insertQuery = "INSERT INTO REGISTER(r_cash, r_register_day, m_num, s_num, r_m_name) VALUES ("
                    + reserveCash.Text.ToString() + ", "
                    + "'" + registerPayDtp.Text.ToString() + "', "
                    + rMemberNum.Text.ToString() + ", "
                    + rTimeNum.Text.ToString() + ", "
                    + "'" + registerMemberName.Text.ToString() + "');";

                connection.Open();

                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("등록 하였습니다.");
                    int n = int.Parse(registerTimeMember.Text.ToString());
                    check = 0;
                    n++;
                    registerTimeMember.Text = n.ToString();
                }
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
                showInfo();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void registerTimeCash_TextChanged(object sender, EventArgs e)
        {

        }

        private void payDeleteBtn_Click(object sender, EventArgs e)
        {
            if (rMemberNum.Text == "" || rTimeNum.Text == "")
            {
                MessageBox.Show("정보를 입력하세요");
                return;
            }
            string deleteQuery = "DELETE FROM REGISTER WHERE "
                + "m_num = " + rMemberNum.Text.ToString() + " AND "
                + "s_num = " + rTimeNum.Text.ToString() + " AND "
                + "r_m_name = '" + registerMemberName.Text.ToString() + "';";

            if (MessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("삭제 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            numSort("REGISTER");
            showInfo();
        }

        private void registerMemberListSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM MEMBER;";
                string result = "";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = "";
                    if (reader.GetString(1) == registerMemberListName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 1:
                                    result += "이름: " + reader.GetString(j) + "\n";
                                    break;
                                case 2:
                                    result += "성별: " + reader.GetString(j) + "\n";
                                    break;
                                case 3:
                                    result += "나이: " + reader.GetString(j) + "\n";
                                    break;
                                case 4:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 5:
                                    result += "메일: " + reader.GetString(j) + "\n";
                                    break;
                                case 6:
                                    result += "주소: " + reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                        MessageBox.Show(result, "회원정보");
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void timeGXListSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM GX;";
                string result = "";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = "";
                    if (reader.GetString(1) == timeGXListName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 1:
                                    result += "프로그램명: " + reader.GetString(j) + "\n";
                                    break;
                                case 2:
                                    result += "요일: " + reader.GetString(j) + "\n";
                                    break;
                                case 3:
                                    result += "금액: " + reader.GetString(j) + "\n";
                                    break;
                                case 4:
                                    result += "최대인원: " + reader.GetString(j) + "\n";
                                    break;
                                case 5:
                                    result += "시작일: " + reader.GetString(j) + "\n";
                                    break;
                                case 6:
                                    result += "종료일: " + reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                        MessageBox.Show(result, "GX정보");
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void timeTrainerListSearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string selectQuery = "SELECT * FROM TRAINER;";
                string result = "";

                int cnt = 0;

                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = "";
                    if (reader.GetString(1) == timeTrainerListName.Text.ToString())
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 1:
                                    result += "이름: " + reader.GetString(j) + "\n";
                                    break;
                                case 2:
                                    result += "성별: " + reader.GetString(j) + "\n";
                                    break;
                                case 3:
                                    result += "나이: " + reader.GetString(j) + "\n";
                                    break;
                                case 4:
                                    result += "번호: " + reader.GetString(j) + "\n";
                                    break;
                                case 5:
                                    result += "메일: " + reader.GetString(j) + "\n";
                                    break;
                                case 6:
                                    result += "주소: " + reader.GetString(j);
                                    break;
                            }
                        }
                        cnt++;
                        MessageBox.Show(result, "트레이너 정보");
                    }
                }
                if (cnt == 0)
                    MessageBox.Show("해당 이름이 없습니다.");
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void trainerModifyBtn_Click(object sender, EventArgs e)
        {
            if (trainerNum.Text == "")
            {
                MessageBox.Show("리스트에서 수정할 데이터를 클릭하세요.");
                return;
            }
            string gender = "";
            if (trainerMRadioBtn.Checked == true)
                gender = mRadoiBtn.Text.ToString();
            else if (trainerFRadioBtn.Checked == true)
                gender = fRadoiBtn.Text.ToString();

            string updateQuery = "UPDATE TRAINER SET "
                + "t_name = '" + trainerName.Text.ToString() + "', "
                + "t_gender = '" + gender + "', "
                + "t_age = '" + trainerAge.Text.ToString() + "', "
                + "t_phone = '" + trainerPhone.Text.ToString() + "', "
                + "t_email = '" + trainerEmail.Text.ToString() + "', "
                + "t_address = '" + trainerAddress.Text.ToString() + "' WHERE "
                + "t_num = " + trainerNum.Text.ToString() + ";";

            string updateInfo = "수정사항이 맞습니까?" + "\n"
                + "트레이너 이름: " + trainerName.Text.ToString() + "\n"
                + "성별: " + gender + "\n"
                + "나이: " + trainerAge.Text.ToString() + "\n"
                + "전화번호: " + trainerPhone.Text.ToString() + "\n"
                + "이메일: " + trainerEmail.Text.ToString() + "\n"
                + "주소: " + trainerAddress.Text.ToString();

            if (MessageBox.Show(updateInfo, "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(updateQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("수정 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            trainerNum.Text = "";
            trainerName.Text = "";
            trainerFRadioBtn.Checked = false;
            trainerMRadioBtn.Checked = false;
            trainerAge.Text = "";
            trainerPhone.Text = "";
            trainerEmail.Text = "";
            trainerAddress.Text = "";
            showInfo();
        }

        private void trainerList_MouseClick(object sender, MouseEventArgs e)
        {
            if (trainerList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection items = trainerList.SelectedItems;
                ListViewItem listItem = items[0];

                trainerNum.Text = listItem.SubItems[0].Text;
                trainerName.Text = listItem.SubItems[1].Text;

                if (listItem.SubItems[2].Text == "남성")
                    trainerMRadioBtn.Checked = true;
                else if (listItem.SubItems[2].Text == "여성")
                    trainerFRadioBtn.Checked = true;

                trainerAge.Text = listItem.SubItems[3].Text;
                trainerPhone.Text = listItem.SubItems[4].Text;
                trainerEmail.Text = listItem.SubItems[5].Text;
                trainerAddress.Text = listItem.SubItems[6].Text;
            }
        }

        private void GXModifyBtn_Click(object sender, EventArgs e)
        {
            if (GXNum.Text == "")
            {
                MessageBox.Show("리스트에서 수정할 데이터를 클릭하세요.");
                return;
            }
            string gDay = "";
            int cnt = 0;

            if (GXMon.Checked == true)
            {
                gDay += "월";
                cnt++;
            }
            if (GXTue.Checked == true)
            {
                if (cnt == 0)
                    gDay += "화";
                else
                    gDay += ", 화";
                cnt++;
            }
            if (GXWen.Checked == true)
            {
                if (cnt == 0)
                    gDay += "수";
                else
                    gDay += ", 수";
                cnt++;
            }
            if (GXTur.Checked == true)
            {
                if (cnt == 0)
                    gDay += "목";
                else
                    gDay += ", 목";
                cnt++;
            }
            if (GXFri.Checked == true)
            {
                if (cnt == 0)
                    gDay += "금";
                else
                    gDay += ", 금";
            }

            string updateQuery = "UPDATE GX SET "
                + "g_name = '" + GXName.Text.ToString() + "', "
                + "g_day = '" + gDay + "', "
                + "g_cash = " + GXCash.Text.ToString() + ", "
                + "g_max_member = " + GXMaxMember.Text.ToString() + ", "
                + "g_start_day = '" + GXStartDtp.Text.ToString() + "', "
                + "g_end_day = '" + GXEndDtp.Text.ToString() + "' WHERE "
                + "g_num = " + GXNum.Text.ToString() + ";";

            string updateInfo = "수정사항이 맞습니까?" + "\n"
                + "프로그램 이름: " + GXName.Text.ToString() + "\n"
                + "날짜: " + gDay + "\n"
                + "금액: " + GXCash.Text.ToString() + "\n"
                + "최대인원: " + GXMaxMember.Text.ToString() + "\n"
                + "시작 날짜: " + GXStartDtp.Text.ToString() + "\n"
                + "종료 날짜: " + GXEndDtp.Text.ToString();
            if (MessageBox.Show(updateInfo, "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(updateQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("수정 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            GXNum.Text = "";
            GXName.Text = "";
            GXCash.Text = "";
            GXMaxMember.Text = "";
            GXMon.Checked = false;
            GXTue.Checked = false;
            GXWen.Checked = false;
            GXTur.Checked = false;
            GXFri.Checked = false;
            showInfo();
        }

        private void GXList_MouseClick(object sender, MouseEventArgs e)
        {
            if (GXList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection items = GXList.SelectedItems;
                ListViewItem listItem = items[0];

                GXNum.Text = listItem.SubItems[0].Text;
                GXName.Text = listItem.SubItems[1].Text;

                if (listItem.SubItems[2].Text.IndexOf("월") != -1)
                    GXMon.Checked = true;
                else
                    GXMon.Checked = false;
                if (listItem.SubItems[2].Text.IndexOf("화") != -1)
                    GXTue.Checked = true;
                else
                    GXTue.Checked = false;
                if (listItem.SubItems[2].Text.IndexOf("수") != -1)
                    GXWen.Checked = true;
                else
                    GXWen.Checked = false;
                if (listItem.SubItems[2].Text.IndexOf("목") != -1)
                    GXTur.Checked = true;
                else
                    GXTur.Checked = false;
                if (listItem.SubItems[2].Text.IndexOf("금") != -1)
                    GXFri.Checked = true;
                else
                    GXFri.Checked = false;

                GXCash.Text = listItem.SubItems[3].Text;
                GXMaxMember.Text = listItem.SubItems[4].Text;
                GXStartDtp.Text = listItem.SubItems[5].Text;
                GXEndDtp.Text = listItem.SubItems[6].Text;
            }
        }

        private void timeGXList_MouseClick(object sender, MouseEventArgs e)
        {
            if (GXList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection GXItems = timeGXList.SelectedItems;
                ListViewItem GXListItem = GXItems[0];

                timeGXNum.Text = GXListItem.SubItems[0].Text;
                timeGXName.Text = GXListItem.SubItems[1].Text;
                timeGXDay.Text = GXListItem.SubItems[2].Text;
                timeGXCash.Text = GXListItem.SubItems[3].Text + " 원";
                timeGXMaxMember.Text = GXListItem.SubItems[4].Text + " 명";
                timeGXStartDtp.Text = GXListItem.SubItems[5].Text;
                timeGXEndDtp.Text = GXListItem.SubItems[6].Text;
            }
        }

        private void timeTrainerList_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection trainerItems = timeTrainerList.SelectedItems;
            ListViewItem trainerListItem = trainerItems[0];

            timeTrainerNum.Text = trainerListItem.SubItems[0].Text;
            timeTrainerName.Text = trainerListItem.SubItems[1].Text;
            timeTrainerAge.Text = trainerListItem.SubItems[3].Text;
            timeTrainerPhone.Text = trainerListItem.SubItems[4].Text;
        }

        private void registerMemberList_MouseClick(object sender, MouseEventArgs e)
        {
            if (registerMemberList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection items = registerMemberList.SelectedItems;
                ListViewItem listItem = items[0];

                rMemberNum.Text = listItem.SubItems[0].Text;
                registerMemberName.Text = listItem.SubItems[1].Text;
                registerMemberPhone.Text = listItem.SubItems[4].Text;
                registerMemberEmail.Text = listItem.SubItems[5].Text;
            }
        }
        private void rTimeNum_Click(object sender, EventArgs e)
        {

        }

        private void registerTimeList_MouseClick(object sender, MouseEventArgs e)
        {
            if (registerTimeList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection items = registerTimeList.SelectedItems;
                ListViewItem listItem = items[0];

                rTimeNum.Text = listItem.SubItems[0].Text;
                registerTimeGXName.Text = listItem.SubItems[1].Text;
                registerTimeDay.Text = listItem.SubItems[2].Text;
                registerTimeTrainer.Text = listItem.SubItems[6].Text;
                registerTimeCash.Text = listItem.SubItems[7].Text;

                int cnt;

                try
                {
                    string selectQuery = "SELECT COUNT(s_num) FROM REGISTER WHERE "
                        + "s_num = " + rTimeNum.Text.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);

                    cnt = Convert.ToInt32(command.ExecuteScalar());

                    registerTimeMember.Text = cnt.ToString();
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void attendMemberListSearchBtn_Click(object sender, EventArgs e)
        {
            string result;
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = attendMemberList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(attendMemberList.Items.Count.ToString()); i++)
                {
                    result = "";
                    listItem = items[i];

                    if (attendMemberListName.Text.ToString() == listItem.SubItems[2].Text.ToString())
                    {
                        result =
                            "회원번호: " + listItem.SubItems[1].Text + "\n"
                            + "이름: " + listItem.SubItems[2].Text + "\n"
                            + "성별: " + listItem.SubItems[3].Text + "\n"
                            + "나이: " + listItem.SubItems[4].Text + "\n"
                            + "전화번호: " + listItem.SubItems[5].Text + "\n"
                            + "메일: " + listItem.SubItems[6].Text + "\n"
                            + "주소: " + listItem.SubItems[7].Text;
                        MessageBox.Show(result, attendDtp.Text.ToString() + "정보");
                        return;
                    }
                }
                MessageBox.Show("일치하는 정보가 없습니다.");
            }
        }

        private void paySuccessBtn_Click(object sender, EventArgs e)
        {
            if (reserveCash.Text == "")
            {
                MessageBox.Show("금액을 입력하세요");
                return;
            }

            ListView.SelectedListViewItemCollection items = registerTimeList.SelectedItems;
            ListViewItem listItem = items[0];

            if (int.Parse(reserveCash.Text) < int.Parse(listItem.SubItems[7].Text))
            {
                MessageBox.Show("결제 금액이 부족합니다.");
            }
            else if (int.Parse(reserveCash.Text) > int.Parse(listItem.SubItems[7].Text))
            {
                int excess = int.Parse(reserveCash.Text) - int.Parse(listItem.SubItems[7].Text);
                MessageBox.Show("결제 금액 초과\n"
                    + "초과액: " + excess.ToString() + "\n"
                    + "반환액: " + excess.ToString() + "\n"
                    + "결제 금액: " + listItem.SubItems[7].Text);
                check = 1;
            }
            else
            {
                MessageBox.Show("결제 완료");
                check = 1;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void registerTimeListSearchBtn_Click(object sender, EventArgs e)
        {
            string result;
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = registerTimeList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(registerTimeList.Items.Count.ToString()); i++)
                {
                    result = "";
                    listItem = items[i];

                    if (registerTimeListGXName.Text.ToString() == listItem.SubItems[1].Text.ToString())
                    {
                        result = "번호: " + listItem.SubItems[0].Text + "\n"
                            + "GX명: " + listItem.SubItems[1].Text + "\n"
                            + "요일: " + listItem.SubItems[2].Text + "\n"
                            + "시간: " + listItem.SubItems[3].Text + "\n"
                            + "시작일: " + listItem.SubItems[4].Text + "\n"
                            + "종료일: " + listItem.SubItems[5].Text + "\n"
                            + "트레이너: " + listItem.SubItems[6].Text + "\n"
                            + "금액: " + listItem.SubItems[7].Text + "\n"
                            + "최대인원: " + listItem.SubItems[8].Text;
                        MessageBox.Show(result, "시간 정보");
                    }
                }
            }
        }

        private void timelistGXNameSearchBtn_Click(object sender, EventArgs e)
        {
            string result;
            if (timeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = timeList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(timeList.Items.Count.ToString()); i++)
                {
                    result = "";
                    listItem = items[i];

                    if (timelistGXName.Text.ToString() == listItem.SubItems[1].Text.ToString())
                    {
                        result = "번호: " + listItem.SubItems[0].Text + "\n"
                            + "GX명: " + listItem.SubItems[1].Text + "\n"
                            + "요일: " + listItem.SubItems[2].Text + "\n"
                            + "시간: " + listItem.SubItems[3].Text + "\n"
                            + "시작일: " + listItem.SubItems[4].Text + "\n"
                            + "종료일: " + listItem.SubItems[5].Text + "\n"
                            + "트레이너: " + listItem.SubItems[6].Text + "\n"
                            + "금액: " + listItem.SubItems[7].Text + "\n"
                            + "최대인원: " + listItem.SubItems[8].Text;
                        MessageBox.Show(result, "시간 정보");
                    }
                }
            }
        }

        private void registerlistMemberNameSearchBtn_Click(object sender, EventArgs e)
        {
            string result;
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = registerList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(registerList.Items.Count.ToString()); i++)
                {
                    result = "";
                    listItem = items[i];

                    if (registerlistMemberName.Text.ToString() == listItem.SubItems[1].Text.ToString())
                    {
                        result = "번호: " + listItem.SubItems[0].Text + "\n"
                            + "회원이름: " + listItem.SubItems[1].Text + "\n"
                            + "연락처: " + listItem.SubItems[2].Text + "\n"
                            + "GX명: " + listItem.SubItems[3].Text + "\n"
                            + "요일: " + listItem.SubItems[4].Text + "\n"
                            + "시작일: " + listItem.SubItems[5].Text + "\n"
                            + "종료일: " + listItem.SubItems[6].Text + "\n"
                            + "트레이너: " + listItem.SubItems[7].Text + "\n"
                            + "금액: " + listItem.SubItems[8].Text + "\n"
                            + "등록일: " + listItem.SubItems[9].Text;
                        MessageBox.Show(result, "시간 정보");
                    }
                }
            }
        }

        private void registerlistGXNameSearchBtn_Click(object sender, EventArgs e)
        {
            string result;
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = registerList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(registerList.Items.Count.ToString()); i++)
                {
                    result = "";
                    listItem = items[i];

                    if (registerlistGXName.Text.ToString() == listItem.SubItems[3].Text.ToString())
                    {
                        result = "번호: " + listItem.SubItems[0].Text + "\n"
                            + "회원이름: " + listItem.SubItems[1].Text + "\n"
                            + "연락처: " + listItem.SubItems[2].Text + "\n"
                            + "GX명: " + listItem.SubItems[3].Text + "\n"
                            + "요일: " + listItem.SubItems[4].Text + "\n"
                            + "시작일: " + listItem.SubItems[5].Text + "\n"
                            + "종료일: " + listItem.SubItems[6].Text + "\n"
                            + "트레이너: " + listItem.SubItems[7].Text + "\n"
                            + "금액: " + listItem.SubItems[8].Text + "\n"
                            + "등록일: " + listItem.SubItems[9].Text;
                        MessageBox.Show(result, "시간 정보");
                    }
                }
            }
        }

        private void timeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (timeList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection GXItems = timeList.SelectedItems;
                ListViewItem GXListItem = GXItems[0];
                timeStartCbb.Text = GXListItem.SubItems[3].Text.Substring(0, 5);
                timeEndCbb.Text = GXListItem.SubItems[3].Text.Substring(11, 5);

                int gNum = 0;
                int tNum = 0;

                try
                {
                    string selectQuery = "SELECT g_num, t_num FROM SCHEDULE WHERE "
                        + "s_num = " + GXListItem.SubItems[0].Text.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    gNum = int.Parse(reader.GetString(0));
                    tNum = int.Parse(reader.GetString(1));

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
                try
                {
                    string selectQuery = "SELECT g_name, g_day, g_cash, g_max_member, g_start_day, g_end_day FROM GX WHERE "
                        + "g_num = " + gNum + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    timeGXNum.Text = gNum.ToString();
                    timeGXName.Text = reader.GetString(0);
                    timeGXDay.Text = reader.GetString(1);
                    timeGXCash.Text = reader.GetString(2);
                    timeGXMaxMember.Text = reader.GetString(3);
                    timeGXStartDtp.Text = reader.GetString(4);
                    timeGXEndDtp.Text = reader.GetString(5);

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
                try
                {
                    string selectQuery = "SELECT t_name, t_age, t_phone FROM TRAINER WHERE "
                        + "t_num = " + tNum + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    timeTrainerNum.Text = tNum.ToString();
                    timeTrainerName.Text = reader.GetString(0);
                    timeTrainerAge.Text = reader.GetString(1);
                    timeTrainerPhone.Text = reader.GetString(2);

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }

        }

        private void registerList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (registerList.SelectedItems != null)
            {
                ListView.SelectedListViewItemCollection memberItems = registerList.SelectedItems;
                ListViewItem memberListItem = memberItems[0];

                registerPayDtp.Text = memberListItem.SubItems[9].Text.ToString();
                registerMemberName.Text = memberListItem.SubItems[1].Text.ToString();
                registerMemberPhone.Text = memberListItem.SubItems[2].Text.ToString();

                int gNum = 0;

                try
                {
                    string selectQuery = "SELECT m_num, s_num FROM REGISTER WHERE "
                        + "r_num = " + memberListItem.SubItems[0].Text.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    rMemberNum.Text = reader.GetString(0);
                    rTimeNum.Text = reader.GetString(1);

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }

                try
                {
                    string selectQuery = "SELECT m_email FROM MEMBER WHERE "
                            + "m_num = " + rMemberNum.Text.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    registerMemberEmail.Text = reader.GetString(0);
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
                try
                {
                    string selectQuery = "SELECT g_num, s_g_name FROM SCHEDULE WHERE "
                            + "s_num = " + rTimeNum.Text.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    registerTimeTrainer.Text = reader.GetString(1);
                    gNum = int.Parse(reader.GetString(0));

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
                try
                {
                    string selectQuery = "SELECT g_name, g_day, g_cash FROM GX WHERE "
                            + "g_num = " + gNum.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    registerTimeGXName.Text = reader.GetString(0);
                    registerTimeDay.Text = reader.GetString(1);
                    registerTimeCash.Text = reader.GetString(2);

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void timeResetBtn_Click(object sender, EventArgs e)
        {
            timeGXNum.Text = "";
            timeGXName.Text = "";
            timeGXDay.Text = "";
            timeGXStartDtp.Text = "";
            timeGXEndDtp.Text = "";
            timeGXCash.Text = "";
            timeGXMaxMember.Text = "";

            timeTrainerNum.Text = "";
            timeTrainerName.Text = "";
            timeTrainerAge.Text = "";
            timeTrainerPhone.Text = "";
            timeStartCbb.Text = "";
            timeEndCbb.Text = "";

        }

        private void attendMemberList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void attendMemberList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void attendMemberList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.attendMemberList.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.attendMemberList.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.attendMemberList.Items)
                    item.Checked = !value;
                this.attendMemberList.Invalidate();
            }
        }

        private void attendMemberList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void attendSearchDtp_Click(object sender, EventArgs e)
        {
            attendMemberList.Items.Clear();
            try
            {
                string SelectQuery = "SELECT COUNT(a_num) FROM ATTEND WHERE "
                    + "a_g_name = '" + attendGXName.Text.ToString() + "' AND "
                    + "a_day = '" + attendDtp.Text.ToString() + "' AND "
                    + "a_start_time = '" + Regex.Replace(attendStartDtp.Text.ToString(), @"\s", "") + ":00' AND "
                    + "a_end_time = '" + Regex.Replace(attendEndDtp.Text.ToString(), @"\s", "") + ":00';";

                connection.Open();
                MySqlCommand command = new MySqlCommand(SelectQuery, connection);
                int count = 0;
                count = Convert.ToInt32(command.ExecuteScalar());

                if (count != 0)
                {
                    MessageBox.Show("이미 체크한 날 입니다.");
                    connection.Close();
                    return;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            string attendTime = Regex.Replace(attendStartDtp.Text.ToString(), @"\s", "") + ":00 ~ " + Regex.Replace(attendEndDtp.Text.ToString(), @"\s", "") + ":00";
            int rNum = 0;

            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = timeList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(timeList.Items.Count.ToString()); i++)
                {
                    listItem = items[i];

                    if (attendGXName.Text.ToString() == listItem.SubItems[1].Text.ToString() && attendTime == listItem.SubItems[3].Text.ToString())
                    {
                        rNum = int.Parse(listItem.SubItems[0].Text.ToString());
                    }
                }
            }

            string selectQuery = "SELECT r_num FROM REGISTER WHERE "
                + "s_num = " + rNum.ToString();

            int cnt = DBCount("REGISTER");
            int[] array = new int[cnt];
            int a = 0;
            
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    array[a] = int.Parse(reader.GetString(0));
                    a++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            ListView.ListViewItemCollection registerItems = registerList.Items;
            ListViewItem registerListItem = new ListViewItem();

            int j = 0;
            
            for (int i = 0; i < int.Parse(registerList.Items.Count.ToString()); i++)
            {
                if (array[j] == 0)
                    break;
                registerListItem = registerItems[i];

                if (array[j] == int.Parse(registerListItem.SubItems[0].Text.ToString()))
                {
                    checkMemberDataList(registerListItem.SubItems[1].Text.ToString());
                    j++;
                }
            }
        }

        private void attendMemberList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void attendSaveBtn_Click(object sender, EventArgs e)
        {
            if(attendMemberList.Items.Count == 0)
            {
                MessageBox.Show("저장할 데이터가 없습니다.");
                return;
            }
            for (int i = 0; i < attendMemberList.Items.Count; i++)
            {
                string attend = "";

                if (attendMemberList.Items[i].Checked.ToString().Equals("True"))
                    attend = "출석";
                else
                    attend = "결석";

                string insertQuery = "INSERT INTO ATTEND(a_g_name, a_m_name, a_m_num, a_day, a_start_time, a_end_time, a_attend, a_day_num) VALUES('"
                    + attendGXName.Text.ToString() + "', "
                    + "'" + attendMemberList.Items[i].SubItems[2].Text.ToString() + "', "
                    + attendMemberList.Items[i].SubItems[1].Text.ToString() + ", "
                    + "'" + Regex.Replace(attendDtp.Text.ToString(), @"\s", "") + "', "
                    + "'" + Regex.Replace(attendStartDtp.Text.ToString(), @"\s", "") + "', "
                    + "'" + Regex.Replace(attendEndDtp.Text.ToString(), @"\s", "") + "', "
                    + "'" + attend + "', "
                    + "1);";

                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
            MessageBox.Show("저장 하였습니다.");
            attendMemberList.Items.Clear();
        }

        private void StatusMemberList_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            {
                e.DrawDefault = true;
            }
        }

        private void StatusMemberList_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            {
                e.DrawDefault = true;
            }
        }

        private void StatusMemberList_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            {
                e.DrawDefault = true;
            }
        }

        private void StatusSearchDtp_Click(object sender, EventArgs e)
        {
            StatusMemberList.Items.Clear();
            try
            {
                string SelectQuery = "SELECT COUNT(a_num) FROM ATTEND WHERE "
                    + "a_g_name = '" + StatusGXName.Text.ToString() + "' AND "
                    + "a_day = '" + StatusDtp.Text.ToString() + "' AND "
                    + "a_start_time = '" + Regex.Replace(StatusStartDtp.Text.ToString(), @"\s", "") + ":00' AND "
                    + "a_end_time = '" + Regex.Replace(StatusEndDtp.Text.ToString(), @"\s", "") + ":00';";

                connection.Open();
                MySqlCommand command = new MySqlCommand(SelectQuery, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
                if(count == 0)
                {
                    MessageBox.Show("해당 내역이 없습니다.");
                    connection.Close();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            string attendTime = Regex.Replace(StatusStartDtp.Text.ToString(), @"\s", "") + ":00 ~ " + Regex.Replace(StatusEndDtp.Text.ToString(), @"\s", "") + ":00";
            int rNum = 0;
            
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = timeList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(timeList.Items.Count.ToString()); i++)
                {
                    listItem = items[i];

                    if (StatusGXName.Text.ToString() == listItem.SubItems[1].Text.ToString() &&
                        attendTime == listItem.SubItems[3].Text.ToString())
                    {
                        rNum = int.Parse(listItem.SubItems[0].Text.ToString());
                    }
                }
            }

            string selectQuery = "SELECT r_num FROM REGISTER WHERE "
                + "s_num = " + rNum.ToString();

            int cnt = DBCount("REGISTER");
            int[] array = new int[cnt];
            int a = 0;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    array[a] = int.Parse(reader.GetString(0));
                    a++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            ListView.ListViewItemCollection registerItems = registerList.Items;
            ListViewItem registerListItem = new ListViewItem();

            int j = 0;
            string startTime = "";
            string endTime = "";
            int sNum = 0;
            int t = 0;
            int l = 0;

            string[] aMemberName = new string[cnt];

            try
            {
                string SelectQuery = "SELECT a_m_name FROM ATTEND WHERE "
                + "a_g_name = '" + StatusGXName.Text.ToString() + "' AND "
                + "a_day = '" + StatusDtp.Text.ToString() + "' AND "
                + "a_start_time = '" + Regex.Replace(StatusStartDtp.Text.ToString(), @"\s", "") + ":00' AND "
                + "a_end_time = '" + Regex.Replace(StatusEndDtp.Text.ToString(), @"\s", "") + ":00';";

                connection.Open();
                MySqlCommand command = new MySqlCommand(SelectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    aMemberName[t] = reader.GetString(0);
                    t++;
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }

            for (int i = 0; i < int.Parse(registerList.Items.Count.ToString()); i++)
            {
                if (array[j] == 0)
                    break;
                registerListItem = registerItems[i];

                try
                {
                    string selecQuery = "SELECT s_num FROM REGISTER WHERE "
                        + "r_num = " + array[j].ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selecQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    sNum = int.Parse(reader.GetString(0));

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }

                try
                {
                    string selecQuery = "SELECT s_start_time, s_end_time FROM SCHEDULE WHERE "
                        + "s_num = " + sNum.ToString() + ";";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(selecQuery, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    startTime = reader.GetString(0);
                    endTime = reader.GetString(1);

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }

                if (array[j] == int.Parse(registerListItem.SubItems[0].Text.ToString()))
                {
                    checkStatusMemberDataList(aMemberName[l++], registerListItem.SubItems[1].Text.ToString(),
                        registerListItem.SubItems[3].Text.ToString(), startTime, endTime);
                    j++;
                }
            }
        }

        private void StatusMemberListSearchBtn_Click(object sender, EventArgs e)
        {
            string result;
            if (registerTimeList.SelectedItems != null)
            {
                ListView.ListViewItemCollection items = StatusMemberList.Items;

                ListViewItem listItem = new ListViewItem();
                for (int i = 0; i < int.Parse(StatusMemberList.Items.Count.ToString()); i++)
                {
                    result = "";
                    listItem = items[i];

                    if (StatusMemberListName.Text.ToString() == listItem.SubItems[2].Text.ToString())
                    {
                        result =
                            "회원번호: " + listItem.SubItems[1].Text + "\n"
                            + "이름: " + listItem.SubItems[2].Text + "\n"
                            + "성별: " + listItem.SubItems[3].Text + "\n"
                            + "나이: " + listItem.SubItems[4].Text + "\n"
                            + "전화번호: " + listItem.SubItems[5].Text + "\n"
                            + "메일: " + listItem.SubItems[6].Text + "\n"
                            + "주소: " + listItem.SubItems[7].Text;
                        MessageBox.Show(result, attendDtp.Text.ToString() + "정보");
                        return;
                    }
                }
                MessageBox.Show("일치하는 정보가 없습니다.");
            }
        }

        private void timeModifyBtn_Click(object sender, EventArgs e)
        {
            if (timeGXNum.Text == "")
            {
                MessageBox.Show("리스트에서 수정할 데이터를 클릭하세요.");
                return;
            }
            if (timeTrainerNum.Text == "")
            {
                MessageBox.Show("리스트에서 수정할 데이터를 클릭하세요.");
                return;
            }

            string updateQuery = "UPDATE SCHEDULE SET "
                + "s_start_time = '" + Regex.Replace(timeStartCbb.Text.ToString(), @"\s", "") + ":00', "
                + "s_end_time = '" + Regex.Replace(timeEndCbb.Text.ToString(), @"\s", "") + ":00' WHERE "
                + "g_num = " + timeGXNum.Text.ToString() + " AND "
                + "t_num = " + timeTrainerNum.Text.ToString() + ";";

            string updateInfo = "수정사항이 맞습니까?" + "\n"
                + "GX명: " + timeGXName.Text.ToString() + "\n"
                + "트레이너 이름: " + timeTrainerName.Text.ToString() + "\n"
                + "시작시간: " + Regex.Replace(timeStartCbb.Text.ToString(), @"\s", "") + "\n"
                + "종료시간: : " + Regex.Replace(timeEndCbb.Text.ToString(), @"\s", "");

            if (MessageBox.Show(updateInfo, "확인", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(updateQuery, connection);

                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show("수정 하였습니다.");
                else
                    MessageBox.Show("실패 하였습니다.");

                connection.Close();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            timeGXNum.Text = "";
            timeGXName.Text = "";
            timeGXDay.Text = "";
            timeGXStartDtp.Text = "";
            timeGXEndDtp.Text = "";
            timeGXCash.Text = "";
            timeGXMaxMember.Text = "";

            timeTrainerNum.Text = "";
            timeTrainerName.Text = "";
            timeTrainerAge.Text = "";
            timeTrainerPhone.Text = "";
            timeStartCbb.Text = "";
            timeEndCbb.Text = "";
            showInfo();
        }
    }
}


