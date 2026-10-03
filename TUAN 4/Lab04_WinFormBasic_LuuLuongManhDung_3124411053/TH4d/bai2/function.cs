namespace bai2th4d
{
    public partial class Form1 : Form
    {
        private List<int> numbers = new();

        public Form1()
        {
            InitializeComponent();

            sortAscendingRadioButton.Checked = true;
            resetButton.Click += ResetButton_Click;
            exitButton.Click += (_, _) => Close();
            executeButton.Click += ExecuteButton_Click;
            totalButton.Click += TotalButton_Click;
            findMinMaxButton.Click += FindMinMaxButton_Click;

            searchValueRadioButton.CheckedChanged += (_, _) => SearchWhenReady(searchValueRadioButton, searchValueTextBox);
            searchPositionRadioButton.CheckedChanged += (_, _) => SearchWhenReady(searchPositionRadioButton, searchPositionTextBox);
            searchValueTextBox.KeyDown += (_, e) => RunOnEnter(e, () => Search(searchValueRadioButton, searchValueTextBox));
            searchPositionTextBox.KeyDown += (_, e) => RunOnEnter(e, () => Search(searchPositionRadioButton, searchPositionTextBox));

            deleteValueRadioButton.CheckedChanged += (_, _) => DeleteWhenReady(deleteValueRadioButton, deleteValueTextBox);
            deletePositionRadioButton.CheckedChanged += (_, _) => DeleteWhenReady(deletePositionRadioButton, deletePositionTextBox);
            deleteValueTextBox.KeyDown += (_, e) => RunOnEnter(e, () => Delete(deleteValueRadioButton, deleteValueTextBox));
            deletePositionTextBox.KeyDown += (_, e) => RunOnEnter(e, () => Delete(deletePositionRadioButton, deletePositionTextBox));

            addValueRadioButton.CheckedChanged += (_, _) => AddWhenReady();
            addValueTextBox.KeyDown += (_, e) => RunOnEnter(e, AddWhenReady);
            addPositionTextBox.KeyDown += (_, e) => RunOnEnter(e, AddWhenReady);

            replaceValueRadioButton.CheckedChanged += (_, _) => ReplaceWhenReady();
            replacePositionRadioButton.CheckedChanged += (_, _) => ReplaceWhenReady();
            replaceValueTextBox.KeyDown += (_, e) => RunOnEnter(e, ReplaceWhenReady);
            replacePositionTextBox.KeyDown += (_, e) => RunOnEnter(e, ReplaceWhenReady);
            replacementTextBox.KeyDown += (_, e) => RunOnEnter(e, ReplaceWhenReady);
        }

        private void ResetButton_Click(object? sender, EventArgs e)
        {
            numbers.Clear();
            inputTextBox.Clear();
            outputTextBox.Clear();
            searchValueTextBox.Clear();
            searchPositionTextBox.Clear();
            searchResultTextBox.Clear();
            deleteValueTextBox.Clear();
            deletePositionTextBox.Clear();
            addValueTextBox.Clear();
            addPositionTextBox.Clear();
            totalArrayTextBox.Clear();
            totalEvenTextBox.Clear();
            totalOddTextBox.Clear();
            maximumTextBox.Clear();
            minimumTextBox.Clear();
            replaceValueTextBox.Clear();
            replacePositionTextBox.Clear();
            replacementTextBox.Clear();
        }

        private void ExecuteButton_Click(object? sender, EventArgs e)
        {
            if (!TryReadNumbers(out var values) || !EnsureNumbersExist())
            {
                return;
            }

            if (sortDescendingRadioButton.Checked)
            {
                values.Sort((left, right) => right.CompareTo(left));
            }
            else
            {
                values.Sort();
            }

            SetNumbers(values);
        }

        private void SearchWhenReady(RadioButton option, TextBox textBox)
        {
            if (option.Checked && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                Search(option, textBox);
            }
        }

        private void Search(RadioButton option, TextBox textBox)
        {
            if (!option.Checked || !TryReadNumbers(out var values) || !EnsureNumbersExist() ||
                !TryReadInteger(textBox, "giá trị tìm kiếm", out var query))
            {
                return;
            }

            if (option == searchValueRadioButton)
            {
                var index = values.IndexOf(query);
                searchResultTextBox.Text = index < 0 ? "-1" : (index + 1).ToString();
            }
            else
            {
                searchResultTextBox.Text = query >= 1 && query <= values.Count
                    ? values[query - 1].ToString()
                    : "-1";
            }
        }

        private void DeleteWhenReady(RadioButton option, TextBox textBox)
        {
            if (option.Checked && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                Delete(option, textBox);
            }
        }

        private void Delete(RadioButton option, TextBox textBox)
        {
            if (!option.Checked || !TryReadNumbers(out var values) || !EnsureNumbersExist() ||
                !TryReadInteger(textBox, "giá trị hoặc vị trí cần xóa", out var query))
            {
                return;
            }

            int index;
            if (option == deleteValueRadioButton)
            {
                index = values.IndexOf(query);
            }
            else
            {
                index = query - 1;
                if (index < 0 || index >= values.Count)
                {
                    ShowInvalidPosition(values.Count);
                    return;
                }
            }

            if (index < 0)
            {
                MessageBox.Show("Không tìm thấy giá trị cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            values.RemoveAt(index);
            SetNumbers(values);
        }

        private void AddWhenReady()
        {
            if (addValueRadioButton.Checked &&
                !string.IsNullOrWhiteSpace(addValueTextBox.Text) &&
                !string.IsNullOrWhiteSpace(addPositionTextBox.Text))
            {
                AddNumber();
            }
        }

        private void AddNumber()
        {
            if (!addValueRadioButton.Checked || !TryReadNumbers(out var values) ||
                !TryReadInteger(addValueTextBox, "số cần thêm", out var value) ||
                !TryReadInteger(addPositionTextBox, "vị trí cần thêm", out var position))
            {
                return;
            }

            if (position < 1 || position > values.Count + 1)
            {
                ShowInvalidPosition(values.Count + 1);
                return;
            }

            values.Insert(position - 1, value);
            SetNumbers(values);
        }

        private void TotalButton_Click(object? sender, EventArgs e)
        {
            if (!TryReadNumbers(out var values) || !EnsureNumbersExist())
            {
                return;
            }

            totalArrayTextBox.Text = values.Sum(value => (long)value).ToString();
            totalEvenTextBox.Text = values.Where(value => value % 2 == 0).Sum(value => (long)value).ToString();
            totalOddTextBox.Text = values.Where(value => value % 2 != 0).Sum(value => (long)value).ToString();
        }

        private void FindMinMaxButton_Click(object? sender, EventArgs e)
        {
            if (!TryReadNumbers(out var values) || !EnsureNumbersExist())
            {
                return;
            }

            maximumTextBox.Text = values.Max().ToString();
            minimumTextBox.Text = values.Min().ToString();
        }

        private void ReplaceWhenReady()
        {
            var option = replaceValueRadioButton.Checked
                ? replaceValueRadioButton
                : replacePositionRadioButton;
            var selector = option == replaceValueRadioButton ? replaceValueTextBox : replacePositionTextBox;

            if (option.Checked &&
                !string.IsNullOrWhiteSpace(selector.Text) &&
                !string.IsNullOrWhiteSpace(replacementTextBox.Text))
            {
                ReplaceNumber(option, selector);
            }
        }

        private void ReplaceNumber(RadioButton option, TextBox selector)
        {
            if (!option.Checked || !TryReadNumbers(out var values) || !EnsureNumbersExist() ||
                !TryReadInteger(selector, "giá trị hoặc vị trí cần thay thế", out var query) ||
                !TryReadInteger(replacementTextBox, "số thay thế", out var replacement))
            {
                return;
            }

            int index;
            if (option == replaceValueRadioButton)
            {
                index = values.IndexOf(query);
                if (index < 0)
                {
                    MessageBox.Show("Không tìm thấy giá trị cần thay thế.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                index = query - 1;
                if (index < 0 || index >= values.Count)
                {
                    ShowInvalidPosition(values.Count);
                    return;
                }
            }

            values[index] = replacement;
            SetNumbers(values);
        }

        private void RunOnEnter(KeyEventArgs e, Action operation)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                operation();
            }
        }

        private static void ShowInvalidPosition(int maximum)
        {
            MessageBox.Show(
                $"Vị trí phải nằm trong khoảng từ 1 đến {maximum}.",
                "Vị trí không hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private bool TryReadNumbers(out List<int> result)
        {
            result = new List<int>();
            var tokens = inputTextBox.Text
                .Replace(',', ' ')
                .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (!int.TryParse(token, out var value))
                {
                    MessageBox.Show(
                        $"Giá trị '{token}' không phải là số nguyên hợp lệ.",
                        "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return false;
                }

                result.Add(value);
            }

            numbers = new List<int>(result);
            outputTextBox.Text = FormatNumbers(numbers);
            return true;
        }

        private static string FormatNumbers(IEnumerable<int> values)
        {
            return string.Join(" ", values);
        }

        private bool TryReadInteger(TextBox textBox, string description, out int value)
        {
            if (int.TryParse(textBox.Text, out value))
            {
                return true;
            }

            MessageBox.Show(
                $"Vui lòng nhập {description} là số nguyên.",
                "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }

        private void SetNumbers(IEnumerable<int> values)
        {
            numbers = new List<int>(values);
            inputTextBox.Text = FormatNumbers(numbers);
            outputTextBox.Text = FormatNumbers(numbers);
        }

        private bool EnsureNumbersExist()
        {
            if (numbers.Count > 0)
            {
                return true;
            }

            MessageBox.Show(
                "Mảng chưa có phần tử.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return false;
        }
    }
}
