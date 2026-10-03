namespace bai2th4d
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;
        private Label titleLabel = null!;
        private Label inputLabel = null!;
        private TextBox inputTextBox = null!;
        private Button resetButton = null!;
        private Label outputLabel = null!;
        private TextBox outputTextBox = null!;
        private Button exitButton = null!;
        private Button executeButton = null!;
        private GroupBox sortGroupBox = null!;
        private RadioButton sortAscendingRadioButton = null!;
        private RadioButton sortDescendingRadioButton = null!;
        private GroupBox searchGroupBox = null!;
        private RadioButton searchValueRadioButton = null!;
        private TextBox searchValueTextBox = null!;
        private RadioButton searchPositionRadioButton = null!;
        private TextBox searchPositionTextBox = null!;
        private Label searchResultLabel = null!;
        private TextBox searchResultTextBox = null!;
        private GroupBox deleteGroupBox = null!;
        private RadioButton deleteValueRadioButton = null!;
        private TextBox deleteValueTextBox = null!;
        private RadioButton deletePositionRadioButton = null!;
        private TextBox deletePositionTextBox = null!;
        private Label deleteNoteLabel = null!;
        private GroupBox addGroupBox = null!;
        private RadioButton addValueRadioButton = null!;
        private TextBox addValueTextBox = null!;
        private Label addPositionLabel = null!;
        private TextBox addPositionTextBox = null!;
        private Label addNoteLabel = null!;
        private GroupBox totalGroupBox = null!;
        private Label totalArrayLabel = null!;
        private TextBox totalArrayTextBox = null!;
        private Label totalEvenLabel = null!;
        private TextBox totalEvenTextBox = null!;
        private Label totalOddLabel = null!;
        private TextBox totalOddTextBox = null!;
        private Button totalButton = null!;
        private GroupBox minMaxGroupBox = null!;
        private Label maximumLabel = null!;
        private TextBox maximumTextBox = null!;
        private Label minimumLabel = null!;
        private TextBox minimumTextBox = null!;
        private Button findMinMaxButton = null!;
        private GroupBox replaceGroupBox = null!;
        private RadioButton replaceValueRadioButton = null!;
        private TextBox replaceValueTextBox = null!;
        private RadioButton replacePositionRadioButton = null!;
        private TextBox replacePositionTextBox = null!;
        private Label replacementLabel = null!;
        private TextBox replacementTextBox = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            titleLabel = new Label();
            inputLabel = new Label();
            inputTextBox = new TextBox();
            resetButton = new Button();
            outputLabel = new Label();
            outputTextBox = new TextBox();
            exitButton = new Button();
            executeButton = new Button();
            sortGroupBox = new GroupBox();
            sortAscendingRadioButton = new RadioButton();
            sortDescendingRadioButton = new RadioButton();
            searchGroupBox = new GroupBox();
            searchValueRadioButton = new RadioButton();
            searchValueTextBox = new TextBox();
            searchPositionRadioButton = new RadioButton();
            searchPositionTextBox = new TextBox();
            searchResultLabel = new Label();
            searchResultTextBox = new TextBox();
            deleteGroupBox = new GroupBox();
            deleteValueRadioButton = new RadioButton();
            deleteValueTextBox = new TextBox();
            deletePositionRadioButton = new RadioButton();
            deletePositionTextBox = new TextBox();
            deleteNoteLabel = new Label();
            addGroupBox = new GroupBox();
            addValueRadioButton = new RadioButton();
            addValueTextBox = new TextBox();
            addPositionLabel = new Label();
            addPositionTextBox = new TextBox();
            addNoteLabel = new Label();
            totalGroupBox = new GroupBox();
            totalArrayLabel = new Label();
            totalArrayTextBox = new TextBox();
            totalEvenLabel = new Label();
            totalEvenTextBox = new TextBox();
            totalOddLabel = new Label();
            totalOddTextBox = new TextBox();
            totalButton = new Button();
            minMaxGroupBox = new GroupBox();
            maximumLabel = new Label();
            maximumTextBox = new TextBox();
            minimumLabel = new Label();
            minimumTextBox = new TextBox();
            findMinMaxButton = new Button();
            replaceGroupBox = new GroupBox();
            replaceValueRadioButton = new RadioButton();
            replaceValueTextBox = new TextBox();
            replacePositionRadioButton = new RadioButton();
            replacePositionTextBox = new TextBox();
            replacementLabel = new Label();
            replacementTextBox = new TextBox();
            sortGroupBox.SuspendLayout();
            searchGroupBox.SuspendLayout();
            deleteGroupBox.SuspendLayout();
            addGroupBox.SuspendLayout();
            totalGroupBox.SuspendLayout();
            minMaxGroupBox.SuspendLayout();
            replaceGroupBox.SuspendLayout();
            SuspendLayout();

            var font = new Font("Times New Roman", 10F);

            titleLabel.Font = new Font("Times New Roman", 20F, FontStyle.Bold);
            titleLabel.ForeColor = Color.Firebrick;
            titleLabel.Location = new Point(60, 12);
            titleLabel.Size = new Size(390, 42);
            titleLabel.Text = "Mảng Số Nguyên";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            inputLabel.Location = new Point(18, 66);
            inputLabel.Size = new Size(104, 30);
            inputLabel.Text = "Nhập mảng:";
            inputLabel.TextAlign = ContentAlignment.MiddleLeft;

            inputTextBox.Font = font;
            inputTextBox.Location = new Point(126, 66);
            inputTextBox.Size = new Size(213, 30);

            resetButton.Location = new Point(348, 64);
            resetButton.Size = new Size(82, 32);
            resetButton.Text = "Reset";

            outputLabel.Location = new Point(18, 103);
            outputLabel.Size = new Size(108, 30);
            outputLabel.Text = "Kết quả mảng:";
            outputLabel.TextAlign = ContentAlignment.MiddleLeft;

            outputTextBox.Font = font;
            outputTextBox.Location = new Point(126, 103);
            outputTextBox.ReadOnly = true;
            outputTextBox.Size = new Size(213, 30);

            exitButton.Location = new Point(348, 101);
            exitButton.Size = new Size(82, 32);
            exitButton.Text = "Thoát";

            executeButton.Font = new Font(font, FontStyle.Bold);
            executeButton.Location = new Point(20, 145);
            executeButton.Size = new Size(108, 58);
            executeButton.Text = "Thực Hiện";

            sortGroupBox.Controls.Add(sortAscendingRadioButton);
            sortGroupBox.Controls.Add(sortDescendingRadioButton);
            sortGroupBox.Location = new Point(138, 142);
            sortGroupBox.Size = new Size(292, 62);
            sortGroupBox.Text = "Sắp Xếp";
            sortAscendingRadioButton.Location = new Point(12, 22);
            sortAscendingRadioButton.Size = new Size(130, 25);
            sortAscendingRadioButton.Text = "Sắp xếp Tăng";
            sortDescendingRadioButton.Location = new Point(157, 22);
            sortDescendingRadioButton.Size = new Size(130, 25);
            sortDescendingRadioButton.Text = "Sắp xếp Giảm";

            searchGroupBox.Controls.Add(searchValueRadioButton);
            searchGroupBox.Controls.Add(searchValueTextBox);
            searchGroupBox.Controls.Add(searchPositionRadioButton);
            searchGroupBox.Controls.Add(searchPositionTextBox);
            searchGroupBox.Controls.Add(searchResultLabel);
            searchGroupBox.Controls.Add(searchResultTextBox);
            searchGroupBox.Location = new Point(18, 210);
            searchGroupBox.Size = new Size(205, 122);
            searchGroupBox.Text = "Tìm Kiếm";
            searchValueRadioButton.Location = new Point(8, 22);
            searchValueRadioButton.Size = new Size(156, 25);
            searchValueRadioButton.Text = "Tìm giá trị cần tìm";
            searchValueTextBox.Location = new Point(158, 20);
            searchValueTextBox.Size = new Size(34, 28);
            searchPositionRadioButton.Location = new Point(8, 49);
            searchPositionRadioButton.Size = new Size(150, 25);
            searchPositionRadioButton.Text = "Tìm vị trí cần tìm";
            searchPositionTextBox.Location = new Point(158, 47);
            searchPositionTextBox.Size = new Size(34, 28);
            searchResultLabel.Location = new Point(26, 79);
            searchResultLabel.Size = new Size(126, 25);
            searchResultLabel.Text = "Số tìm được là:";
            searchResultTextBox.Location = new Point(158, 77);
            searchResultTextBox.Size = new Size(34, 28);

            deleteGroupBox.Controls.Add(deleteValueRadioButton);
            deleteGroupBox.Controls.Add(deleteValueTextBox);
            deleteGroupBox.Controls.Add(deletePositionRadioButton);
            deleteGroupBox.Controls.Add(deletePositionTextBox);
            deleteGroupBox.Controls.Add(deleteNoteLabel);
            deleteGroupBox.Location = new Point(231, 210);
            deleteGroupBox.Size = new Size(199, 122);
            deleteGroupBox.Text = "Xóa";
            deleteValueRadioButton.Location = new Point(8, 22);
            deleteValueRadioButton.Size = new Size(150, 25);
            deleteValueRadioButton.Text = "Tìm giá trị cần xóa";
            deleteValueTextBox.Location = new Point(157, 20);
            deleteValueTextBox.Size = new Size(32, 28);
            deletePositionRadioButton.Location = new Point(8, 49);
            deletePositionRadioButton.Size = new Size(150, 25);
            deletePositionRadioButton.Text = "Tìm vị trí cần xóa";
            deletePositionTextBox.Location = new Point(157, 47);
            deletePositionTextBox.Size = new Size(32, 28);
            deleteNoteLabel.ForeColor = Color.Firebrick;
            deleteNoteLabel.Location = new Point(37, 79);
            deleteNoteLabel.Size = new Size(135, 24);
            deleteNoteLabel.Text = "Cần sắp xếp tăng";

            addGroupBox.Controls.Add(addValueRadioButton);
            addGroupBox.Controls.Add(addValueTextBox);
            addGroupBox.Controls.Add(addPositionLabel);
            addGroupBox.Controls.Add(addPositionTextBox);
            addGroupBox.Controls.Add(addNoteLabel);
            addGroupBox.Location = new Point(18, 339);
            addGroupBox.Size = new Size(205, 122);
            addGroupBox.Text = "Thêm";
            addValueRadioButton.Location = new Point(8, 22);
            addValueRadioButton.Size = new Size(156, 25);
            addValueRadioButton.Text = "Tìm giá trị cần thêm";
            addValueTextBox.Location = new Point(158, 20);
            addValueTextBox.Size = new Size(34, 28);
            addPositionLabel.Location = new Point(16, 53);
            addPositionLabel.Size = new Size(141, 25);
            addPositionLabel.Text = "Tại vị trí cần thêm:";
            addPositionTextBox.Location = new Point(158, 50);
            addPositionTextBox.Size = new Size(34, 28);
            addNoteLabel.ForeColor = Color.Firebrick;
            addNoteLabel.Location = new Point(37, 82);
            addNoteLabel.Size = new Size(135, 24);
            addNoteLabel.Text = "Cần sắp xếp tăng";

            totalGroupBox.Controls.Add(totalArrayLabel);
            totalGroupBox.Controls.Add(totalArrayTextBox);
            totalGroupBox.Controls.Add(totalEvenLabel);
            totalGroupBox.Controls.Add(totalEvenTextBox);
            totalGroupBox.Controls.Add(totalOddLabel);
            totalGroupBox.Controls.Add(totalOddTextBox);
            totalGroupBox.Controls.Add(totalButton);
            totalGroupBox.Location = new Point(231, 339);
            totalGroupBox.Size = new Size(199, 122);
            totalGroupBox.Text = "Tổng";
            totalArrayLabel.Location = new Point(8, 22);
            totalArrayLabel.Size = new Size(78, 26);
            totalArrayLabel.Text = "Tổng mảng";
            totalArrayTextBox.Location = new Point(91, 20);
            totalArrayTextBox.Size = new Size(48, 28);
            totalEvenLabel.Location = new Point(8, 53);
            totalEvenLabel.Size = new Size(78, 26);
            totalEvenLabel.Text = "Tổng chẵn";
            totalEvenTextBox.Location = new Point(91, 50);
            totalEvenTextBox.Size = new Size(48, 28);
            totalOddLabel.Location = new Point(8, 84);
            totalOddLabel.Size = new Size(78, 26);
            totalOddLabel.Text = "Tổng lẻ";
            totalOddTextBox.Location = new Point(91, 81);
            totalOddTextBox.Size = new Size(48, 28);
            totalButton.Location = new Point(148, 20);
            totalButton.Size = new Size(42, 89);
            totalButton.Text = "Tổng";

            minMaxGroupBox.Controls.Add(maximumLabel);
            minMaxGroupBox.Controls.Add(maximumTextBox);
            minMaxGroupBox.Controls.Add(minimumLabel);
            minMaxGroupBox.Controls.Add(minimumTextBox);
            minMaxGroupBox.Controls.Add(findMinMaxButton);
            minMaxGroupBox.Location = new Point(18, 468);
            minMaxGroupBox.Size = new Size(205, 122);
            minMaxGroupBox.Text = "Max - Min";
            maximumLabel.Location = new Point(8, 23);
            maximumLabel.Size = new Size(103, 26);
            maximumLabel.Text = "Giá trị lớn nhất";
            maximumTextBox.Location = new Point(111, 20);
            maximumTextBox.Size = new Size(36, 28);
            minimumLabel.Location = new Point(8, 59);
            minimumLabel.Size = new Size(103, 26);
            minimumLabel.Text = "Giá trị nhỏ nhất";
            minimumTextBox.Location = new Point(111, 56);
            minimumTextBox.Size = new Size(36, 28);
            findMinMaxButton.Location = new Point(153, 20);
            findMinMaxButton.Size = new Size(39, 76);
            findMinMaxButton.Text = "Tìm";

            replaceGroupBox.Controls.Add(replaceValueRadioButton);
            replaceGroupBox.Controls.Add(replaceValueTextBox);
            replaceGroupBox.Controls.Add(replacePositionRadioButton);
            replaceGroupBox.Controls.Add(replacePositionTextBox);
            replaceGroupBox.Controls.Add(replacementLabel);
            replaceGroupBox.Controls.Add(replacementTextBox);
            replaceGroupBox.Location = new Point(231, 468);
            replaceGroupBox.Size = new Size(199, 122);
            replaceGroupBox.Text = "Thay Thế";
            replaceValueRadioButton.Location = new Point(8, 20);
            replaceValueRadioButton.Size = new Size(153, 25);
            replaceValueRadioButton.Text = "Giá trị cần thay thế";
            replaceValueTextBox.Location = new Point(157, 18);
            replaceValueTextBox.Size = new Size(32, 28);
            replacePositionRadioButton.Location = new Point(8, 51);
            replacePositionRadioButton.Size = new Size(153, 25);
            replacePositionRadioButton.Text = "Vị trí cần thay thế";
            replacePositionTextBox.Location = new Point(157, 49);
            replacePositionTextBox.Size = new Size(32, 28);
            replacementLabel.Location = new Point(26, 82);
            replacementLabel.Size = new Size(125, 26);
            replacementLabel.Text = "Số thay thế là:";
            replacementTextBox.Location = new Point(157, 80);
            replacementTextBox.Size = new Size(32, 28);

            Controls.Add(titleLabel);
            Controls.Add(inputLabel);
            Controls.Add(inputTextBox);
            Controls.Add(resetButton);
            Controls.Add(outputLabel);
            Controls.Add(outputTextBox);
            Controls.Add(exitButton);
            Controls.Add(executeButton);
            Controls.Add(sortGroupBox);
            Controls.Add(searchGroupBox);
            Controls.Add(deleteGroupBox);
            Controls.Add(addGroupBox);
            Controls.Add(totalGroupBox);
            Controls.Add(minMaxGroupBox);
            Controls.Add(replaceGroupBox);

            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 610);
            Font = font;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mảng Số Nguyên";

            sortGroupBox.ResumeLayout(false);
            searchGroupBox.ResumeLayout(false);
            searchGroupBox.PerformLayout();
            deleteGroupBox.ResumeLayout(false);
            deleteGroupBox.PerformLayout();
            addGroupBox.ResumeLayout(false);
            addGroupBox.PerformLayout();
            totalGroupBox.ResumeLayout(false);
            totalGroupBox.PerformLayout();
            minMaxGroupBox.ResumeLayout(false);
            minMaxGroupBox.PerformLayout();
            replaceGroupBox.ResumeLayout(false);
            replaceGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}