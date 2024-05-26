using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NumberBox
{
    public static class NumericTextBoxBehavior
    {
        //соаздаём доп свойство для TextBox
        public static readonly DependencyProperty IsNumericProperty =
            DependencyProperty.RegisterAttached("IsNumeric", typeof(bool), typeof(NumericTextBoxBehavior), new PropertyMetadata(false, OnIsNumericChanged));
        
        //получение и установка занчения свойства 
        public static bool GetIsNumeric(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericProperty);
        }
        public static void SetIsNumeric(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericProperty, value);
        }

        // будет ли обрабатываться box при false/tue значении свойства
        private static void OnIsNumericChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if ((bool)e.NewValue)
                {
                    textBox.PreviewTextInput += TextBox_PreviewTextInput;
                }
                else
                {
                    textBox.PreviewTextInput -= TextBox_PreviewTextInput;
                }
            }
        }

        private static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Разрешаем только цифры
            if (!char.IsDigit(e.Text, 0))
            {
                //блокировка ввода
                e.Handled = true;
                return;
            }

            // Получаем текущий текст в TextBox
            string currentText = textBox.Text;

            // Если текст пустой или содержит только ноль, очищаем его перед добавлением нового символа
            if (string.IsNullOrEmpty(currentText) || currentText == "0")
            {
                textBox.Text = e.Text;
                textBox.CaretIndex = textBox.Text.Length;
                e.Handled = true;
                return;
            }

            // Добавляем разделители тысяч (запятые) к числу
            string newText = AddThousandsSeparator(currentText + e.Text);
            textBox.Text = newText;
            textBox.CaretIndex = newText.Length;

            e.Handled = true;
        }

        private static string AddThousandsSeparator(string text)
        {
            // Преобразуем введенное число в числовой формат
            if (decimal.TryParse(text, out decimal value))
            {
                // Форматируем число с разделителями тысяч
                return value.ToString("#,0");
            }

            return text; // Возвращаем исходный текст, если не удалось преобразовать в число
        }
    }
}