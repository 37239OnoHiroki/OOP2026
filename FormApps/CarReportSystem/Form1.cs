using System.ComponentModel;
using static CarReportSystem.CarReport;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReport = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReport;
        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = String.Empty; //メッセージ領域のクリア


            //記録者と車名が未入力だった場合は追加しない
            //String.IsNullOrWhiteSpace(cbAuthor.Text)||String.IsNullOrWhiteSpace()
            if (cbAuthor.Text == String.Empty || cbCarName.Text == String.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Mekar = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReport.Add(carReport);

            //入力履歴を登録
            SetCbAuthor(cbAuthor.Text);
            SetCarName(cbCarName.Text);

            dgvRecords.CurrentRow.Selected = false;//セルの選択を解除する
            ImputItemsAllClear(); //入力項目の全クリア
        }

        private MakerGroup GetRadioButtonMaker() {

            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.輸入車;

            return MakerGroup.その他;

        }
        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }
        private void btNewInput_Click(object sender, EventArgs e) {
            ImPutItemsUpdate();
        }

        private void ImputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;

            dgvRecords.CurrentRow.Selected = false; //セルの選択を解除する
        }
        private void dgvRecords_Click(object sender, EventArgs e) {  //Record押したら該当行の詳細表示

            //if ((dgvRecords is null)
            //               || (!dgvRecords.CurrentRow.Selected)) return;

            //dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            //cbAuthor.Text = (String)dgvRecords.CurrentRow.Cells["Author"].Value;
            //SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Mekar"].Value);
            //cbCarName.Text = (String)dgvRecords.CurrentRow.Cells["CarName"].Value;
            //tbReport.Text = (String)dgvRecords.CurrentRow.Cells["Report"].Value;
            //pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;

            //ImPutItemsUpdate();
        }

        private void SetRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {

                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の入力履歴をコンボボックスに登録（重複なし）
        private void SetCbAuthor(string auther) {
            if (!cbAuthor.Items.Contains(auther))
                cbAuthor.Items.Add(auther);

        }

        //車名の入力履歴をコンボボックスに登録（重複なし）
        private void SetCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }



        private void btDeleteRecord_Click(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null)
                || (!dgvRecords.CurrentRow.Selected)) return;

            //削除したいインデックスをしていしてリストから削除
            listCarReport.RemoveAt(dgvRecords.CurrentRow.Index);

            //ImPutItemsUpdate();//データグリットビュを更新したら呼ぶ

            ImPutItemsUpdate();
        }

        //
        private void ImPutItemsUpdate() {
            if (! dgvRecords.CurrentRow.Selected)
                ImputItemsAllClear();
        }

        private void btModifyRecord_Click(object sender, EventArgs e) {

            //カーポート管理用リストの該当する要素のデータを書き換える
            listCarReport[dgvRecords.CurrentRow.Index].Date = dtpDate.Value;
            listCarReport[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReport[dgvRecords.CurrentRow.Index].Mekar = GetRadioButtonMaker();
            listCarReport[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReport[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReport[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            dgvRecords.Refresh(); //データグリットビューの更新
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null)
                         || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (String)dgvRecords.CurrentRow.Cells["Author"].Value;
            SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Mekar"].Value);
            cbCarName.Text = (String)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (String)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;

            ImPutItemsUpdate(); //データグリッドビューを更新したら呼ぶメソッド
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK) {
                this.BackColor = colorDialog.Color;
            }
        }
    }
}
