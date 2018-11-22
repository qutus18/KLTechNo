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
using System.Threading;
using System.IO.Ports;
using System.Configuration;
using System.Media;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace CompareLoggingCode
{
    public partial class FormMain : Form
    {
        #region Khai báo
        private string CodeInfo = "intRotaryCW1";
        private string CodeResult;
        private SoundPlayer SoundOK;
        private SoundPlayer SoundBuzz;
        private string CognexCOMInfo;
        private SerialPort CognexCOM;
        private int CodeNumber;
        private string fileDirection;
        private string filename;
        private string CurrentStringCSV = "";
        private DateTime datetimeBegin;
        private DateTime datetimeEnd;
        #endregion

        public FormMain()
        {
            InitializeComponent();
            SoundOK = new SoundPlayer(System.Environment.CurrentDirectory + "\\confirmS.wav");
            SoundBuzz = new SoundPlayer(System.Environment.CurrentDirectory + "\\buzz.wav");

            // Khai báo cổng COM
            CognexCOMInfo = ConfigurationSettings.AppSettings["ComPort"];
            CognexCOM = new SerialPort(CognexCOMInfo, 115200, Parity.None, 8, StopBits.One);
            CognexCOM.DtrEnable = true;
            CognexCOM.RtsEnable = true;
            CognexCOM.DataReceived += new SerialDataReceivedEventHandler(GetDataCognex);
            CognexCOM.Open();

            // Đặt hiển thị về mặc định
            lblResult.BackColor = Color.White;
            lblCode.Text = "";
            lblCode2.Text = "";
            lblResult.Text = "___";
            lblResult.BackColor = Color.Black;

            CodeNumber = 0;

            // Lấy thông tin thư mục lưu csv, chuẩn bị thư mục lưu file log
            fileDirection = ConfigurationSettings.AppSettings["Direction"];
            PrepairFolderAndLogFileName();

            // Update DataBase
            BackUpAndUpateDatabase(fileDirection);
        }

        /// <summary>
        /// Nhấn nút tìm kiếm QRCode
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindCSV_Click(object sender, EventArgs e)
        {
            string tempResult = "NoFound";
            string resultDirectory = "123";
            //CodeInfo = "intRotaryC1W1";
            CodeResult = "NoFound";
            string[] listfile = null;

            // Lấy list file csv trong thư mục lưu trữ
            try
            {
                listfile = Directory.GetFiles(fileDirection, "*.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Tìm kiếm QRCode trong listfile
            int countDouble = 0;
            foreach (var temp in listfile)
            {
                Console.WriteLine(temp);
                // Nếu thỏa mãn điều kiện thì copy ra file tạm để xử lý
                if (temp.IndexOf(DateTime.Now.ToString("yyMMdd")) > 0) ///// Đã sửa bỏ đi + "1"
                {
                    // Đợi copy file ra vị trí tạm, điều kiện kiểm tra đã copy xong = checkDone
                    var checkDone = false;
                    while (!checkDone)
                    {
                        try
                        {
                            if (!Directory.Exists(@"E:\OutputSumCSV")) Directory.CreateDirectory(@"E:\OutputSumCSV");
                            File.Copy(temp, @"E:\OutputSumCSV\tempCSV.txt", true);
                            checkDone = true;
                        }
                        catch
                        {
                            Thread.Sleep(100);
                        }
                    }
                    // Chạy hàm tìm kiếm với file tạm
                    tempResult = SearchCodeInfile(@"E:\OutputSumCSV\tempCSV.txt", CodeInfo);
                }
                // Nếu không, đọc tất cả dữ liệu trong file, tìm xem có QRCode không, nếu có thì chạy hàm tìm kiếm 
                else
                {
                    if (File.ReadAllText(temp).IndexOf(CodeInfo) > 0)
                        tempResult = SearchCodeInfile(temp, CodeInfo);
                }
                // Nếu kết quả là tìm thấy, cập nhật kết quả vào CodeResult
                if (tempResult != "NoFound")
                {
                    CodeResult = tempResult;
                    resultDirectory = temp;
                    countDouble += 1;
                    //break;
                }
            }
            // Cộng thêm số lượng QRCode tìm thấy trong Database vào kết quả kiểm tra trùng
            countDouble += GetNumberQRCodeRepeat(CodeInfo);
            // Nếu tổng số lần tìm thấy > 1 =>> Code đã bị trùng
            if (countDouble > 1) CodeResult = "NGDouble";

            // Nếu tìm thấy Code và không bị trùng
            if ((CodeResult != "NoFound") && (CodeResult != "NGDouble"))
            {
                // Khi này CodeResult sẽ trả ra kết quả 0/1 tương ứng với kết quả đo trong file csv
                if (CodeResult.IndexOf("0") >= 0)
                {
                    lblResult.BackColor = Color.DarkRed;
                    lblResult.Text = "NG";
                }
                if (CodeResult.IndexOf("1") >= 0)
                {
                    if (lblOKNG.Text == "OK")
                    {
                        lblResult.BackColor = Color.DarkGreen;
                        lblResult.Text = "OK";
                    }
                    else
                    {
                        lblResult.BackColor = Color.DarkRed;
                        lblResult.Text = "NG_Code";
                    }
                }
                Console.WriteLine("Kết quả tìm được là : " + CodeResult + "\r\n" + "Trong file : " + resultDirectory);
            }
            else
            {
                // Nếu kiểm tra 2 code đọc khớp nhau, thì tổng hợp kết quả với kết quả tìm kiếm QRCode
                if (lblOKNG.Text == "OK")
                {
                    if (CodeResult == "NoFound")
                    {
                        lblResult.BackColor = Color.Black;
                        lblResult.Text = "NoFound";
                    }
                    if (CodeResult == "NGDouble")
                    {
                        lblResult.BackColor = Color.DarkRed;
                        lblResult.Text = "NGDouble";
                    }
                }
                // Nếu kiểm tra 2 code đọc khác nhau thì hiển thị NG_Code
                else
                {
                    lblResult.BackColor = Color.DarkRed;
                    lblResult.Text = "NG_Code";
                }
            }

            // Ghi kết quả kiểm tra ra file csv
            if (!File.Exists(filename)) ChangeLogFilenameToSaveFile();
            var writer = new StreamWriter(filename, true, Encoding.UTF8);
            if (lblResult.Text == "NGDouble") writer.Write(DateTime.Now.ToString("yy/MM/dd") + DateTime.Now.ToString(",hh:mm:ss") + "," + CodeInfo + ",NG,Double Code");
            if (lblResult.Text == "NoFound") writer.Write(DateTime.Now.ToString("yy/MM/dd") + DateTime.Now.ToString(",hh:mm:ss") + "," + CodeInfo + ",NG,No Found Code");
            if (lblResult.Text == "NG") writer.Write(DateTime.Now.ToString("yy/MM/dd") + DateTime.Now.ToString(",hh:mm:ss") + "," + CodeInfo + ",NG,Not Good");
            if (lblResult.Text == "OK") writer.Write(DateTime.Now.ToString("yy/MM/dd") + DateTime.Now.ToString(",hh:mm:ss") + "," + CodeInfo + ",OK,Good");
            if (lblResult.Text == "NG_Code") writer.Write(DateTime.Now.ToString("yy/MM/dd") + DateTime.Now.ToString(",hh:mm:ss") + "," + CodeInfo + ",NG,Not Correct Code");
            writer.WriteLine("," + CurrentStringCSV);
            CurrentStringCSV = "";
            writer.Close();

            // Âm thanh kiểm tra OK/NG
            if (lblResult.Text == "OK") SoundOK.Play();
            else SoundBuzz.Play();

        }

        private void ChangeLogFilenameToSaveFile()
        {
            try
            {
                filename = filename.Substring(0, filename.IndexOf("Log_")) + "Log_" + DateTime.Now.ToString("_yyyyMMdd") + ".csv";
            }
            catch
            {
                return;
            }
            //Add title
            string tempDir = filename.Substring(0, filename.LastIndexOf("Log") - 1);
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);
            var writer = new StreamWriter(filename, true, Encoding.UTF8);
            writer.WriteLine("Date,Time,QR Code,OK/NG,Infomations,DateCode,TimeCode,QR,OK,ANGLE 1-2,ANGLE 3-4,Model M,Model SM");
            writer.Close();
            Console.WriteLine("0001" + filename.ToString());
        }

        private void PrepairFolderAndLogFileName()
        {
            Console.WriteLine("Prepair Folder");
            if (!Directory.Exists("E:\\LogData\\" + "BarcodeLog"))
                Directory.CreateDirectory("E:\\LogData\\" + "BarcodeLog");
            if (!Directory.Exists("E:\\CsvBackup"))
                Directory.CreateDirectory("E:\\CsvBackup");
            filename = "E:\\LogData\\" + "BarcodeLog" + "\\" + "Log_" + DateTime.Now.ToString("_yyyyMMdd") + ".csv";
        }

        /// <summary>
        /// Tìm kiếm QRCode trong file csv, trả ra kết quả nếu tìm thấy Code, hoặc trả ra Nofound/NGDouble
        /// </summary>
        /// <param name="fileDirection"></param>
        /// <param name="codeInfo"></param>
        /// <returns></returns>
        private string SearchCodeInfile(string fileDirection, string codeInfo)
        {
            string[] tempintAr = new string[50];
            string tempResult = "";
            int CountNG = 0;
            //int countLine = 0;
            FileStream logFileStream = new FileStream(fileDirection, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var reader = new StreamReader(logFileStream))
            {
                while ((!reader.EndOfStream)/* && (countLine < 60)*/)
                {
                    string line = reader.ReadLine();
                    //countLine += 1;
                    //Console.WriteLine(line);
                    if (line.IndexOf(codeInfo) >= 0)
                    {
                        tempintAr = line.Split(',');
                        for (int i = 0; i < tempintAr.Length; i++)
                        {
                            //Console.WriteLine(tempintAr[i] + " ---- ");
                            if (tempintAr[i] == codeInfo)
                            {
                                tempResult = tempintAr[i + 1];
                                CountNG += 1;
                                if (i > 5)
                                {
                                    CurrentStringCSV = line.Substring(line.IndexOf(",,") + 2);
                                }
                                else
                                {
                                    CurrentStringCSV = line.Substring(0, line.IndexOf(",,"));
                                }
                            }
                        }
                    }
                }
            }
            logFileStream.Close();

            if (CountNG == 1) return tempResult;
            else
            {
                if (CountNG == 0) return "NoFound";
                else return "NGDouble";
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Backup file Csv ra 1 thư mục khác, đồng thời cập nhật dữ liệu và Database
        /// </summary>
        /// <param name="path"></param>
        private void BackUpAndUpateDatabase(string path)
        {
            Console.WriteLine("BackUpDB");

            if (Directory.GetFiles(path, "*.csv").Count() > 0)
            {
                foreach (var item in Directory.GetFiles(path, "*.csv"))
                {
                    // Nếu không phải là file trong ngày
                    if (item.IndexOf(DateTime.Now.ToString("yyMMdd")) < 0)
                    {
                        Console.WriteLine("Copy file " + item);
                        File.Copy(item, item.Replace(path, @"E:\CsvBackup"), true);
                        InputFileToDatabase(item);
                        File.Delete(item);
                    }
                }
            }
        }

        /// <summary>
        /// Xử lý dữ liệu nhận về từ Barcode Cognex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDataCognex(object sender, SerialDataReceivedEventArgs e)
        {
            string tempReceive = CognexCOM.ReadLine().Replace("\r\n", "").Replace("\r", "").Replace("\n", "");

            if (tempReceive.Length > 3) CodeNumber += 1;

            if ((tempReceive.Length > 3) && (CodeNumber == 1))
            {
                CodeInfo = tempReceive;
                Console.WriteLine(CodeInfo);
                Invoke(new MethodInvoker(delegate
                {
                    lblCode.Text = CodeInfo;
                    lblCode2.Text = "";

                    lblOKNG.BackColor = Color.White;

                    lblResult.Text = "Wait";
                    lblResult.BackColor = Color.Black;
                }));
            }

            // Nếu đã đọc xong 2 code thì tiến hành tìm kiếm
            if ((tempReceive.Length > 3) && (CodeNumber == 2))
            {
                CodeInfo = tempReceive;
                Console.WriteLine(CodeInfo);
                Invoke(new MethodInvoker(delegate
                {
                    lblCode2.Text = CodeInfo;

                    if (lblCode.Text == lblCode2.Text)
                    {
                        lblOKNG.BackColor = Color.DarkGreen;
                        lblOKNG.Text = "OK";
                    }
                    else
                    {
                        lblOKNG.BackColor = Color.DarkRed;
                        lblOKNG.Text = "NG";
                    }

                    lblResult.Text = "___";
                    lblResult.BackColor = Color.Black;

                    // Kích hoạt nút tìm kiếm QRCode
                    btnFindCSV.PerformClick();
                }));
                CodeNumber = 0;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CognexCOM.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTestsound_Click(object sender, EventArgs e)
        {
            SoundBuzz.Play();
        }

        /// <summary>
        /// Đóng ứng dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Lựa chọn khoảng ngày tháng năm, sau đó xuất ra file dữ liệu tổng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportSCVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateSelect dateSelect = new DateSelect();
            dateSelect.FormClosing += GetDataDateSelect;
            dateSelect.ShowDialog();
            while (datetimeEnd >= datetimeBegin)
            {
                writeCSVtoOutputFolder(datetimeBegin);
                datetimeBegin = datetimeBegin.AddDays(1);
            }
        }

        /// <summary>
        /// Ghi dữ liệu ngày tháng được chọn ra file CSV tổng theo ngày
        /// </summary>
        /// <param name="datetimeBegin"></param>
        private void writeCSVtoOutputFolder(DateTime datetimeBegin)
        {
            string urlOutput = "E:\\OutputSumCSV\\";
            string urlInput = fileDirection;
            if (!Directory.Exists(urlOutput)) Directory.CreateDirectory(urlOutput);
            List<string> SumCSVList = new List<string>();
            int count = 0;
            foreach (var item in Directory.GetFiles(urlInput, "*.csv"))
            {
                if ((item as string).IndexOf(datetimeBegin.ToString("yyMMdd")) >= 0)
                {
                    List<string> templines1 = new List<string>();
                    string[] templines = File.ReadAllLines(item as string);
                    if (count > 0)
                        templines1 = templines.Skip(1).Take(templines.Length - 1).ToList<string>();
                    else
                        templines1 = templines.Take(templines.Length).ToList<string>();

                    SumCSVList.AddRange(templines1);
                    count += 1;
                }
            }
            if (count > 0)
            {
                File.WriteAllLines(urlOutput + "Log_" + datetimeBegin.ToString("yyyyMMdd") + ".csv", SumCSVList);
            }

        }

        /// <summary>
        /// Lấy dữ liệu ngày tháng năm từ form chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetDataDateSelect(object sender, FormClosingEventArgs e)
        {
            DateSelect temp = sender as DateSelect;
            datetimeBegin = temp.beginDate;
            datetimeEnd = temp.endDate;
        }

        /// <summary>
        /// Kiểm tra từng dòng trong file, nếu có thông tin thì chạy hàm thêm dữ liệu vào DB
        /// </summary>
        /// <param name="filePath"></param>
        private void InputFileToDatabase(string filePath)
        {
            string line = "";
            string[] linearray;
            System.IO.FileStream tempfileStream = new FileStream(filePath, FileMode.Open);
            StreamReader file = new StreamReader(tempfileStream, System.Text.Encoding.UTF8, true, 128);
            while ((line = file.ReadLine()) != null)
            {
                linearray = line.Split(',');
                if (linearray[2].IndexOf('$') > 0) ThemVaoDB("Left", linearray);
                if (linearray[11].IndexOf('$') > 0) ThemVaoDB("Right", linearray);
            }
            file.Close();
        }

        /// <summary>
        /// Lấy dữ liệu từ file csv và thêm vào Database QRCode, Ngày, Kết quả
        /// </summary>
        /// <param name="options"></param>
        /// <param name="linearray"></param>
        private void ThemVaoDB(string options, string[] linearray)
        {
            Console.WriteLine("Them vao DB");
            string qrCode = "", dateTime = "", result = "";
            switch (options)
            {
                case "Left":
                    qrCode = linearray[2];
                    dateTime = linearray[0];
                    if (linearray[3] == "1") result = "true";
                    else result = "false";
                    break;
                case "Right":
                    qrCode = linearray[11];
                    dateTime = linearray[9];
                    if (linearray[12] == "1") result = "true";
                    else result = "false";
                    break;
                default:
                    break;
            }

            // Khai bao Query
            MySqlConnection conn = DBMySQLUtils.GetDBConnection();
            string querySQL = $"insert into latus.kltechdb (QRCode,Datetime,Result) value ('{qrCode}','{dateTime}',{result});";
            //Console.WriteLine($"Query : {querySQL}");
            MySqlCommand sqlCommand = new MySqlCommand(querySQL, conn);
            MySqlDataReader myReader;
            conn.Open();
            myReader = sqlCommand.ExecuteReader();
            while (myReader.Read())
            { }
            conn.Close();
        }

        /// <summary>
        /// Test Query
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CognexCOM.WriteLine("123");
        }

        /// <summary>
        /// Hàm trả về số lần lặp lại QRCode trong SQL
        /// </summary>
        /// <param name="QRInput"></param>
        /// <returns></returns>
        private int GetNumberQRCodeRepeat(string QRInput)
        {
            string temp;
            int count;
            MySqlConnection conn = DBMySQLUtils.GetDBConnection();
            string querySQL = $"select count(*) from latus.kltechdb where QRCode='{QRInput}';";
            MySqlCommand sqlCommand = new MySqlCommand(querySQL, conn);
            MySqlDataReader myReader;
            conn.Open();
            myReader = sqlCommand.ExecuteReader();
            while (myReader.Read())
            {
                count = int.Parse(myReader.GetString(0));
                Console.WriteLine(myReader.GetString(0));
                return count;
            }
            conn.Close();
            return 0;
        }
    }
}
